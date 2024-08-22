using OrganizeMySelfAPI.Models;
using SqlCommandExample.Utilities;
using System.Data.SqlClient;
using System.Data;

namespace OrganizeMySelfAPI.DAL
{
    public class TypeDAL
    {
        private readonly static String LastId = "SELECT IDENT_CURRENT('Type') As LastID;";
        public static List<TypeModel> GetTypes()
        {
            String query = "SELECT * FROM [OrganizeMySelf].[dbo].[Type]";
            List<TypeModel> storage = null;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text))
            {
                storage = new List<TypeModel>();
                while (reader.Read())
                {
                    storage.Add(new TypeModel()
                    {
                        Id = reader.GetInt32(0),
                        Type = reader.GetString(1)
                    });
                }
            }
            return storage;
        }

        public static TypeModel GetType(int id)
        {
            String query = "SELECT * FROM [OrganizeMySelf].[dbo].[Type] WHERE id = @Id";
            SqlParameter parameterId = new SqlParameter("@Id", SqlDbType.Int);
            parameterId.Value = id;
            TypeModel type = null;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameterId))
            {
                while (reader.Read())
                {
                    type = new TypeModel()
                    {
                        Id = reader.GetInt32("id"),
                        Type = reader.GetString("type")
                    };
                }
            }
            return type;
        }

        public static int InsertTypes(TypeModel insertType)
        {
            String query = "INSERT INTO [OrganizeMySelf].[dbo].[Type] " +
                "VALUES (@Type)" +
                " SELECT IDENT_CURRENT('Type') As LastID;";
            SqlParameter parameter = new SqlParameter("@Type", insertType.Type);
            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameter))
            {
                return 0;
            }
            return 0;
        }

        public static bool UpdateTypes(TypeModel updateType)
        {
            String query = "UPDATE [OrganizeMySelf].[dbo].[Type] " +
                "SET type=@Type " +
                "WHERE id=@Id";
            SqlParameter[] parameters = [
                new SqlParameter("@Type", updateType.Type),
                new SqlParameter("@Id", updateType.Id)
                ];
            StorageModel storage = null;
            if (SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameters) >= 1)
            {
                return true;
            }
            return false;
        }

        public static bool DeleteTypes(int id)
        {
            String query = "DELETE FROM [OrganizeMySelf].[dbo].[Type] " +
                "WHERE id = @Id";
            SqlParameter parameter = new SqlParameter("@Id", id);
            if (SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameter) >= 1)
            {
                return true;
            }
            return false;
        }
        
    }
}
