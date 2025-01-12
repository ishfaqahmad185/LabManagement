using Microsoft.Data.SqlClient;

namespace LabManagement.Services
{
    public class BackupService
    {
        private readonly string _backupDirectory = @"C:\Backups\";

        public void CreateBackup()
        {
            var backupFile = Path.Combine(_backupDirectory, $"Backup_{DateTime.Now:yyyyMMddHHmmss}.bak");

            // Replace with your SQL Server connection string
            var connectionString = "your_connection_string_here";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand($"BACKUP DATABASE [LabManagementDb] TO DISK = '{backupFile}'", connection);
                command.ExecuteNonQuery();
            }
        }

        public void RestoreBackup(string backupFile)
        {
            var connectionString = "your_connection_string_here";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand($"RESTORE DATABASE [LabManagementDb] FROM DISK = '{backupFile}'", connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
