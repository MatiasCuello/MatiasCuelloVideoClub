using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos;
using VideoClub.Entidades;

namespace VideoClub.Servicios
{
    public class ServicioProvincia
    {
        private ConexionBD conexion;
        private RepositorioProvincias repositorio;

        public ServicioProvincia()
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioProvincias(conexion.AbrirConexion());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public List<Provincia> GetLista()
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioProvincias(conexion.AbrirConexion());
                var lista = repositorio.GetLista();
                conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Agregar(Provincia provincia)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioProvincias(conexion.AbrirConexion());
                repositorio.Agregar(provincia);
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Provincia provincia)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioProvincias(conexion.AbrirConexion());
                var existe = repositorio.Existe(provincia);
                conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Borrar(Provincia provincia)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioProvincias(conexion.AbrirConexion());
                repositorio.Borrar(provincia);
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Provincia provincia)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioProvincias(conexion.AbrirConexion());
                repositorio.Guardar(provincia);
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Provincia provincia)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioProvincias(conexion.AbrirConexion());
                var relacionado = repositorio.EstaRelacionado(provincia);
                conexion.CerrarConexion();
                return relacionado;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
