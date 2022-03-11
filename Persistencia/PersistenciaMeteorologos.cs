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
    internal class PersistenciaMeteorologos : InterfazPersistenciaMeteorologos
    {
        private static PersistenciaMeteorologos instancia = null;
        private PersistenciaMeteorologos() { }
        public static PersistenciaMeteorologos GetInstanciaMeteorologos()
        {
            if (instancia == null)
                instancia = new PersistenciaMeteorologos();

            return instancia;
        }


        public void CrearMeteorologo(Meteorologo m, Usuario user_log)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("crear_usuario_meteorologo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("username", m.Username);
                cmd.Parameters.AddWithValue("nombre", m.Nombre);
                cmd.Parameters.AddWithValue("pass", m.Password);
                cmd.Parameters.AddWithValue("telefono", m.Telefono);
                cmd.Parameters.AddWithValue("correo", m.Correo);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("Ya existe ese Usuario.");
                if (valor == -2)
                    throw new Exception("Hubo un error de Permisos al querer crear el Usuario.");
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

        public void ModificarMeteorologo(Meteorologo m, Usuario user_log)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("modificar_usuario_meteorologo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("username", m.Username);
                cmd.Parameters.AddWithValue("nombre", m.Nombre);
                cmd.Parameters.AddWithValue("pass", m.Password);
                cmd.Parameters.AddWithValue("telefono", m.Telefono);
                cmd.Parameters.AddWithValue("correo", m.Correo);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("No existe el Usuario.");
                if (valor == -2)
                    throw new Exception("No existe el Empleado.");
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

        public void EliminarMeteorologo(Meteorologo m, Usuario user_log)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("eliminar_usuario_meteorologo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("username", m.Username);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("No existe el Usuario.");
                if (valor == -2)
                    throw new Exception("No existe el Meteorologo.");
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


        public Meteorologo LoginMeteorologo(string username, string password, Usuario user_log)
        {
            Meteorologo user = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("logueo_meteorologo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("user", username);
                cmd.Parameters.AddWithValue("pass", password);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    user = new Meteorologo(dr["telefono"].ToString(), dr["correo"].ToString(), 
                        username, password, dr["nombre_completo"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return user;
        }

        internal Meteorologo BuscarMeteorologo(string username, Usuario user_log)
        {
            Meteorologo u = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("buscar_meteorologo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("user", username);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    u = new Meteorologo(dr["telefono"].ToString(), dr["correo"].ToString(), 
                        username, dr["password"].ToString(), dr["nombre_completo"].ToString());

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
            return u;
        }

        public Meteorologo BuscarMeteorologoActivo(string username, Usuario user_log)
        {
            Meteorologo p = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("buscar_meteorologo_activo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("user", username);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    p = new Meteorologo(dr["telefono"].ToString(), dr["correo"].ToString(), 
                        username, dr["password"].ToString(), dr["nombre_completo"].ToString());
                
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
            return p;
        }
    }
}
