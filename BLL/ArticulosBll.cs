using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Parcial1_Maria.Entidades;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Parcial1_Maria.DAL;
using System.Linq.Expressions;

namespace Parcial1_Maria.BLL
{
    public class ArticulosBll
    {
        public static bool Guardar(Articulos articulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Articulos.Add(articulos) != null)
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

        public static bool Modificar(Articulos articulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(articulos).State = EntityState.Modified;
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
                var eliminar = contexto.Articulos.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;
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

        public static Articulos Buscar(int id)
        {
            Articulos articulos = new Articulos();
            Contexto contexto = new Contexto();
            try
            {
               articulos = contexto.Articulos.Find(id);
               
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return articulos;
        }

        public static List<Articulos> GetList(Expression<Func<Articulos,bool>> articulos)
        {
            List<Articulos> lista = new List<Articulos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Articulos.Where(articulos).ToList();
            }catch (Exception)
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
