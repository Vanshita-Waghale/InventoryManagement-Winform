using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoMaan.DAL
{

    public class CommonCommands : IDisposable
    {
        System.Data.SqlClient.SqlConnection Connection { get; set; }
        public static string ConnectionString { get; set; }
        public object Command { get; private set; }
        public object CurrentException { get; private set; }

        static CommonCommands()
        {
            ConnectionString = @"Data Source=VICSHA;Initial Catalog=db.MangoMan;Trusted_Connection=True;";
        }
        public CommonCommands()
        {
            Connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Executes command
        /// </summary>
        /// <param name="CommandText">SQL Command</param>
        /// <returns>Nofrecords effected -1 if exception occurs</returns>

        // ----------------------
        //  ExecuteNonQuery
        // ----------------------
        public int ExecuteNonQuery(string CommandText, params SqlParameter[] SQLParameters)
        {
            CurrentException = null;
            int NofRecords = 0;

            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                using (SqlCommand cmd = new SqlCommand(CommandText, Connection))
                {
                    if (SQLParameters != null && SQLParameters.Length > 0)
                        cmd.Parameters.AddRange(SQLParameters);

                    NofRecords = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                CurrentException = ex;
                NofRecords = -1;
            }
            finally
            {
                Connection.Close();
            }

            return NofRecords;
        }
        
                        
        public int ExecuteScalar(string CommandText, params SqlParameter[] SQLParameters)
        {
            CurrentException = null;
            int NofRecords = 0;

            try
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                SqlCommand cmd = new SqlCommand(CommandText, Connection);
                {
                    if(SQLParameters.Count()>0)
                    {
                    cmd.Parameters.AddRange(SQLParameters);
                    }
                    
            return (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                CurrentException = ex;
            }
            finally
            {
                Connection.Close();
            }

            return 0;
        }

        // ----------------------
        //  GetData (no parameters)
        // ----------------------
        public DataTable GetData(string SelectCommandText)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                using (SqlDataAdapter DA = new SqlDataAdapter(SelectCommandText, Connection))
                {
                    DA.Fill(dtResult);
                }
            }
            catch (SqlException ex)
            {
                CurrentException = ex;
            }
            finally
            {
                Connection.Close();
            }
            return dtResult;
        }

        // ----------------------
        //  GetData (with parameters)
        // ----------------------
        public DataTable GetData(string SelectCommandText, params SqlParameter[] sqlParameters)
        {
            DataTable dtResult = new DataTable();
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                using (SqlCommand cmd = new SqlCommand(SelectCommandText, Connection))
                {
                    if (sqlParameters != null && sqlParameters.Length > 0)
                        cmd.Parameters.AddRange(sqlParameters);

                    using (SqlDataAdapter DA = new SqlDataAdapter(cmd))
                    {
                        DA.Fill(dtResult);
                    }
                }
            }
            catch (SqlException ex)
            {
                CurrentException = ex;
            }
            finally
            {
                Connection.Close();
            }
            return dtResult;
        }

        public void Dispose()
        {
            if (Connection != null)
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();

                Connection.Dispose();
                Connection = null;
            }
            CurrentException = null;
        }
    }
}
