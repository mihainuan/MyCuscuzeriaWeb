using MySql.Data.MySqlClient;
using System.Data;

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
            $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=none;allowPublicKeyRetrieval=true;";

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