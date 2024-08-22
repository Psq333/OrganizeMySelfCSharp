using Microsoft.AspNetCore.Mvc;
using OrganizeMySelfAPI.BLL;
using OrganizeMySelfAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrganizeMySelfAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<TypeModel>> Get()
        {
            return Ok(TypeBLL.GetTypes());
        }

        // GET api/<TypeController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(TypeBLL.GetType(id));
        }

        // POST api/<TypeController>
        [HttpPost]
        public ActionResult Insert(TypeModel stype)
        {
            return Ok(TypeBLL.InsertTypes(stype));
        }

        // PUT api/<TypeController>/5
        [HttpPut]
        public ActionResult Update(TypeModel stype)
        {
            return Ok(TypeBLL.UpdateTypes(stype));
        }

        // DELETE api/<TypeController>/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return Ok(TypeBLL.DeleteTypes(id));
        }
    }
}
