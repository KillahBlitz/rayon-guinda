using RayonGuinda.Context;
using RayonGuinda.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;



namespace RayonGuinda.Operaciones
{

    public class UsuarioDAO
    {
        //inicializamos el contexto donde trabajamos en la base de datos para realizar CRUD
        public RayonguindaContext Context = new RayonguindaContext();

        //metodo para registrar un usuario en la base de datos
        public bool Registrarse(string Apatern, string Amatern, string Nombre, DateTime FechaNac, string Correo, string Password)
        {
            try
            {
                //Aqui se crea el objeto usuario y se le asignan los valores que se le pasan por parametro
                UsuarioModel usuario = new UsuarioModel();

                //se asignan los valores a las propiedades del objeto usuario
                usuario.ApellidoPaterno = Apatern;
                usuario.ApellidoMaterno = Amatern;
                usuario.Nombres = Nombre;
                usuario.FechaNacimiento = FechaNac;
                usuario.CorreoInstitucional = Correo;
                usuario.Contraseña = Password;
                usuario.NumBoleta = "";

                //se agrega el objeto usuario a la base de datos y se guardan los cambios
                Context.Usuarios.Add(usuario);
                Context.SaveChanges();

                //devolvemos que todo salio bien
                return true;
            }
            catch (Exception e)
            {
                //si hubo un error se imprime el error en la consola y se devuelve false
                Console.WriteLine(e);
                return false;
            }
        }

        //metodo para ver si el usuario existe en la base de datos y si ingreso una contraseña correcta
        public bool Logearse(string correo, string contrasena)
        {
            try
            {
                //buscamos el usuario en la base de datos
                UsuarioModel usuario = Context.Usuarios.FirstOrDefault(u => u.CorreoInstitucional == correo);
                //si el usuario no existe devolvemos false
                if (usuario == null)
                {
                    return false;
                }
                //si la contraseña es correcta devolvemos true
                if (usuario.Contraseña == contrasena)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //metodo para devolver el id del usuario cuando inicia sesion
        public int ObtenerIdUsuario(string correo)
        {
            try
            {
                //buscamos el usuario en la base de datos
                UsuarioModel usuario = Context.Usuarios.FirstOrDefault(u => u.CorreoInstitucional == correo);
                //si el usuario no existe devolvemos 0
                if (usuario == null)
                {
                    return 0;
                }
                //si el usuario existe devolvemos su id
                return usuario.UserId;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        //consultar los datos del usuario por id
        public UserAux ConsultarUsuario(int id)
        {
            try
            {
                //buscamos el usuario en la base de datos
                UsuarioModel usuario = Context.Usuarios.FirstOrDefault(u => u.UserId == id);
                //si el usuario no existe devolvemos null
                if (usuario == null)
                {
                    return null;
                }
                //solo devolver correo, apellido paterno, apellido materno, nombres, fechanacimiento y boleta
                var user = new UserAux
                {
                    CorreoInstitucional = usuario.CorreoInstitucional,
                    ApellidoPaterno = usuario.ApellidoPaterno,
                    ApellidoMaterno = usuario.ApellidoMaterno,
                    Nombres = usuario.Nombres,
                    FechaNacimiento = DateOnly.FromDateTime(usuario.FechaNacimiento),
                    NumBoleta = usuario.NumBoleta,
                    password = usuario.Contraseña
                };
                //si el usuario existe devolvemos al usuario
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //metodo para recuperar los grupos de un usuario por id del usuario
        public List<string> GruposUsuario(int id)
        {
            try
            {
                //buscamos al usuario en la base de datos
                UsuarioModel usuario = Context.Usuarios.FirstOrDefault(u => u.UserId == id);
                //si el usuario no existe devolvemos null
                if (usuario == null)
                {
                    return null;
                }
                //si el usuario existe devolvemos la lista de grupos a los que pertenece
                var grupos = Context.Grupos.Where(g => g.Users.Contains(usuario)).Select(g => g.NombreGrupo).ToList();
                //si el usuario no pertenece a ningun grupo devolvemos null
                if (grupos.Count == 0)
                {
                    return null;
                }
                //devolvemos la lista de grupos
                return grupos;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

    //clase auxiliar que solo manda lo que se pide de un usuario
    public class UserAux
    {
        public string CorreoInstitucional { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string NumBoleta { get; set; }
        public string password { get; set; }
    }

}
