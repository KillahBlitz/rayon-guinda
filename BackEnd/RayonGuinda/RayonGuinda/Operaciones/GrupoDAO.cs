using RayonGuinda.Context;
using RayonGuinda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayonGuinda.Operaciones
{
    public class GrupoDAO
    {
        //Inicializamos el contexto donde trabajamos en la base de datos para realizar CRUD
        public RayonguindaContext Context = new RayonguindaContext();

        // Metodo para Crear un codigo unico del grupo que contendra 5 caracteres alfanumericos y comprobar que no exista en la base de datos
        public string CrearCodigoGrupo()
        {
            Random random = new Random();
            string codigoGrupo;
            do
            {
                // Generamos un codigo aleatorio de 5 caracteres alfanumericos
                codigoGrupo = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 5)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            } while (Context.Grupos.Any(g => g.ClaveAcceso == codigoGrupo)); // Comprobamos que no exista en la base de datos
            return codigoGrupo;
        }
    }
}
