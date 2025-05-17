using RayonGuinda.Context;
using RayonGuinda.Models;
using RayonGuinda.Operaciones;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Mail;


class Program
{
    static void Main(string[] args)
    {
        RecuperarPassword();
    }

    static void IngresarUsuario()
    {
        try
        {
            Console.WriteLine("=== Alta de Usuario ===");

            Console.Write("Nombres: ");
            string nombres = Console.ReadLine();

            Console.Write("Apellido Paterno: ");
            string apellidoPaterno = Console.ReadLine();

            Console.Write("Apellido Materno: ");
            string apellidoMaterno = Console.ReadLine();

            Console.Write("Num. Boleta: ");
            string numBoleta = Console.ReadLine();

            Console.Write("Fecha de Nacimiento (yyyy-MM-dd): ");
            DateTime fechaNacimiento;
            while (!DateTime.TryParse(Console.ReadLine(), out fechaNacimiento))
            {
                Console.Write("Formato inválido. Intenta de nuevo (yyyy-MM-dd): ");
            }

            Console.Write("Correo Institucional: ");
            string correo = Console.ReadLine();

            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine();

            var usuario = new UsuarioModel
            {
                Nombres = nombres,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = apellidoMaterno,
                NumBoleta = numBoleta,
                FechaNacimiento = fechaNacimiento,
                CorreoInstitucional = correo,
                Contraseña = contrasena
            };

            using var context = new RayonguindaContext();
            context.Usuarios.Add(usuario);
            context.SaveChanges();

            Console.WriteLine("Usuario guardado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    static void ConfirmarUsuario()
    {
        try
        {
            Console.WriteLine("=== Confirmar Usuario ===");
            Console.Write("Correo Electronico: ");
            string correo = Console.ReadLine();
            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine();
            bool esValido = false;
            using var context = new RayonguindaContext();
            var usuario = context.Usuarios.FirstOrDefault(u => u.CorreoInstitucional == correo);
            
            if (usuario.Contraseña == contrasena)
            {
                esValido = true;
            }
            else
            {
                esValido = false;
            }
            
            if (usuario != null && esValido== true)
            {
                Console.WriteLine($"Usuario encontrado: {usuario.Nombres} {usuario.ApellidoPaterno} {usuario.ApellidoMaterno}");
            }
            else
            {
                Console.WriteLine("Credenciales Incorrectas");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    // Diccionario estático para almacenar tokens temporales
    private static ConcurrentDictionary<string, (DateTime Expira, bool Usado)> tokens = new();
    static void RecuperarPassword()
    {
        try
        {
            Console.WriteLine("=== Recuperar Contraseña ===");
            Console.Write("Correo Electronico: ");
            string correo = Console.ReadLine();
            Console.Write("Fecha de Nacimiento (yyyy-MM-dd): ");
            DateTime fecha;
            while (!DateTime.TryParse(Console.ReadLine(), out fecha))
            {
                Console.Write("Formato inválido. Intenta de nuevo (yyyy-MM-dd): ");
            }

            try
            {
                //buscamos el usuario en la base de datos
                using var context = new RayonguindaContext();
                var usuario = context.Usuarios.FirstOrDefault(u => u.CorreoInstitucional == correo);
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
                        Console.WriteLine("Todo ha salido con exito");
                    }
                    else
                    {
                        //si la fecha no es correcta devolvemos false
                        Console.WriteLine("Fecha de nacimiento Incorrecta");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
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

    public static void EnviarCorreo(string destinatario, string enlace)
    {
        var fromAddress = new MailAddress("jmonroyc2100@alumno.ipn.mx", "Rayon Guinda");
        var toAddress = new MailAddress(destinatario);
        const string fromPassword = "DE0021AEAD1A5F4B842ABC984FA8BEFC5713";
        const string subject = "Recuperación de contraseña";
        string body = $"Haz clic en el siguiente enlace para continuar (válido por 15 minutos): {enlace}";

        var smtp = new SmtpClient
        {
            Host = "smtp.elasticemail.com",
            Port = 2525,
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
