using RayonGuinda.Context;
using RayonGuinda.Models;
using RayonGuinda.Operaciones;


class Program
{
    static void Main(string[] args)
    {
        ConfirmarUsuario();
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
            DateOnly fechaNacimiento;
            while (!DateOnly.TryParse(Console.ReadLine(), out fechaNacimiento))
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


}
