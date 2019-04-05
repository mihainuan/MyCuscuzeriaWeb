using MySql.Data.MySqlClient;

namespace MyCuscuzeriaWeb.Util
{
    public class DAL
    {
        private static string Server = "localhost";
        private static string Database = "cuscuzeriadb";
        private static string User = "mihai";
        private static string Password = "mihai";
        private MySqlConnection Connection;

        private string ConnectionString =
            $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=none;";

        public DAL()
        {
            Connection = new MySqlConnection();
            Connection.Open();
        }
    }
}