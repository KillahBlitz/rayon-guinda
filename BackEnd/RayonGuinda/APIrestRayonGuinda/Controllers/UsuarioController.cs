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

        [HttpPost("recuperarpassword")]
        //aqui hacemos una funcion para recuperar la contraseña de un usuario
        public bool RecuperarPassword([FromBody] UsuarioModel usuario)
        {
            //regresamos el metodo de recuperaropassword de la clase UsuarioDAO
            return usuarioDAO.RecuperarContraseña(usuario.CorreoInstitucional, usuario.FechaNacimiento);
        }
    }

}
