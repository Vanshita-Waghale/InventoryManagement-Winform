namespace MangoMan.SQLCommands
{
    public class DBFunctions
    {
        public System.Data.DataTable ExecuteSelectCommand(string SelectCommandText)
        {
            // Implementation for executing a SELECT command
            System.Data.SqlClient.SqlConnection Connection = new System.Data.SqlClient.SqlConnection("YourConnectionStringHere");
            Connection.ConnectionString= "@Data Source=VICSHA;Initial Catalog=db.MangoMan;Trusted_Connection=True;";
            Connection.Open();  
            System.Data.SqlClient.SqlCommand mySqlCommand = new System.Data.SqlClient.SqlCommand(SelectCommandText, Connection);
            System.Data.SqlClient.SqlDataAdapter mySqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.DataTable myDataTable = new System.Data.DataTable();
            mySqlDataAdapter.Fill(myDataTable);
            Connection.Close();
            return myDataTable;

        }
    }
}
