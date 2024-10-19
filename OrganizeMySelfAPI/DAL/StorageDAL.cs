using log4net;
using MySqlConnector;
using OrganizeMySelfAPI.Models;
using SqlCommandExample.Utilities;
using System.Data;

namespace OrganizeMySelfAPI.DAL
{
    public class StorageDAL
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(StorageDAL));

        #region GetStorages
        public static List<StorageModel> GetStorages()
        {
            try
            {
                return getStorages();
            }
            catch (MySqlException e)
            {
                log.Error(e.Message, e);
                throw new Exception("Errore durante la lettura della lista");
            }
        }
        public static List<StorageModel> getStorages()
        {
            String query = "SELECT * FROM OrganizeMySelf.Storage";
            List<StorageModel> storage = new List<StorageModel>();
            using (MySqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text))
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
                        Cash = reader.GetDouble(4),
                        Descrizione = reader.GetString(5),
                    });
                }
            }
            return storage;
        }
        #endregion

        #region GetStorage
        public static StorageModel GetStorage(int id)
        {
            try
            {
                return getStorage(id);
            }
            catch (MySqlException e)
            {
                log.Error(e.Message, e);
                throw new Exception("Errore durante la lettura del dato");
            }
        }

        public static StorageModel getStorage(int id)
        {
            String query = "SELECT * FROM OrganizeMySelf.Storage WHERE id = @Id";
            MySqlParameter parameter = new MySqlParameter("@Id", id);
            StorageModel storage = new StorageModel();
            using (MySqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameter))
            {

                while (reader.Read())
                {
                    storage = new StorageModel()
                    {
                        Id = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        Type = TypeDAL.GetType(reader.GetInt32(2)),
                        Inside = Enum.GetValues<InsideStorage>()[reader.GetInt32(3)],
                        Cash = reader.GetDouble(4),
                        Descrizione = reader.GetString(5),
                    };
                }
            }
            if (storage.Id <= 0) throw new Exception("Elemento non trovato");
            return storage;
        }
        #endregion

        #region InsertStorages
        public static int InsertStorages(StorageModel insertStorage)
        {
            try
            {
                return insertStorages(insertStorage);
            }
            catch (MySqlException e)
            {
                log.Error(e.Message, e);
                throw new Exception("Errore durante l'inserimento del dato");
            }
        }
        public static int insertStorages(StorageModel insertStorage)
        {
            String query = "INSERT INTO OrganizeMySelf.Storage " +
                "VALUES (@Id, @Date,@Id_Type,@Inside,@Cash,@Descrizione); " +
                "SELECT id FROM OrganizeMySelf.Storage ORDER BY id desc LIMIT 1;";
            MySqlParameter[] parameters = [
                new MySqlParameter("@Id", 0),
                    new MySqlParameter("@Date", insertStorage.Date),
                    new MySqlParameter("@Id_Type", insertStorage.Type.Id),
                    new MySqlParameter("@Inside", insertStorage.Inside),
                    new MySqlParameter("@Cash", insertStorage.Cash),
                    new MySqlParameter("@Descrizione", insertStorage.Descrizione),
                ];

            int id = Convert.ToInt32(SqlHelper.ExecuteScalar(query, CommandType.Text, parameters));
            return id;
        }
        #endregion

        #region UpdateStorages
        public static void updateStorages(StorageModel updateStorage)
        {
            try
            {
                UpdateStorages(updateStorage);
            }
            catch (MySqlException e)
            {
                log.Error(e.Message, e);
                throw new Exception("Errore durante la modificata del dato");
            }
        }

        public static void UpdateStorages(StorageModel updateStorage)
        {
            String query = "UPDATE OrganizeMySelf.Storage " +
                "SET date=@Date,id_type=@Id_Type,inside=@Inside,cash=@Cash,descrizione=@Descrizione " +
                "WHERE id=@Id";
            MySqlParameter[] parameters = [
                    new MySqlParameter("@Id", updateStorage.Id),
                    new MySqlParameter("@Date", updateStorage.Date),
                    new MySqlParameter("@Id_Type", updateStorage.Type.Id),
                    new MySqlParameter("@Inside", updateStorage.Inside),
                    new MySqlParameter("@Cash", updateStorage.Cash),
                    new MySqlParameter("@Descrizione", updateStorage.Descrizione),
                ];
            int row = SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
            if (row <= 0) throw new Exception("Errore durante l'update dello Storage");
        }
        #endregion
        public static void DeleteStorages(int id)
        {
            try
            {
                deleteStorages(id);
            }
            catch (MySqlException e)
            {
                log.Error(e.Message, e);
                throw new Exception("Errore durante l'eliminazione del dato");
            }
        }
        public static void deleteStorages(int id)
        {
            String query = "DELETE FROM OrganizeMySelf.Storage " +
                "WHERE id = @Id";
            MySqlParameter parameter = new MySqlParameter("@Id", id);
            int row = SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameter);
            if (row <= 0) throw new Exception("Errore durante l'eliminazione dello Storage");
        }
    }
}
