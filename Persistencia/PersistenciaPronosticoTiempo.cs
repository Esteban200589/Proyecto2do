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


        public void CrearPronosticoTiempo(Pronostico_tiempo prono)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand cmd = new SqlCommand("crear_pronostico_tiempo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("fecha", prono.Fecha);
            cmd.Parameters.AddWithValue("ciudad", prono.);
            cmd.Parameters.AddWithValue("cuerpo", prono.Cuerpo);

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
                    throw new Exception("La Noticia ya existe.");
                if (valor == -2)
                    throw new Exception("El usuario no existe.");

                foreach (Periodista p in n.Periodistas)
                {
                    PersistenciaEscriben.GetInstanciaEscriben().AgregarEscriben(n.Codigo, p, trn);
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

    }
}
