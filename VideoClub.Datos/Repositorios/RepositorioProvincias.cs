using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Entidades;

namespace VideoClub.Datos
{
    public class RepositorioProvincias
    {
        private readonly SqlConnection cn;



        public RepositorioProvincias(SqlConnection cn)
        {
            this.cn = cn;
        }
        public List<Provincia> GetLista()
        {
            try
            {
                List<Provincia> lista = new List<Provincia>();
                string cadenaComando = "SELECT ProvinciaId, NombreProvincia FROM Provincias";
                SqlCommand comando = new SqlCommand(cadenaComando, cn);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var provincia = ConstruirProvincia(reader);
                    lista.Add(provincia);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Provincia ConstruirProvincia(SqlDataReader reader)
        {
            return new Provincia
            {
                ProvinciaId = reader.GetInt32(0),
                NombreProvincia = reader.GetString(1)
            };
        }

        public void Agregar(Provincia provincia)
        {
            try
            {
                string cadenaComando = "INSERT INTO Provincias VALUES (@nombre)";
                SqlCommand comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@nombre", provincia.NombreProvincia);
                comando.ExecuteNonQuery();
                cadenaComando = "SELECT @@IDENTITY";
                comando = new SqlCommand(cadenaComando, cn);
                int id = (int)(decimal)comando.ExecuteScalar();
                provincia.ProvinciaId = id;
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
                var cadenaComando = "SELECT ProvinciaId, NombreProvincia FROM Provincias WHERE NombreProvincia=@nombre";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@nombre", provincia.NombreProvincia);
                var reader = comando.ExecuteReader();
                return reader.HasRows;

            }

            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Provincia GetProvinciaPorId(int id)
        {
            try
            {
                Provincia provincia = null;
                string cadenaComando = "SELECT ProvinciaId, NombreProvincia FROM Provincias WHERE ProvinciaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    provincia = ConstruirProvincia(reader);
                }
                reader.Close();
                return provincia;
               
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
                var cadenaComando = "DELETE FROM Provincias WHERE ProvinciaId=@id";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Provincia provincia)
        {
            if (provincia.ProvinciaId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Provincias VALUES (@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@nombre", provincia.NombreProvincia);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, cn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    provincia.ProvinciaId = id;
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }

            }
            else
            {

                try
                {
                    string cadenaComando = "UPDATE Provincias SET NombreProvincia=@nombre WHERE ProvinciaId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@nombre", provincia.NombreProvincia);
                    comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
        }

        public bool EstaRelacionado(Provincia provincia)
        {
            try
            {
                var cadenaComando = "SELECT COUNT(*) FROM Socios WHERE ProvinciaId=@id";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
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
    }
}

