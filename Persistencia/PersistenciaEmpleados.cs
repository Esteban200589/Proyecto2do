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
    internal class PersistenciaEmpleados : InterfazPersistenciaEmpleados
    {
        private static PersistenciaEmpleados instancia = null;
        private PersistenciaEmpleados() { }
        public static PersistenciaEmpleados GetInstanciaEmpleados()
        {
            if (instancia == null)
                instancia = new PersistenciaEmpleados();

            return instancia;
        }


        public void CrearEmpleado(Empleado e)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn());

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("crear_usuario_empleado", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("username", e.Username);
                cmd.Parameters.AddWithValue("nombre", e.Nombre);
                cmd.Parameters.AddWithValue("pass", e.Password);
                cmd.Parameters.AddWithValue("hrs", e.Carga_horaria);

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

        public void ModificarEmpleado(Empleado e)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn());

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("modificar_ususario_empleado", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("username", e.Username);
                cmd.Parameters.AddWithValue("nombre", e.Nombre);
                cmd.Parameters.AddWithValue("pass", e.Password);
                cmd.Parameters.AddWithValue("hrs", e.Carga_horaria);

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

        public void EliminarEmpleado(Empleado e)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn());

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("eliminar_ususario_empleado", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("username", e.Username);

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


        public Empleado LoginEmpleado(string username, string password)
        {
            Empleado user = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn());

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("logueo_empleado", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("user", username);
                cmd.Parameters.AddWithValue("pass", password);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    user = new Empleado(Convert.ToInt32(dr["carga_horaria"]), 
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

        public Empleado BuscarEmpleado(string username)
        {
            Empleado u = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn());
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("buscar_empleado", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("user", username);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    u = new Empleado(Convert.ToInt32(dr["carga_horaria"]), 
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
    }
}

