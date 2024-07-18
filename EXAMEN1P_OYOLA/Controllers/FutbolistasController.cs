using EXAMEN1P_OYOLA.Comunes;
using EXAMEN1P_OYOLA.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EXAMEN1P_OYOLA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutbolistasController : ControllerBase
    {
        // GET: api/<FutbolistasController>
        [HttpGet]
        public List<Futbolista> Get()
        {
            return ConexionDB.GetFutbolistasActivos();
        }

        // GET api/<FutbolistasController>/5
        [HttpGet("{id}")]
        public Futbolista Get(int id)
        {
            return ConexionDB.GetFutbolista(id);
        }

        // POST api/<FutbolistasController>
        [HttpPost]
        public void Post([FromBody] Futbolista objfutbolista)
        {
            ConexionDB.PostFutbolista(objfutbolista);
        }

        // PUT api/<FutbolistasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Futbolista objfutbolista)
        {
            ConexionDB.PutFutbolista(id, objfutbolista);
        }

        // DELETE api/<FutbolistasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ConexionDB.DeleteFutbolista(id);
        }
    }
}
