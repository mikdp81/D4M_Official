using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AraneaUtilities.ActiveDirectoryManagedIdentityAuthentication
{
    // Active Directory Managed Identity authentication
    // puo essere di 2 tipi (cambia la stringa di connessione):
    //      1. System-assigned managed identity: is created on a service instance in Azure AD. It's tied to the lifecycle of that service instance.
    //          ConnectionString = @"Server=demo.database.windows.net; Authentication=Active Directory Managed Identity; Database=testdb";

    //      2. User-assigned managed identity: is created as a standalone Azure resource.It can be assigned to one or more instances of an Azure service."system assisted" o "user assisted": dipende da cosa è scritto nella stringa di connessione
    //          ConnectionString1 = @"Server=demo.database.windows.net; Authentication=Active Directory Managed Identity; User Id=ClientIdOfManagedIdentity; Database=testdb";

    public class DbConnection
    {
        private static string CONNECTION_STRING;

        private static SqlConnection _connection;

        public static string Token {
            get { return _connection.AccessToken; }
            private set { _connection.AccessToken = value; }
        }  

        private static SqlConnection CreateConnection(string accessToken)
        {
            // creo la connesione
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);

            // 2. se la connessione non è nulla procedo
            if (connection != null)
                // assegno il token
                connection.AccessToken = accessToken;

            return connection;
        }


        public static SqlConnection GetConnection(string connectionString, string localManagedIdentityURL, string azureResourcesEndpoint)
        {
            // 1. ottengo il token
            string accessToken = AccessToken.Create(localManagedIdentityURL, azureResourcesEndpoint);

            // 2. se il token non è nullo procedo
            if (accessToken != null)
            {
                // se non c'è una connessione esistente la creo e la appendo
                if (_connection == null || !connectionString.Equals(CONNECTION_STRING))
                {
                    CONNECTION_STRING = connectionString;
                    _connection = CreateConnection(accessToken);
                }
                else
                    _connection.AccessToken = accessToken;
            }

            return _connection;
        }

    }
}
