using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pronostico_tiempo
    {
        private int interno;
        private DateTime fecha;
        private Ciudad ciudad;
        private Usuario usuario;
        private List<Pronostico_hora> pronosticos_hora;

        public int Interno
        {
            get { return interno; }
            set { 
                interno = value; 
            }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                fecha = value;
            }
        }

        public Pronostico_tiempo(int pInt, DateTime pDate)
        {
            Interno = pInt;
            Fecha = pDate;
        }
    }
}
