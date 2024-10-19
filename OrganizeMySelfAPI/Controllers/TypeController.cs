using log4net;
using Microsoft.AspNetCore.Mvc;
using OrganizeMySelfAPI.BLL;
using OrganizeMySelfAPI.Models;
using OrganizeMySelfAPI.Utilities;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrganizeMySelfAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TypeController));
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                return JsonResponse.JsonResponsePackage(
                    TypeBLL.GetTypes(),
                    HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return JsonResponse.JsonResponsePackage(
                    "Errore durante l'inserimento dell'elemento",
                    HttpStatusCode.InternalServerError);
            }
        }

        // GET api/<TypeController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                return JsonResponse.JsonResponsePackage(
                    TypeBLL.GetType(id),
                    HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return JsonResponse.JsonResponsePackage(
                    "Errore durante l'inserimento dell'elemento",
                    HttpStatusCode.InternalServerError);
            }
        }

        // POST api/<TypeController>
        [HttpPost]
        public JsonResult Insert(TypeModel stype)
        {
            try
            {
                return JsonResponse.JsonResponsePackage(
                    TypeBLL.InsertTypes(stype),
                    HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return JsonResponse.JsonResponsePackage(
                    "Errore durante l'inserimento dell'elemento",
                    HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<TypeController>/5
        [HttpPut]
        public JsonResult Update(TypeModel type)
        {
            try
            {
                TypeBLL.UpdateTypes(type);
                return JsonResponse.JsonResponsePackage(
                    "Elemento modificato correttamente",
                    HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return JsonResponse.JsonResponsePackage(
                    "Errore durante la modifica dell'elemento",
                    HttpStatusCode.InternalServerError);
            }
        }

        // DELETE api/<TypeController>/5
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            try
            {
                TypeBLL.DeleteTypes(id);
                return JsonResponse.JsonResponsePackage(
                    "Elemento eliminato correttamente",
                    HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return JsonResponse.JsonResponsePackage(
                    "Errore durante l'eliminazione dell'elemento",
                    HttpStatusCode.InternalServerError);
            }
        }
    }
}
