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


        public void CrearCiudad(Ciudad c)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

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

        public void ModificarCiudad(Ciudad c)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

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

        public void EliminarCiudad(Ciudad c)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

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


        public List<Ciudad> ListarPeriodistas()
        {
            List<Ciudad> lista = new List<Ciudad>();
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
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

        public List<Ciudad> ListarPeriodistasSinPronosticos()
        {
            List<Ciudad> lista = new List<Ciudad>();
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("listar_ciudades_sin", cnn);
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
    }
}
