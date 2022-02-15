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
    internal class PersistenciaPronosticoTiempo
    {
        private static PersistenciaPronosticoTiempo instancia = null;
        private PersistenciaPronosticoTiempo() { }
        public static PersistenciaPronosticoTiempo GetInstanciaPronosticoTiempo()
        {
            if (instancia == null)
                instancia = new PersistenciaPronosticoTiempo();

            return instancia;
        }


        public void CrearPronosticoTiempo(Pronostico_tiempo pt)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

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
                    PersistenciaPronosticoHora.GetInstanciaPronosticoHora().CrearPronosticoHora(ph,trn);
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

        public List<Pronostico_tiempo> ListarPronosticosTodos()
        {
            List<Pronostico_tiempo> lista = new List<Pronostico_tiempo>();
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            List<Pronostico_hora> list_ph = new List<Pronostico_hora>();

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("listar_pronosticos", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                Pronostico_tiempo p = null;
                Ciudad city = null;
                Usuario user = null;

                while (dr.Read())
                {
                    city = PersistenciaCiudades.GetInstanciaCiudades().BuscarCiudad(dr["ciudad"].ToString());
                    user = PersistenciaMeteorologos.GetInstanciaMeteorologos().BuscarMeteorologo(dr["usuario"].ToString());

                    p = new Pronostico_tiempo(1, Convert.ToDateTime(dr["fecha"]), city, user, list_ph);
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

        public List<Pronostico_tiempo> ListarPronosticosAnio()
        {
            List<Pronostico_tiempo> lista = new List<Pronostico_tiempo>();
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            List<Pronostico_hora> list_ph = new List<Pronostico_hora>();

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("listar_pronosticos_anio", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                Pronostico_tiempo p = null;
                Ciudad city = null;
                Usuario user = null;

                while (dr.Read())
                {
                    city = PersistenciaCiudades.GetInstanciaCiudades().BuscarCiudad(dr["ciudad"].ToString());
                    user = PersistenciaMeteorologos.GetInstanciaMeteorologos().BuscarMeteorologo(dr["usuario"].ToString());

                    p = new Pronostico_tiempo(1, Convert.ToDateTime(dr["fecha"]), city, user, list_ph);
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
