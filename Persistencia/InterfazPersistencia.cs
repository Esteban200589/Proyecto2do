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
    public interface InterfazPersistenciaCiudades
    {
        void CrearCiudad(Ciudad c, Usuario user_log);
        void ModificarCiudad(Ciudad c, Usuario user_log);
        void EliminarCiudad(Ciudad c, Usuario user_log);

        Ciudad BuscarCiudadActiva(string codigo, Usuario user_log);

        List<Ciudad> ListarCiudades(Usuario user_log);
        List<Ciudad> ListarCiudadesSinPronosticos(Usuario user_log, int anio);
    }

    public interface InterfazPersistenciaEmpleados
    {
        void CrearEmpleado(Empleado e, Usuario user_log);
        void ModificarEmpleado(Empleado e, Usuario user_log);
        void EliminarEmpleado(Empleado e, Usuario user_log);

        Empleado LoginEmpleado(string username, string password, Usuario user_log);
        Empleado BuscarEmpleado(string username, Usuario user_log);
    }
    public interface InterfazPersistenciaMeteorologos
    {
        void CrearMeteorologo(Meteorologo m, Usuario user_log);
        void ModificarMeteorologo(Meteorologo m, Usuario user_log);
        void EliminarMeteorologo(Meteorologo m, Usuario user_log);

        Meteorologo LoginMeteorologo(string username, string password, Usuario user_log);
        Meteorologo BuscarMeteorologoActivo(string username, Usuario user_log);

        List<Meteorologo> ListarMeteorologosSinPronosticos(Usuario user_log, int anio);
    }

    public interface InterfazPersistenciaPronosticosTiempo
    {
        void CrearPronosticoTiempo(Pronostico_tiempo pt, Usuario user_log);

        List<Pronostico_tiempo> ListarPronosticosFecha(DateTime fecha, Usuario user_log);
        List<Pronostico_tiempo> ListarPronosticosAnioActual(Usuario user_log);
    }

    public interface InterfazPersistenciaPronosticosHora
    {
        void CrearPronosticoHora(int interno, Pronostico_hora ph, SqlTransaction trn, Usuario user_log);

        List<Pronostico_hora> ListarPronosticosHora(int interno, SqlTransaction trn, Usuario user_log);
    }
}
