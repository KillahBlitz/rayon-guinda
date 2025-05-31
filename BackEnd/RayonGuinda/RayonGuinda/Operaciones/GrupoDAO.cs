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
                codigoGrupo = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 5).Select(s => s[random.Next(s.Length)]).ToArray());
            } while (Context.Grupos.Any(g => g.ClaveAcceso == codigoGrupo)); // Comprobamos que no exista en la base de datos
            return codigoGrupo;
        }

        //metodo para crear un grupo
        public bool CrearGrupo(int AdminID, string NombreGrupo, string ClaveAcceso)
        {
            try
            {
                //agregamos un nuevo grupo a la base de datos
                Context.Grupos.Add(new GrupoModel
                {
                    AdminID = AdminID,
                    NombreGrupo = NombreGrupo,
                    ClaveAcceso = ClaveAcceso,
                    NumIntegrantes = 1 // Inicializamos el numero de integrantes en 1
                });

                Context.SaveChanges();

                //buscamos al usuario en la base de datos
                UsuarioModel usuario = Context.Usuarios.FirstOrDefault(u => u.UserId == AdminID);
                //recuperamos el ID del grupo recien creado
                GrupoModel grupo = Context.Grupos.FirstOrDefault(g => g.ClaveAcceso == ClaveAcceso);


                //lo agregamos al grupo
                if (usuario != null)
                {
                    //agregamos al usuario al grupo en la tabla Usuario_Grupo por medio del ID del grupo y el ID del usuario
                    usuario.Grupos.Add(grupo);
                }
                else
                {
                    return false; // Si el usuario no existe, devolvemos false
                }

                //guardamos los cambios en la base de datos
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
