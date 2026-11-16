using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jamera.Properties;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Jamera.Backup_Restore
{
    class Backup_Restores
    {
        // 1. Get settings from the application
        private string server_name = Settings.Default.server_name;
        private string db_name = Settings.Default.db_name;
        private string user_name = Settings.Default.db_user_name;
        private string password = Settings.Default.db_password;
        private string disk_drive = Settings.Default.backup_drive;

        private string backup_file_full_path;
        private string current_date = DateTime.Now.ToString("dd-MM-yyyy");

        public Backup_Restores()
        {
            // Set the path: e.g. D:\JameraDB\BACKUPS\15-05-2024.bak
            string folder = Path.Combine(disk_drive, db_name, "BACKUPS");
            backup_file_full_path = Path.Combine(folder, "BACKUP - "+db_name+" - ["+current_date +"].bak");
        }

        // Use this to get a clean connection string to any DB on your server
        private string GetConnectionString(string catalog)
        {
            return $@"Data Source={server_name};Initial Catalog={catalog};User ID={user_name};Password={password};Pooling=False;";
        }

        public bool Folder_Create_Exists()
        {
            try
            {
                string folder = Path.Combine(disk_drive, db_name, "BACKUPS");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Folder Permission Error: " + ex.Message);
                return false;
            }
        }

        public void Update_Backup()
        {
            if (!Folder_Create_Exists()) return;

            // Connect to the actual database to back it up
            using (SqlConnection conn = new SqlConnection(GetConnectionString(db_name)))
            {
                try
                {
                    conn.Open();
                    string query = $@"BACKUP DATABASE [{db_name}] TO DISK = '{backup_file_full_path}' WITH FORMAT, INIT, NAME = '{db_name}';";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Hide the file if it was created
                    if (File.Exists(backup_file_full_path))
                    {
                        File.SetAttributes(backup_file_full_path, FileAttributes.Hidden);
                    }

                    //XtraMessageBox.Show("Backup created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Backup Failed: " + ex.Message);
                }
            }
        }

        public void Restore_Database()
        {
            if (!File.Exists(backup_file_full_path))
            {
                XtraMessageBox.Show("Backup file not found at: " + backup_file_full_path);
                return;
            }

            // CRITICAL: We connect to the 'master' database. 
            // We cannot be connected to our app database while restoring it.
            using (SqlConnection conn = new SqlConnection(GetConnectionString("master")))
            {
                try
                {
                    conn.Open();

                    // 1. Kick out all current users/connections (including this app's other connections)
                    // 2. Restore the database with REPLACE (overwrites existing files)
                    // 3. Set back to MULTI_USER mode
                    string sql = $@"
                        ALTER DATABASE [{db_name}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                        
                        RESTORE DATABASE [{db_name}] 
                        FROM DISK = '{backup_file_full_path}' 
                        WITH REPLACE;
                        
                        ALTER DATABASE [{db_name}] SET MULTI_USER;";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Increase timeout to 5 minutes as restores take time
                        cmd.CommandTimeout = 300;
                        cmd.ExecuteNonQuery();
                    }

                    XtraMessageBox.Show("Database restored successfully! The application might need to restart to refresh data.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Restore Error: " + ex.Message + "\n\nTry closing all other windows before restoring.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}