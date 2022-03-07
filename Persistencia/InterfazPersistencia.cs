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
    public interface InterfazPersistenciaEmpleados
    {
        void CrearEmpleado(Empleado e);
        void ModificarEmpleado(Empleado e);
        void EliminarEmpleado(Empleado e);

        Empleado LoginEmpleado(string username, string password);
        Empleado BuscarEmpleado(string username);
    }
    public interface InterfazPersistenciaMeteorologos
    {
        void CrearMeteorologo(Meteorologo m);
        void ModificarMeteorologo(Meteorologo m);
        void EliminarMeteorologo(Meteorologo m);

        Meteorologo LoginMeteorologo(string username, string password);
        Meteorologo BuscarMeteorologoActivo(string username);
    }

    public interface InterfazPersistenciaCiudades
    {
        void CrearCiudad(Ciudad c);
        void ModificarCiudad(Ciudad c);
        void EliminarCiudad(Ciudad c);

        Ciudad BuscarCiudadActiva(string codigo);

        List<Ciudad> ListarCiudades();
        List<Ciudad> ListarCiudadesSinPronosticos();
    }

    public interface InterfazPersistenciaPronosticosTiempo
    {
        void CrearPronosticoTiempo(Pronostico_tiempo pt);

        List<Pronostico_tiempo> ListarPronosticosFecha(DateTime fecha);
        List<Pronostico_tiempo> ListarPronosticosAnioActual();
    }

    public interface InterfazPersistenciaPronosticosHora
    {
        void CrearPronosticoHora(Pronostico_hora ph, SqlTransaction trn);

        List<Pronostico_hora> ListarPronosticosHora(int interno, SqlTransaction trn);
    }
}
