using Microsoft.AspNetCore.Mvc;
using OrganizeMySelfAPI.Models;
using OrganizeMySelfAPI.BLL;
using System.Collections.Generic;
using System.Net;
using OrganizeMySelfAPI.Utilities;
using log4net;
using OrganizeMySelfAPI.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrganizeMySelfAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(StorageController));
        // GET: api/<StorageController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                return JsonResponse.JsonResponsePackage(
                    StorageBLL.GetStorages(), 
                    HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return JsonResponse.JsonResponsePackage(
                    "Errore durante la lettura degli elementi", 
                    HttpStatusCode.InternalServerError);
            }
        }

        // GET api/<StorageController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                return JsonResponse.JsonResponsePackage(
                    StorageBLL.GetStorage(id),
                    HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return JsonResponse.JsonResponsePackage(
                    "Errore durante la lettura dell'elemento",
                    HttpStatusCode.InternalServerError);
            }
        }

        // POST api/<StorageController>
        [HttpPost]
        public JsonResult Insert(StorageModel storage)
        {
            try
            {
                return JsonResponse.JsonResponsePackage(
                    StorageBLL.InsertStorages(storage),
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

        //PUT api/<StorageController>/5
        [HttpPut]
        public JsonResult Update(StorageModel storage)
        {
            try
            {
                StorageBLL.UpdateStorages(storage);
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

        // DELETE api/<StorageController>/5
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            try
            {
                StorageBLL.DeleteStorages(id);
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
