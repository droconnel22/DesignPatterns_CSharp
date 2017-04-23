using System;
using System.Configuration;
using System.Web.Configuration;

namespace Shipbob.Data.Configuration
{
    internal static class DataConfiguration
    {
        public static string DatabaseConnectionString
        {
            get
            {
               // return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Shipbob;Integrated Security=True\" providerName = \"System.Data.SqlClient\"";

                var result = ConfigurationManager.ConnectionStrings["ConnectionString"];
                if(result == null)
                {
                    throw new ArgumentNullException(nameof(result));
                }
                return result.ConnectionString;
            }
        }
    }
}