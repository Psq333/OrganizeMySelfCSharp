using OrganizeMySelfAPI.Models;
using OrganizeMySelfAPI.DAL;

namespace OrganizeMySelfAPI.BLL
{
    public class StorageBLL
    {

        public static List<StorageModel> GetStorages() { 
            return StorageDAL.GetStorages(); 
        }

        public static StorageModel GetStorage(int id)
        {
            return StorageDAL.GetStorage(id);
        }

        public static int InsertStorages(StorageModel insertStorage)
        {
           return StorageDAL.InsertStorages(insertStorage);
        }

        public static void UpdateStorages(StorageModel insertStorage)
        {
            StorageDAL.UpdateStorages(insertStorage);
        }

        public static void DeleteStorages(int id)
        {
            StorageDAL.DeleteStorages(id);
        }
    }
}
