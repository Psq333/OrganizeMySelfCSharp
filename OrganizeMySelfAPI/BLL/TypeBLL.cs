using OrganizeMySelfAPI.DAL;
using OrganizeMySelfAPI.Models;

namespace OrganizeMySelfAPI.BLL
{
    public class TypeBLL
    {
        public static List<TypeModel> GetTypes() { return TypeDAL.GetTypes(); }

        public static TypeModel GetType(int id)
        {
            return TypeDAL.GetType(id);
        }

        public static int InsertTypes(TypeModel insertType)
        {
            return TypeDAL.InsertTypes(insertType);
        }

        public static bool UpdateTypes(TypeModel insertType)
        {
            return TypeDAL.UpdateTypes(insertType);
        }

        public static bool DeleteTypes(int id)
        {
            return TypeDAL.DeleteTypes(id);
        }
    }
}
