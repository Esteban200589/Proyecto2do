using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace Persistencia
{
    internal class Conexion
    {
        private static string Server = "(local);";
        //private static string Server = "DESKTOP-MGR3B3L\\SQLEXPRESS;";
        private static string DataBase = "Proyecto_Pronosticos;";

        internal static string Cnn(Usuario user = null)
        {
            string cnn;

            if (user == null)
            {
                cnn = "Data Source=" + Server +
                      "Initial Catalog=" + DataBase +
                      "Integrated Security=true";
            }
            else
            {
                cnn = "Data Source=" + Server +
                      "Initial Catalog=" + DataBase +
                      "User=" + user.Username + "; Password='" + user.Password + "'";
            }

            return cnn;
        }

        // private static string Cnn = Make_Cnn();
    }
}
