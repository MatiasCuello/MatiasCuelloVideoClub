using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos;
using VideoClub.Entidades;

namespace VideoClub.Servicios
{
    public class ServicioSoporte
    {
        private ConexionBD conexion;
        private RepositorioSoportes repositorio;

        public ServicioSoporte()
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioSoportes(conexion.AbrirConexion());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public List<Soporte> GetLista()
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioSoportes(conexion.AbrirConexion());
                var lista = repositorio.GetLista();
                conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public void Agregar(Soporte soporte)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioSoportes(conexion.AbrirConexion());
                repositorio.Agregar(soporte);
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Soporte soporte)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioSoportes(conexion.AbrirConexion());
                var existe = repositorio.Existe(soporte);
                conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Borrar(Soporte soporte)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioSoportes(conexion.AbrirConexion());
                repositorio.Borrar(soporte);
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Soporte soporte)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioSoportes(conexion.AbrirConexion());
                repositorio.Guardar(soporte);
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Soporte soporte)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioSoportes(conexion.AbrirConexion());
                var relacionado = repositorio.EstaRelacionado(soporte);
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
