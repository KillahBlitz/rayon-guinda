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
    }
}
