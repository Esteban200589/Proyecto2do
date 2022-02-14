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
    internal class PersistenciaMeteorologos
    {
        private static PersistenciaMeteorologos instancia = null;
        private PersistenciaMeteorologos() { }
        public static PersistenciaMeteorologos GetInstanciaMeteorologos()
        {
            if (instancia == null)
                instancia = new PersistenciaMeteorologos();

            return instancia;
        }


        public Meteorologo LoginMeteorologo(string username, string password)
        {
            Meteorologo user = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("logueo_empleado", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("user", username);
                cmd.Parameters.AddWithValue("pass", password);

                SqlDataReader dr = cmd.ExecuteReader();
                //string pTel, string pCo, string pUser, string pPass, string pName
                if (dr.Read())
                    user = new Meteorologo(dr["telefono"].ToString(), dr["correo"].ToString(), username, password, dr["nombre"].ToString());
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

        public Meteorologo BuscarMeteorologo(string username)
        {
            Meteorologo u = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("buscar_usuario", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("user", username);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    u = new Meteorologo(dr["telefono"].ToString(), dr["correo"].ToString(), username, dr["password"].ToString(), dr["nombre"].ToString());

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
