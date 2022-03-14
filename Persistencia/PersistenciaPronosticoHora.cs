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


        public void CrearPronosticoHora(Pronostico_hora ph, SqlTransaction trn, Usuario user_log)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn());

            try
            {
                SqlCommand cmd = new SqlCommand("crear_pronostico_hora", trn.Connection);
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

        public List<Pronostico_hora> ListarPronosticosHora(int interno, SqlTransaction trn, Usuario user_log)
        {
            List<Pronostico_hora> lista = new List<Pronostico_hora>();
            SqlConnection cnn = new SqlConnection(Conexion.Cnn());

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("listar_pronosticos_hora", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("interno", interno);
                //SqlDataReader dr = cmd.ExecuteReader();

                cmd.Transaction = trn;
                SqlDataReader dr = cmd.ExecuteReader();

                Pronostico_hora p = null;

                while (dr.Read())
                {
                    p = new Pronostico_hora(Convert.ToInt32(dr["hora"]),
                                            Convert.ToInt32(dr["temp_max"]),
                                            Convert.ToInt32(dr["temp_min"]),
                                            Convert.ToInt32(dr["v_viento"]),
                                            Convert.ToInt32(dr["prob_lluvias"]),
                                            Convert.ToInt32(dr["prob_tormenta"]),
                                            dr["tipo_cielo"].ToString());
                    lista.Add(p);
                }
                //dr.Close();
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
