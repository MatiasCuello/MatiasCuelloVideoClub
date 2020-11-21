using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos;
using VideoClub.Datos.Repositorios;
using VideoClub.Entidades;

namespace VideoClub.Servicios
{
    public class ServicioEstado
    {
        private ConexionBD conexion;
        private RepositorioEstados repositorio;

        public ServicioEstado()
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioEstados(conexion.AbrirConexion());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
       
        public List<Estado> GetLista()
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioEstados(conexion.AbrirConexion());
                var lista = repositorio.GetLista();
                conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Estado estado)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioEstados(conexion.AbrirConexion());
                var existe = repositorio.Existe(estado);
                conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Agregar(Estado estado)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioEstados(conexion.AbrirConexion());
                repositorio.Agregar(estado);
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Estado estado)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioEstados(conexion.AbrirConexion());
                var relacionado = repositorio.EstaRelacionado(estado);
                conexion.CerrarConexion();
                return relacionado;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Borrar(Estado estado)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioEstados(conexion.AbrirConexion());
                repositorio.Borrar(estado);
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Estado estado)
        {
            try
            {
                conexion = new ConexionBD();
                repositorio = new RepositorioEstados(conexion.AbrirConexion());
                repositorio.Guardar(estado);
                conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}

