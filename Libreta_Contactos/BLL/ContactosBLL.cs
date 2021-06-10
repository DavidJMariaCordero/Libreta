using Libreta_Contactos.DAL;
using Libreta_Contactos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libreta_Contactos.BLL
{
    public class ContactosBLL
    {
        public static bool Guardar(Contactos contacto)
        {
            if (!Existe(contacto.ContactoId))
                return Insertar(contacto);
            else
                return Modificar(contacto);
        }
        public static bool Insertar(Contactos contacto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Contactos.Add(contacto);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Contactos.Any(c => c.ContactoId == id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static bool Modificar(Contactos contacto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(contacto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool eliminado = false;
            Contexto contexto = new Contexto();

            try
            {
                var contacto = contexto.Contactos.Find(id);
                if (contacto != null)
                {
                    contexto.Contactos.Remove(contacto);
                    eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return eliminado;
        }

        public static Contactos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Contactos contacto;
            try
            {
                contacto = contexto.Contactos.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return contacto;
        }

        public static List<Contactos> GetList()
        {
            List<Contactos> lista = new List<Contactos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Contactos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;

        }
    }
}
