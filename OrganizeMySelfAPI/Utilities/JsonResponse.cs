using Microsoft.AspNetCore.Mvc;
using OrganizeMySelfAPI.BLL;
using System.Net;

namespace OrganizeMySelfAPI.Utilities
{
    public class JsonResponse
    {

        public static JsonResult JsonResponsePackage(object data, HttpStatusCode status) {
            return new JsonResult(new
            {
                Data = data,
                ContentType = "application/json",
                StatusCode = status,
                MaxJsonLength = UInt16.MaxValue
                //MaxJsonLength = Int32.MaxValue Quasi 2 GB di dati
            });
        }
    }
}
