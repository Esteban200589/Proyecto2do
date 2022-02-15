﻿using System;
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
        Empleado LoginEmpleado(string username, string password);
        Empleado BuscarEmpleado(string username);
    }
    public interface InterfazPersistenciaMeteorologos
    {
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

        List<Pronostico_tiempo> ListarPronosticosTodos();
        List<Pronostico_tiempo> ListarPronosticosAnio();
    }

    public interface InterfazPersistenciaPronosticosHora
    {
        void CrearPronosticoHora(Pronostico_hora ph, SqlTransaction trn);
    }
}