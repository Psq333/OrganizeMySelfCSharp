using Microsoft.AspNetCore.Mvc;
using OrganizeMySelfAPI.Models;
using OrganizeMySelfAPI.BLL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrganizeMySelfAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        // GET: api/<StorageController>
        [HttpGet]
        public ActionResult<List<StorageModel>> Get()
        {
            return Ok(StorageBLL.GetStorages());
        }

        // GET api/<StorageController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(StorageBLL.GetStorage(id));
        }

        // POST api/<StorageController>
        [HttpPost]
        public ActionResult Insert(StorageModel storage)
        {
            return Ok(StorageBLL.InsertStorages(storage));
        }

        // PUT api/<StorageController>/5
        [HttpPut]
        public ActionResult Update(StorageModel storage)
        {
            return Ok(StorageBLL.UpdateStorages(storage));
        }

        // DELETE api/<StorageController>/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return Ok(StorageBLL.DeleteStorages(id));
        }
    }
}
