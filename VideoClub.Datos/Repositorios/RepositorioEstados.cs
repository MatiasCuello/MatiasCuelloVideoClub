using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Entidades;

namespace VideoClub.Datos.Repositorios
{
    public class RepositorioEstados
    {
        private readonly SqlConnection cn;
        public RepositorioEstados(SqlConnection cn)
        {
            this.cn = cn;
        }


        public List<Estado> GetLista()
        {
            try
            {
                List<Estado> lista = new List<Estado>();
                string cadenaComando = "SELECT EstadoId, Descripcion FROM Estados";
                SqlCommand comando = new SqlCommand(cadenaComando, cn);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var estado = ConstruirEstado(reader);
                    lista.Add(estado);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Estado ConstruirEstado(SqlDataReader reader)
        {
            return new Estado
            {
                EstadoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

        public bool Existe(Estado estado)
        {
            try
            {
                var cadenaComando = "SELECT Estadoid, Descripcion FROM Estados WHERE Descripcion=@descripcion";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@descripcion", estado.Descripcion);
                var reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Agregar(Estado estado)
        {
            string cadenaComando = "INSERT INTO Estados VALUES (@descripcion)";
            SqlCommand comando = new SqlCommand(cadenaComando, cn);
            comando.Parameters.AddWithValue("@descripcion", estado.Descripcion);
            comando.ExecuteNonQuery();
            cadenaComando = "SELECT @@IDENTITY";
            comando = new SqlCommand(cadenaComando, cn);
            int id = (int)(decimal)comando.ExecuteScalar();
            estado.EstadoId = id;
        }

        public bool EstaRelacionado(Estado estado)
        {
            try
            {
                var cadenaComando = "SELECT COUNT(*) FROM Peliculas WHERE EstadoId=@id";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", estado.EstadoId);
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

        public void Borrar(Estado estado)
        {
            try
            {
                var cadenaComando = "DELETE FROM Estados WHERE EstadoId=@id";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", estado.EstadoId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Estado estado)
        {
            if (estado.EstadoId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Estados VALUES (@descripcion)";
                    SqlCommand comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@descripcion", estado.Descripcion);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, cn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    estado.EstadoId = id;
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
                    string cadenaComando = "UPDATE Estados SET Descripcion=@descripcion WHERE EstadoId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@descripcion", estado.Descripcion);
                    comando.Parameters.AddWithValue("@id", estado.EstadoId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
        }
    }
}
