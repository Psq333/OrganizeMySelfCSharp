using OrganizeMySelfAPI.Models;
using OrganizeMySelfAPI.DAL;
using SqlCommandExample.Utilities;
using System.Data.SqlClient;
using System.Data;

namespace OrganizeMySelfAPI.BLL
{
    public class StorageBLL
    {

        public static List<StorageModel> GetStorages() { return StorageDAL.GetStorages(); }

        public static StorageModel GetStorage(int id)
        {
            return StorageDAL.GetStorage(id);
        }

        public static int InsertStorages(StorageModel insertStorage)
        {
           return StorageDAL.InsertStorages(insertStorage);
        }

        public static bool UpdateStorages(StorageModel insertStorage)
        {
            return StorageDAL.UpdateStorages(insertStorage);
        }

        public static bool DeleteStorages(int id)
        {
            return StorageDAL.DeleteStorages(id);
        }
    }
}
