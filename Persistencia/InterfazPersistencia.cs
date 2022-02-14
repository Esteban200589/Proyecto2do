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
        Empleado LoginEmpelado(string username, string password);
        Empleado BuscarEmpleado(string username);
    }
    public interface InterfazPersistenciaMeteorologos
    {
        Meteorologo LoginMeteorologo(string username, string password);
        Meteorologo BuscarMeteorologo(string username);
    }

    public interface InterfazPersistenciaCiudades
    {
        void CrearCiudad(Ciudad c);
        void ModificarCiudad(Ciudad c);
        void EliminarCiudad(Ciudad c);

        void ListaCiudades
    }

    public interface InterfazPersistenciaPronosticosTiempo
    {
        void CrearPronosticoTiempo(Pronostico_tiempo pt);
    }

    public interface InterfazPersistenciaPronosticosHora
    {
        void CrearPronosticoHora(Pronostico_hora ph);
    }
}
