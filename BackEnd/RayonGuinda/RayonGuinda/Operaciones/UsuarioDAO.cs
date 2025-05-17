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

        // Diccionario estático para almacenar tokens temporales
        private static ConcurrentDictionary<string, (DateTime Expira, bool Usado)> tokens = new();
        public bool RecuperarContraseña(string correo, DateTime fecha)
        {
            try
            {
                //buscamos el usuario en la base de datos
                UsuarioModel usuario = Context.Usuarios.FirstOrDefault(u => u.CorreoInstitucional == correo);
                //encontrando el usuario, se verifica que la fecha de nacimiento sea correcta
                {
                    if (usuario != null && usuario.FechaNacimiento.Date == fecha.Date)
                    {
                        // Generar token único
                        string token = Guid.NewGuid().ToString();
                        DateTime expira = DateTime.UtcNow.AddMinutes(15);
                        tokens[token] = (expira, false);

                        // Construir enlace temporal
                        string enlace = $"https://www.google.com/?token={token}";

                        // Enviar correo
                        EnviarCorreo(usuario.CorreoInstitucional, enlace);

                        //si la fecha es correcta devolvemos true
                        return true;
                    }
                    else
                    {
                        //si la fecha no es correcta devolvemos false
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // Método para validar el token (puedes llamarlo desde un endpoint)
        public static bool ValidarToken(string token)
        {
            if (tokens.TryGetValue(token, out var info))
            {
                if (!info.Usado && DateTime.UtcNow <= info.Expira)
                {
                    // Marcar como usado
                    tokens[token] = (info.Expira, true);
                    return true;
                }
                else
                {
                    // Token expirado o ya usado
                    tokens[token] = (info.Expira, false);
                    return false;
                }
            }
            return false;
        }

        private void EnviarCorreo(string destinatario, string enlace)
        {
            var fromAddress = new MailAddress("jmonroyc2100@gmail.com", "Rayon Guinda");
            var toAddress = new MailAddress(destinatario);
            const string fromPassword = "olakase2";
            const string subject = "Recuperación de contraseña";
            string body = $"Haz clic en el siguiente enlace para continuar (válido por 15 minutos): {enlace}";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
