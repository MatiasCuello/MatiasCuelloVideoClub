using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Datos;
using VideoClub.Datos.Repositorios;
using VideoClub.Entidades;

namespace VideoClub.Servicios
{
    public class ServicioLocalidad
    {
        private ConexionBD cn;
        private RepositorioLocalidades repositorio;
        private RepositorioProvincias repositorioProvincias;

        public ServicioLocalidad()
        {

        }
        public void Agregar(Localidad localidad)
        {
            try
            {
                cn = new ConexionBD();
                repositorio = new RepositorioLocalidades(cn.AbrirConexion());
                repositorio.Agregar(localidad);
                cn.CerrarConexion();


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public List<Localidad> GetLocalidades()
        {
            try
            {
                cn = new ConexionBD();
                repositorioProvincias = new RepositorioProvincias(cn.AbrirConexion());
                repositorio = new RepositorioLocalidades(cn.AbrirConexion(),repositorioProvincias);
                var lista = repositorio.GetLocalidades();
                cn.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Localidad localidad)
        {
            try
            {
                cn = new ConexionBD();
                repositorio = new RepositorioLocalidades(cn.AbrirConexion());
                var existe = repositorio.Existe(localidad);
                cn.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool EstaRelacionado(Localidad localidad)
        {
            try
            {
                cn = new ConexionBD();
                repositorio = new RepositorioLocalidades(cn.AbrirConexion());
                var relacionado = repositorio.EstaRelacionado(localidad);
                cn.CerrarConexion();
                return relacionado;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Borrar(Localidad localidad)
        {
            try
            {
                cn = new ConexionBD();
                repositorio = new RepositorioLocalidades(cn.AbrirConexion());
                repositorio.Borrar(localidad);
                cn.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
