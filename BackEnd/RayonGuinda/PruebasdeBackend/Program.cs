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
        ConsultarDatos();
        ModificarUsuario();
    }
    static void AltaUsuario()
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
            Console.WriteLine("=== Confirma tu identidad ===");
            Console.Write("Ingresa tu contraseña: ");
            string contrasena = Console.ReadLine();
            bool esValido = false;
            using var context = new RayonguindaContext();
            var usuario = context.Usuarios.FirstOrDefault();

            if (usuario != null && usuario.Contraseña == contrasena)
            {
                esValido = true;
            }

            if (usuario != null && esValido == true)
            {
                Console.WriteLine($"Perfil {usuario.Nombres} {usuario.ApellidoPaterno} {usuario.ApellidoMaterno}");
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

    static void ConsultarDatos()
    {
        try
        {
            Console.WriteLine("=== Perfil ===");

            //Busca al usuario con su contraseña y correo institucional
            Console.Write("Correo Institucional: ");
            string correo = Console.ReadLine();

            using var context = new RayonguindaContext();
            var usuario = context.Usuarios.FirstOrDefault(u => u.CorreoInstitucional == correo);

            if (usuario.CorreoInstitucional != correo)
            {
                Console.WriteLine("Usuario no encontrado"); }
            else {
                Console.WriteLine("=== Perfil ===");
                Console.WriteLine(usuario.CorreoInstitucional);
                Console.WriteLine();
                //Muestra los datos actualmente almacenados
                Console.WriteLine("Nombre: " + usuario.Nombres);
                Console.WriteLine("Apellido paterno: " + usuario.ApellidoPaterno);
                Console.WriteLine("Apellido materno: " + usuario.ApellidoMaterno);
                Console.WriteLine("Numero de Boleta: " +  usuario.NumBoleta);
                Console.WriteLine("Fecha de nacimiento: " + usuario.FechaNacimiento);

            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al mostrar usuario: {e.Message}");
        }
    }

    static void ModificarUsuario()
    {

        try
        {
            Console.WriteLine("=== Modificar Usuario ===");

            // Primero confirmar la identidad del usuario
            Console.Write("Correo Electrónico: ");
            string correo = Console.ReadLine();
            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine();

            using var context = new RayonguindaContext();
            var usuario = context.Usuarios.FirstOrDefault(u => u.CorreoInstitucional == correo);

            if (usuario == null || usuario.Contraseña != contrasena)
            {
                Console.WriteLine("Credenciales Incorrectas");
                return;
            }

            Console.WriteLine($"Perfil");

            // Mostrar datos actuales y permitir modificaciones
            //si los datos quedan vacios, estos permaneceran como estan
            Console.WriteLine($"Nombre actual: {usuario.Nombres}");
            Console.Write("Nuevo nombre: ");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                usuario.Nombres = nuevoNombre;
            }

            Console.WriteLine($"Apellido Paterno actual: {usuario.ApellidoPaterno}");
            Console.Write("Nuevo apellido paterno: ");
            string nuevoApellidoP = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoApellidoP))
            {
                usuario.ApellidoPaterno = nuevoApellidoP;
            }

            Console.WriteLine($"Apellido Materno actual: {usuario.ApellidoMaterno}");
            Console.Write("Nuevo apellido materno: ");
            string nuevoApellidoM = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoApellidoM))
            {
                usuario.ApellidoMaterno = nuevoApellidoM;
            }

            Console.WriteLine($"Fecha de nacimiento actual: {usuario.FechaNacimiento:yyyy-MM-dd}");
            Console.Write("Nueva fecha de nacimiento (yyyy-MM-dd) (dejar vacío para mantener): ");
            string nuevaFechaStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaFechaStr) && DateTime.TryParse(nuevaFechaStr, out DateTime nuevaFecha))
            {
                usuario.FechaNacimiento = nuevaFecha;
            }

            Console.WriteLine($"Número de boleta actual: {usuario.NumBoleta}");
            Console.Write("Nuevo número de boleta: ");
            string nuevaBoleta = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaBoleta))
            {
                usuario.NumBoleta = nuevaBoleta;
            }


            context.SaveChanges();
            Console.WriteLine("Usuario modificado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al modificar usuario: {e.Message}");
        }
    }
}
