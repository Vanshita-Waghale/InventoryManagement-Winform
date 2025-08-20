using System.Data.SqlClient;

namespace System.Data
{
    internal class SqlCLient
    {
        internal class SqlDataAdapter
        {
            internal void Fill(DataTable dtItemID)
            {
                throw new NotImplementedException();
            }

            public static implicit operator SqlDataAdapter(SqlClient.SqlDataAdapter v)
            {
                throw new NotImplementedException();
            }
        }
    }
}