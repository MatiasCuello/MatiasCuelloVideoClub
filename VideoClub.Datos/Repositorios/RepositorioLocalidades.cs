using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Entidades;

namespace VideoClub.Datos.Repositorios
{
    public class RepositorioLocalidades
    {
        private readonly SqlConnection cn;
        private readonly RepositorioProvincias repositorioProvincias;
        private SqlConnection sqlConnection;

        public RepositorioLocalidades(SqlConnection _cn)
        {
            cn = _cn;
        }

        public RepositorioLocalidades(SqlConnection cn, RepositorioProvincias repositorioProvincias)
        {
            this.cn = cn;
            this.repositorioProvincias = repositorioProvincias;
        }

        public bool Existe(Localidad localidad)
        {
            try
            {
                SqlCommand comando = null;
                SqlDataReader reader = null;

                if (localidad.LocalidadId == 0)
                {
                    var cadenaComando = "SELECT LocalidadId, NombreLocalidad, ProvinciaId FROM Localidades WHERE NombreLocalidad=@nombre AND ProvinciaId=@provinciaid";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@nombre", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@provinciaid", localidad.Provincia.ProvinciaId);

                }
                else
                {
                    var cadenaComando = "SELECT LocalidadId, NombreLocalidad, ProvinciaId FROM Localidades WHERE NombreLocalidad=@nombre AND ProvinciaId=@provinciaid AND LocalidadId<>@id";
                    comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@nombre", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@provinciaid", localidad.Provincia.ProvinciaId);
                    comando.Parameters.AddWithValue("@id", localidad.LocalidadId);
                }

                reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public bool EstaRelacionado(Localidad localidad)
        {
            try
            {
                var cadenaComando = "SELECT COUNT(*) FROM Proveedores WHERE LocalidadId=@id";
                
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", localidad.LocalidadId);
                int cantidadRegistros = (int)comando.ExecuteScalar();
                if (cantidadRegistros > 0)
                {
                    return true;
                }
                return false;

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
                var cadenaComando = "DELETE FROM Localidades WHERE LocalidadId=@id";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", localidad.LocalidadId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Agregar(Localidad localidad)
        {
            try
            {
                string cadenaComando = "INSERT INTO Localidades VALUES (@nombre, @provinciaid)";
                SqlCommand comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@nombre", localidad.NombreLocalidad);
                comando.Parameters.AddWithValue("@provinciaid", localidad.Provincia.ProvinciaId);
                comando.ExecuteNonQuery();
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
                List<Localidad> lista = new List<Localidad>();
                var cadenaComando = "SELECT LocalidadId, NombreLocalidad, ProvinciaId FROM Localidades ORDER BY NombreLocalidad";
                var comando = new SqlCommand(cadenaComando, cn);
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var localidad = ConstruirLocalidad(reader);
                    lista.Add(localidad);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Localidad ConstruirLocalidad(SqlDataReader reader)
        {
            return new Localidad
            {
                LocalidadId = reader.GetInt32(0),
                NombreLocalidad = reader.GetString(1),
                Provincia =repositorioProvincias.GetProvinciaPorId(reader.GetInt32(2))
            };
        }
    }
}
