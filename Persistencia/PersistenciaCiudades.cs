using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaCiudades : InterfazPersistenciaCiudades
    {
        private static PersistenciaCiudades instancia = null;
        private PersistenciaCiudades() { }
        public static PersistenciaCiudades GetInstanciaCiudades()
        {
            if (instancia == null)
                instancia = new PersistenciaCiudades();

            return instancia;
        }


        public void CrearCiudad(Ciudad c, Usuario user_log)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("crear_ciudad", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigo", c.Codigo);
                cmd.Parameters.AddWithValue("nombre_ciudad", c.Nombre_ciudad);
                cmd.Parameters.AddWithValue("pais", c.Pais);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("La Ciudad ya existe.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }

        public void ModificarCiudad(Ciudad c, Usuario user_log)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("modificar_ciudad", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigo", c.Codigo);
                cmd.Parameters.AddWithValue("nombre_ciudad", c.Nombre_ciudad);
                cmd.Parameters.AddWithValue("pais", c.Pais);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("La Ciudad no existe.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }

        }

        public void EliminarCiudad(Ciudad c, Usuario user_log)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("eliminar_ciudad", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigo", c.Codigo);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("La Ciudad no existe.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }


        internal Ciudad BuscarCiudad(string codigo, Usuario user_log)
        {
            Ciudad c = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("buscar_ciudad", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("code", codigo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    c = new Ciudad(dr["codigo"].ToString(), dr["nombre_ciudad"].ToString(), dr["pais"].ToString());

                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return c;
        }

        public Ciudad BuscarCiudadActiva(string codigo, Usuario user_log)
        {
            Ciudad c = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("buscar_ciudad_activa", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("code", codigo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    c = new Ciudad(dr["codigo"].ToString(), dr["nombre_ciudad"].ToString(), dr["pais"].ToString());

                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return c;
        }


        public List<Ciudad> ListarCiudades(Usuario user_log)
        {
            List<Ciudad> lista = new List<Ciudad>();
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));

            try
            {
                string sts = cnn.State.ToString();
                cnn.Open();

                SqlCommand cmd = new SqlCommand("listar_ciudades", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                Ciudad p = null;

                while (dr.Read())
                {
                    p = new Ciudad(dr["codigo"].ToString(), dr["nombre_ciudad"].ToString(), dr["pais"].ToString());
                    lista.Add(p);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }

            return lista;
        }

        public List<Ciudad> ListarCiudadesSinPronosticos(Usuario user_log, int anio)
        {
            List<Ciudad> lista = new List<Ciudad>();
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("listar_ciudades_sin", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("anio", anio);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("Solo puede digitar hasta 4 cifras máximo.");

                SqlDataReader dr = cmd.ExecuteReader();

                Ciudad p = null;

                while (dr.Read())
                {
                    p = new Ciudad(dr["codigo"].ToString(), dr["nombre_ciudad"].ToString(), dr["pais"].ToString());
                    lista.Add(p);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }

            return lista;
        }
    }
}
