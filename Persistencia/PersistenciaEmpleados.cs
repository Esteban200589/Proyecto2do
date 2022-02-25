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


        public Empleado LoginEmpleado(string username, string password)
        {
            Empleado user = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("logueo_empleado", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("user", username);
                cmd.Parameters.AddWithValue("pass", password);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    user = new Empleado(Convert.ToInt32(dr["carga_horaria"]), username, password, dr["nombre_completo"].ToString());
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
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("buscar_empleado", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("user", username);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    u = new Empleado(Convert.ToInt32(dr["carga_horaria"]), username, dr["password"].ToString(), dr["nombre_completo"].ToString());

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
