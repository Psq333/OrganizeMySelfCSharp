using OrganizeMySelfAPI.DAL;
using OrganizeMySelfAPI.Models;

namespace OrganizeMySelfAPI.BLL
{
    public class TypeBLL
    {
        public static List<TypeModel> GetTypes() { 
            return TypeDAL.GetTypes(); 
        }

        public static TypeModel GetType(int id)
        {
            return TypeDAL.GetType(id);
        }

        public static int InsertTypes(TypeModel insertType)
        {
            return TypeDAL.InsertType(insertType);
        }

        public static void UpdateTypes(TypeModel insertType)
        {
            TypeDAL.UpdateType(insertType);
        }

        public static void DeleteTypes(int id)
        {
            TypeDAL.DeleteType(id);
        }
    }
}
