using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Entidades;

namespace VideoClub.Datos
{
    public class RepositorioSoportes
    {
        private readonly SqlConnection cn;
        public RepositorioSoportes(SqlConnection cn)
        {
            this.cn = cn;
        }
        public bool EstaRelacionado(Soporte soporte)
        {
            try
            {
                var cadenaComando = "SELECT COUNT(*) FROM Peliculas WHERE SoporteId=@id";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", soporte.SoporteId);
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
        public List<Soporte> GetLista()
        {
            try
            {
                List<Soporte> lista = new List<Soporte>();
                string cadenaComando = "SELECT SoporteId, Descripcion FROM Soportes";
                SqlCommand comando = new SqlCommand(cadenaComando, cn);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var soporte = ConstruirSoporte(reader);
                    lista.Add(soporte);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Soporte ConstruirSoporte(SqlDataReader reader)
        {
            return new Soporte
            {
                SoporteId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

        public void Agregar(Soporte soporte)
        {
            string cadenaComando = "INSERT INTO Soportes VALUES (@descripcion)";
            SqlCommand comando = new SqlCommand(cadenaComando, cn);
            comando.Parameters.AddWithValue("@descripcion", soporte.Descripcion);
            comando.ExecuteNonQuery();
            cadenaComando = "SELECT @@IDENTITY";
            comando = new SqlCommand(cadenaComando, cn);
            int id = (int)(decimal)comando.ExecuteScalar();
            soporte.SoporteId = id;
        }

        public bool Existe(Soporte soporte)
        {
            try
            {
                var cadenaComando = "SELECT SoporteId, Descripcion FROM Soportes WHERE Descripcion=@descripcion";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@descripcion", soporte.Descripcion);
                var reader = comando.ExecuteReader();
                return reader.HasRows;
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
                var cadenaComando = "DELETE FROM Soportes WHERE SoporteId=@id";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", soporte.SoporteId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Soporte soporte)
        {
            if (soporte.SoporteId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Soportes VALUES (@descripcion)";
                    SqlCommand comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@descripcion", soporte.Descripcion);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, cn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    soporte.SoporteId = id;
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
                    string cadenaComando = "UPDATE Soportes SET Descripcion=@descripcion WHERE SoporteId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@descripcion", soporte.Descripcion);
                    comando.Parameters.AddWithValue("@id", soporte.SoporteId);
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
