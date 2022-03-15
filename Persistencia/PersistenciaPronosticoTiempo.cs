using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace Persistencia
{
    internal class PersistenciaPronosticoTiempo : InterfazPersistenciaPronosticosTiempo
    {
        private static PersistenciaPronosticoTiempo instancia = null;
        private PersistenciaPronosticoTiempo() { }
        public static PersistenciaPronosticoTiempo GetInstanciaPronosticoTiempo()
        {
            if (instancia == null)
                instancia = new PersistenciaPronosticoTiempo();

            return instancia;
        }


        public void CrearPronosticoTiempo(Pronostico_tiempo pt, Usuario user_log)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));

            SqlCommand cmd = new SqlCommand("crear_pronostico_tiempo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("fecha", pt.Fecha);
            cmd.Parameters.AddWithValue("ciudad", pt.Ciudad.Codigo);
            cmd.Parameters.AddWithValue("usuario", pt.Usuario.Username);

            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(ret);

            SqlTransaction trn = null;

            try
            {
                cnn.Open();

                trn = cnn.BeginTransaction();
                cmd.Transaction = trn;
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("El Usuario no existe.");
                if (valor == -2)
                    throw new Exception("La Ciudad no existe.");

                foreach (Pronostico_hora ph in pt.LIST_pronosticos_hora)
                {
                    PersistenciaPronosticoHora.GetInstanciaPronosticoHora().CrearPronosticoHora(valor,ph, trn, user_log);
                }

                trn.Commit();
            }
            catch (Exception ex)
            {
                trn.Rollback();
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }

        public List<Pronostico_tiempo> ListarPronosticosFecha(DateTime fecha, Usuario user_log)
        {
            List<Pronostico_tiempo> lista = new List<Pronostico_tiempo>();
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));

            List<Pronostico_hora> list_ph = new List<Pronostico_hora>();
            //IFormatProvider formato = new CultureInfo("en-US", true);

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("listar_pronosticos_fecha", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("fecha", fecha);
                SqlDataReader dr = cmd.ExecuteReader();

                SqlTransaction trn = null;
                Pronostico_tiempo p = null;
                Ciudad city = null;
                Usuario user = null;

                while (dr.Read())
                {
                    list_ph = PersistenciaPronosticoHora.GetInstanciaPronosticoHora().ListarPronosticosHora(Convert.ToInt32(dr["interno"]),trn, user_log);
                    city = PersistenciaCiudades.GetInstanciaCiudades().BuscarCiudad(dr["ciudad"].ToString(), user_log);
                    user = PersistenciaMeteorologos.GetInstanciaMeteorologos().BuscarMeteorologo(dr["usuario"].ToString(), user_log);
                    p = new Pronostico_tiempo(Convert.ToInt32(dr["interno"]), Convert.ToDateTime(dr["fecha"]), city, user, list_ph);
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

        public List<Pronostico_tiempo> ListarPronosticosAnioActual(Usuario user_log)
        {
            List<Pronostico_tiempo> lista = new List<Pronostico_tiempo>();
            SqlConnection cnn = new SqlConnection(Conexion.Cnn(user_log));

            List<Pronostico_hora> list_ph = new List<Pronostico_hora>();

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("listar_pronosticos_anio", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                SqlTransaction trn = null;
                Pronostico_tiempo p = null;
                Ciudad city = null;
                Usuario user = null;

                while (dr.Read())
                {
                    list_ph = PersistenciaPronosticoHora.GetInstanciaPronosticoHora().ListarPronosticosHora(Convert.ToInt32(dr["interno"]),trn, user_log);
                    city = PersistenciaCiudades.GetInstanciaCiudades().BuscarCiudad(dr["ciudad"].ToString(), user_log);
                    user = PersistenciaMeteorologos.GetInstanciaMeteorologos().BuscarMeteorologo(dr["usuario"].ToString(), user_log);
                    p = new Pronostico_tiempo(Convert.ToInt32(dr["interno"]), Convert.ToDateTime(dr["fecha"]), city, user, list_ph);
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


        #region other

        //public Pronostico_tiempo CargarPronostico()
        //{
        //    Pronostico_tiempo pt = null;
        //    SqlConnection cnn = new SqlConnection(Conexion.Cnn);
        //    try
        //    {
        //        cnn.Open();
        //        //SqlCommand cmd = new SqlCommand("sp_MostrarEntregaPorPaquete", cnn);
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        //cmd.Parameters.AddWithValue("paquete", paquete.Numero);
        //        //cmd.Parameters.AddWithValue("empresa", paquete.Empresa.Rut);
        //        //SqlDataReader dr = cmd.ExecuteReader();
        //        //if (dr.Read())
        //        //{
        //        //    Usuario user = new perUsuario().BuscarUsuario(dr["usuario"].ToString());
        //        //    sol = new Pronostico_tiempo(Convert.ToInt32(dr["interno"]),
        //        //                                Convert.ToDateTime(dr["fecha"]),
        //        //                                dr[" "].ToString(),
        //        //                                dr[" "].ToString(),
        //        //                                dr[" "].ToString(),);
        //        //}
        //        //dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        cnn.Close();
        //    }
        //    return pt;
        //}

        #endregion
    }
}
