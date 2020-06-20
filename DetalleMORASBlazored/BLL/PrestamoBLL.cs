using DetalleMORASBlazored.DAL;
using DetalleMORASBlazored.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DetalleMORASBlazored.BLL
{
    public class PrestamoBLL
    {
        public static bool Guardar(Prestamos prestamo)
        {
            if (!Existe(prestamo.PrestamoId))
                return Insertar(prestamo);
            else
                return Modificar(prestamo);

        }

        private static bool Insertar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Prestamos.Add(prestamo);
                //le sumamos el balance a la persona
                contexto.Personas.Find(prestamo.PersonaId).Balance += prestamo.Balance;
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


        private static bool Modificar(Prestamos prestamo)
        {
            bool paso = false;
            decimal BalanceAnterior = Buscar(prestamo.PrestamoId).Balance;
            int PersonaIdAnterior = Buscar(prestamo.PrestamoId).PersonaId;
            Contexto contexto = new Contexto();

            try
            {

                if (PersonaIdAnterior != prestamo.PersonaId)
                {
                    contexto.Personas.Find(PersonaIdAnterior).Balance -= BalanceAnterior;
                    contexto.Personas.Find(prestamo.PersonaId).Balance += prestamo.Balance;
                }
                else
                {
                    contexto.Personas.Find(prestamo.PersonaId).Balance -= BalanceAnterior;
                    contexto.Personas.Find(prestamo.PersonaId).Balance += prestamo.Balance;
                }

                contexto.Entry(prestamo).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var auxPrestamo = contexto.Prestamos.Find(id);
                if (auxPrestamo != null)
                {
                    contexto.Personas.Find(auxPrestamo.PersonaId).Balance -= auxPrestamo.Balance; 
                    contexto.Prestamos.Remove(auxPrestamo);
                    paso = contexto.SaveChanges() > 0;

                }
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

        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamo;

            try
            {
                prestamo = contexto.Prestamos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return prestamo;

        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> prestamo)
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Prestamos.Where(prestamo).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Prestamos.Any(p => p.PrestamoId == id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;

        }
    }
}
