using OrganizeMySelfAPI.Models;
using SqlCommandExample.Utilities;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace OrganizeMySelfAPI.DAL
{
    public class StorageDAL
    {
        private readonly static String LastId = "SELECT IDENT_CURRENT('Storage')";
        public static List<StorageModel> GetStorages()
        {
            String query = "SELECT * FROM [OrganizeMySelf].[dbo].[Storage]";
            List<StorageModel> storage = null;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text))
            {
                storage = new List<StorageModel>();
                while (reader.Read())
                {
                    storage.Add(new StorageModel()
                    {
                        Id = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        Type = TypeDAL.GetType(reader.GetInt32(2)),
                        Inside = Enum.GetValues<InsideStorage>()[reader.GetInt32(3)],
                        Cash = reader.GetDecimal(4),
                    });
                }
            }
            return storage;
        }

        public static StorageModel GetStorage(int id)
        {
            String query = "SELECT * FROM [OrganizeMySelf].[dbo].[Storage] WHERE id = @Id";
            SqlParameter parameter = new SqlParameter("@Id", id);
            StorageModel storage = null;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text,parameter))
            {
                
                while (reader.Read())
                {
                    InsideStorage inside;
                    Enum.TryParse<InsideStorage>(reader.GetString(3), out inside);

                    storage = new StorageModel()
                    {
                        Id = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        Type = TypeDAL.GetType(reader.GetInt32(2)),
                        Inside = inside,
                        Cash = reader.GetDecimal(4),
                    };
                }
            }
            return storage;
        }

        public static int InsertStorages(StorageModel insertStorage)
        {
            String query = "INSERT INTO [OrganizeMySelf].[dbo].[Storage] " +
                "VALUES (@Date,@Id_Type,@Inside,@Cash);";
            SqlParameter[] parameters = [
                    new SqlParameter("@Date", insertStorage.Date),
                    new SqlParameter("@Id_Type", insertStorage.Type.Id),
                    new SqlParameter("@Inside", insertStorage.Inside),
                    new SqlParameter("@Cash", insertStorage.Cash),
                ];
            StorageModel storage = null;
            if (SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameters) >= 1)
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(LastId, CommandType.Text))
                {
                    return reader.GetInt32(0);
                }
            }
            return 0;
        }

        public static bool UpdateStorages(StorageModel updateStorage)
        {
            String query = "UPDATE [OrganizeMySelf].[dbo].[Storage] " +
                "SET date=@Date,id_type=@Id_Type,inside=@Inside,cash=@Cash " +
                "WHERE id=@Id";
            SqlParameter[] parameters = [
                    new SqlParameter("@Id", updateStorage.Id),
                    new SqlParameter("@Date", updateStorage.Date),
                    new SqlParameter("@Id_Type", updateStorage.Type.Id),
                    new SqlParameter("@Inside", updateStorage.Inside),
                    new SqlParameter("@Cash", updateStorage.Cash),
                ];
            StorageModel storage = null;
            if (SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameters) >= 1)
            {
                return true;
            }
            return false;
        }

        public static bool DeleteStorages(int id)
        {
            String query = "DELETE FROM [OrganizeMySelf].[dbo].[Storage] " +
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
