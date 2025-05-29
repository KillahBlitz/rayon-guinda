using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RayonGuinda.Operaciones;

namespace APIrestRayonGuinda.Controllers
{
    [Route("api")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        // Definimos el objeto grupoDAO que nos permite acceder a la base de datos
        private GrupoDAO GrupoDAO = new GrupoDAO();

        // Metodo para crear un codigo unico del grupo
        [HttpGet("crearcodigogrupo")]
        public string CrearCodigoGrupo()
        {
            // Llamamos al metodo CrearCodigoGrupo de la clase GrupoDAO y regresamos el codigo generado
            return GrupoDAO.CrearCodigoGrupo();
        }
    }
}
