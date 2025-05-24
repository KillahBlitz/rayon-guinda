using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RayonGuinda.Operaciones;
using RayonGuinda.Models;


namespace APIrestRayonGuinda.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // Definimos el objeto usuarioDAO que nos permite acceder a la base de datos
        private UsuarioDAO usuarioDAO = new UsuarioDAO();

        //Hago una funcion para registrar un usario a la base de datos
        [HttpPost("registro")]
        //aqui hacemos una funcion para registrar un usuario
        public bool RegistrarUsuario([FromBody] UsuarioModel usuario)
        {
            //regresamos el metodo de registrarusuario de la clase UsuarioDAO
            return usuarioDAO.Registrarse(usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Nombres, usuario.FechaNacimiento, usuario.CorreoInstitucional, usuario.Contraseña);
        }

        [HttpPost("login")]
        //aqui hacemos una funcion para logear a un usuario
        public bool login([FromBody] UsuarioModel usuario)
        {
            //regresamos el metodo de login de la clase UsuarioDAO
            return usuarioDAO.Logearse(usuario.CorreoInstitucional, usuario.Contraseña);
        }

        [HttpGet("getid")]
        //aqui hacemos una funcion para obtener el id de un usuario
        public int getid([FromQuery] UsuarioModel usuario)
        {
            //regresamos el metodo de getid de la clase UsuarioDAO
            return usuarioDAO.ObtenerIdUsuario(usuario.CorreoInstitucional);
        }

        [HttpGet("getusuario")]
        //aqui hacemos una funcion para obtener todos los datos del usuario de acuerdo a su id
        public UserAux getusuario([FromQuery] int id)
        {
            //regresamos el metodo de getusuario de la clase UsuarioDAO
            return usuarioDAO.ConsultarUsuario(id);
        }

        [HttpGet("usergropus")]
        //aqui hacemos una funcion para obtener todos los grupos a los que pertenece el usuario de acuerdo a su id
        public List<string> getgrupos([FromQuery] int id)
        {
            //regresamos el metodo de getgrupos de la clase UsuarioDAO
            return usuarioDAO.GruposUsuario(id);
        }
    }

}
