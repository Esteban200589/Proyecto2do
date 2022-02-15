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
    internal class PersistenciaPronosticoHora : InterfazPersistenciaPronosticosHora
    {
        private static PersistenciaPronosticoHora instancia = null;
        private PersistenciaPronosticoHora() { }
        public static PersistenciaPronosticoHora GetInstanciaPronosticoHora()
        {
            if (instancia == null)
                instancia = new PersistenciaPronosticoHora();

            return instancia;
        }


        public void CrearPronosticoHora(Pronostico_hora ph, SqlTransaction trn)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("crear_pronostico_hora", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("hora", ph.Hora);
                cmd.Parameters.AddWithValue("temp_max", ph.Temp_max);
                cmd.Parameters.AddWithValue("temp_min", ph.Temp_min);
                cmd.Parameters.AddWithValue("v_viento", ph.V_viento);
                cmd.Parameters.AddWithValue("tipo_cielo", ph.Tipo_cielo);
                cmd.Parameters.AddWithValue("prob_lluvias", ph.Prob_lluvias);
                cmd.Parameters.AddWithValue("prob_tormenta", ph.Prob_tormenta);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);

                cmd.Transaction = trn;
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);
                // if (valor == -1) ERROR
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
    }
}
