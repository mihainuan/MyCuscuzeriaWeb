using MySql.Data.MySqlClient;
using System.Data;

namespace MyCuscuzeriaWeb.Util
{
    public class DAL
    {
        //String connection variables
        private static string Server = "mycuscuzeriadb.mysql.database.azure.com";
        //private static string Server = "localhost"; 
        private static string Database = "cuscuzeriadb";
        private static string User = "mihai@mycuscuzeriadb";
        //private static string User = "mihai";
        private static string Password = "SZ@kM19&L";
        //private static string Password = "";

        private MySqlConnection Connection;

        private string ConnectionString =
            $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=Required;allowPublicKeyRetrieval=true; charset=utf8";

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }

        //Executa: INSERT, UPDATE, DELETE
        public void ExecutaComandoSQL(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }

        //Retorna dados do Banco
        public DataTable RetornaDataTable(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
            DataTable DataTable = new DataTable();
            DataAdapter.Fill(DataTable);
            return DataTable;
        }
    }
}