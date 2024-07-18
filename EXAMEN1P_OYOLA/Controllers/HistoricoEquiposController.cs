using EXAMEN1P_OYOLA.Comunes;
using EXAMEN1P_OYOLA.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EXAMEN1P_OYOLA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoEquiposController : ControllerBase
    {

        // GET api/<HistoricoEquiposController>/5
        [HttpGet("{id}")]
        public List<HistoricoEquipo> Get(int id)
        {
            return ConexionDB.GetHistoricoEquipo(id);
        }



    }
}
