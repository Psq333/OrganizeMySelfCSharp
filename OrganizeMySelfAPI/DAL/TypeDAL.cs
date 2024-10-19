using OrganizeMySelfAPI.Models;
using SqlCommandExample.Utilities;
using MySqlConnector;
using System.Data;
using log4net;
using OrganizeMySelfAPI.Controllers;

namespace OrganizeMySelfAPI.DAL
{
    public class TypeDAL
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TypeDAL));

        #region GetTypes
        public static List<TypeModel> GetTypes()
        {
            try
            {
                return getTypes();
            }
            catch (MySqlException e)
            {
                log.Error(e.Message, e);
                throw new Exception("Errore durante l'inserimento del dato");
            }
        }
        public static List<TypeModel> getTypes()
        {
            String query = "SELECT * FROM OrganizeMySelf.Type";
            List<TypeModel> storage = new List<TypeModel>(); ;
            using (MySqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text))
            {
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
        #endregion

        #region GetType
        public static TypeModel GetType(int id)
        {
            try
            {
                return getType(id);
            }
            catch (MySqlException e)
            {
                log.Error(e.Message, e);
                throw new Exception("Errore durante l'inserimento del dato");
            }
        }
        public static TypeModel getType(int id)
        {
            String query = "SELECT * FROM OrganizeMySelf.Type WHERE id = @Id";
            MySqlParameter parameterId = new MySqlParameter("@Id", SqlDbType.Int);
            parameterId.Value = id;
            TypeModel type = new TypeModel();
            using (MySqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text, parameterId))
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
            if (type.Id <= 0) throw new Exception("Elemento non trovato");
            return type;
        }
        #endregion

        #region InsertTypes
        public static int InsertType(TypeModel insertTypeModel)
        {
            try
            {
                return insertType(insertTypeModel);
            }
            catch (MySqlException e)
            {
                log.Error(e.Message, e);
                throw new Exception("Errore durante l'inserimento del dato");
            }
        }
        public static int insertType(TypeModel insertTypeModel)
        {
            String query = "INSERT INTO OrganizeMySelf.Type " +
                "VALUES (@Id, @Type); " +
                "SELECT id FROM OrganizeMySelf.Type ORDER BY id desc LIMIT 1;";
            MySqlParameter[] parameter = {
                 new MySqlParameter("@Id", insertTypeModel.Id),
                new MySqlParameter("@Type", insertTypeModel.Type)
        };
            int id = Convert.ToInt32(SqlHelper.ExecuteScalar(query, CommandType.Text, parameter));
            if(id > 0) return id;
            throw new Exception("Errore durante l'inserimento del tipo");
        }
        #endregion

        #region UpdateTyeps
        public static void UpdateType(TypeModel updateTypeModel)
        {
            try
            {
                updateType(updateTypeModel);
            }
            catch (MySqlException e)
            {
                log.Error(e.Message, e);
                throw new Exception("Errore durante l'inserimento del dato");
            }
        }
        public static void updateType(TypeModel updateTypeModel)
        {
            String query = "UPDATE OrganizeMySelf.Type " +
                "SET type=@Type " +
                "WHERE id=@Id";
            MySqlParameter[] parameters = [
                new MySqlParameter ("@Type", updateTypeModel.Type),
                new MySqlParameter ("@Id", updateTypeModel.Id)
                ];
            int row = SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameters);
            if (row <= 0) throw new Exception("Errore durante l'update del tipo");
        }
        #endregion

        #region DeleteType
        public static void DeleteType(int id)
        {
            try
            {
                deleteType(id);
            }
            catch (MySqlException e)
            {
                log.Error(e.Message, e);
                throw new Exception("Errore durante l'inserimento del dato");
            }
        }
        public static void deleteType(int id)
        {
            String query = "DELETE FROM OrganizeMySelf.Type " +
                "WHERE id = @Id";
            MySqlParameter parameter = new MySqlParameter("@Id", id);
            int row = SqlHelper.ExecuteNonQuery(query, CommandType.Text, parameter);
            if (row <= 0) throw new Exception("Errore durante l'eliminazione del tipo");
        }
        #endregion

    }
}
