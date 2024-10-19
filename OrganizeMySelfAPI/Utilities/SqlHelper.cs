using System;
using System.Collections.Generic;
using MySqlConnector;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommandExample.Utilities
{
    class SqlHelper
    {

        //public static String connectionString = "Server=192.168.1.50; Port = 3306; Database=OrganizeMySelf; User Id=root;Password=root;";
        //public static String connectionStringInLocalPC = "Data Source=(local);Initial Catalog=OrganizeMySelf; User Id=psq378;Password=Pasquale2024;";
        public static String connectionStringInLocalRaspberry = "Server=localhost;Database=OrganizeMySelf;User Id=root;Password=root;\r\n";

        // Set the connection, command, and then execute the command with non query.
        public static Int32 ExecuteNonQuery(String commandText,
            CommandType commandType, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionStringInLocalRaspberry))
            {
                using (MySqlCommand cmd = new MySqlCommand(commandText, conn))
                {
                    // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect
                    // type is only for OLE DB.
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // Set the connection, command, and then execute the command and only return one value.
        public static Object ExecuteScalar(String commandText,
            CommandType commandType, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionStringInLocalRaspberry))
            {
                using (MySqlCommand cmd = new MySqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        // Set the connection, command, and then execute the command with query and return the reader.
        public static MySqlDataReader ExecuteReader(String commandText,
            CommandType commandType, params MySqlParameter[] parameters)
        {
            MySqlConnection conn = new MySqlConnection(connectionStringInLocalRaspberry);

            using (MySqlCommand cmd = new MySqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                conn.Open();
                // When using CommandBehavior.CloseConnection, the connection will be closed when the
                // IDataReader is closed.
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }
    }
}
