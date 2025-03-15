namespace DataTaminMVC.DbAccess
{
    public class DbSetup
    {
        private static readonly string _connectionString = "Server=.;Database=bookstore;Trusted_Connection=True;TrustServerCertificate=True;";
        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
