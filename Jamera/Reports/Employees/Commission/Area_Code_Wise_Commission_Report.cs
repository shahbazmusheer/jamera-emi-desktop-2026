using DevExpress.CodeParser;
using DevExpress.DataAccess.Sql;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.XtraReports.UI;
using Jamera.Items;
using Jamera.Properties;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Jamera.Reports.Employees.Commission
{
    public partial class Area_Code_Wise_Commission_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Area_Code_Wise_Commission_Report(String Start_Date, String End_Date, int store_id, String store_name)
        {
            InitializeComponent();

            // Fill Header Parameters
            from_date.Value = Start_Date;
            to_date.Value = End_Date;
            if (store_id > -1) { 
                store.Value = store_name;
            }
            else
            {
                store.Value = "";
            }
                company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;

            // Refresh Data Query
            sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);

            CustomSqlQuery query = new CustomSqlQuery();
            query.Name = "Query";

            // This query now joins Items -> SaleItems -> Aggrements
            query.Sql = @"SELECT 
                            items.id AS 'Item.Code', 
                            items.name AS 'Item', 
                            CAST(SUM(ISNULL(si.sold_qty, 0)) AS INT) AS 'Total Sale', 
                            CAST(SUM(ISNULL(si.returned_quantity, 0)) AS INT) AS 'Sale Returns', 
                            CAST(SUM(ISNULL(si.sold_qty, 0) - ISNULL(si.returned_quantity, 0)) AS INT) AS 'Net Sale', 
                            CAST(SUM((ISNULL(si.sold_qty, 0) - ISNULL(si.returned_quantity, 0)) * ISNULL(com.area_manager, 0)) AS DECIMAL(18,2)) AS 'Area Manager', 
                            CAST(SUM((ISNULL(si.sold_qty, 0) - ISNULL(si.returned_quantity, 0)) * ISNULL(com.senior_secretary, 0)) AS DECIMAL(18,2)) AS 'Senior Secretary', 
                            CAST(SUM((ISNULL(si.sold_qty, 0) - ISNULL(si.returned_quantity, 0)) * ISNULL(com.junior_secretary, 0)) AS DECIMAL(18,2)) AS 'Junior Secretary', 
                            CAST(SUM((ISNULL(si.sold_qty, 0) - ISNULL(si.returned_quantity, 0)) * ISNULL(com.salesman, 0)) AS DECIMAL(18,2)) AS 'Salesman', 
                            CAST(SUM((ISNULL(si.sold_qty, 0) - ISNULL(si.returned_quantity, 0)) * (ISNULL(com.area_manager, 0) + ISNULL(com.senior_secretary, 0) + ISNULL(com.junior_secretary, 0) + ISNULL(com.salesman, 0))) AS DECIMAL(18,2)) AS 'Total' 
                        FROM dbo.items AS items 
                        INNER JOIN dbo.sale_items AS si ON items.id = si.item_id 
                        INNER JOIN dbo.aggrements AS agg ON si.agreement_id = agg.id 
                        -- The FIX: Use CROSS APPLY TOP 1 to prevent row multiplication
                        CROSS APPLY (
                            SELECT TOP 1 area_manager, senior_secretary, junior_secretary, salesman 
                            FROM dbo.commissions 
                            WHERE item_id = items.id
                            ORDER BY id DESC -- Takes the latest commission set if duplicates exist
                        ) AS com
                         WHERE (agg.date >= @pFrom AND agg.date <= @pTo) 
                         AND (@pStoreId = -1 OR agg.store_id = @pStoreId) 
                        GROUP BY items.id, items.name 
                        HAVING SUM(ISNULL(si.sold_qty, 0) - ISNULL(si.returned_quantity, 0)) > 0";

            // Ensure parameters match the data types in the database
            query.Parameters.Add(new QueryParameter("@pFrom", typeof(DateTime), DateTime.Parse(Start_Date)));
            query.Parameters.Add(new QueryParameter("@pTo", typeof(DateTime), DateTime.Parse(End_Date)));
            query.Parameters.Add(new QueryParameter("@pStoreId", typeof(int), store_id));

            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.Fill();
        }
    }
}
