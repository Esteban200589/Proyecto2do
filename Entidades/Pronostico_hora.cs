using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class Pronostico_hora
    {
        private int hora;
        private int temp_max;
        private int temp_min;
        private int vel_viento;
        private int prob_lluvias;
        private int prob_tormenta;
        private string tipo_cielo;

        [DataMember]
        public int Hora
        {
            get { return hora; }
            set
            {
                if (value > 2359 || value < 0)
                    throw new Exception("hora incorrecta");
                else
                    hora = value;
            }
        }
        [DataMember]
        public int Temp_max
        {
            get { return temp_max; }
            set
            {
                temp_max = value;
            }
        }
        [DataMember]
        public int Temp_min
        {
            get { return temp_min; }
            set
            {
                temp_min = value;
            }
        }
        [DataMember]
        public int V_viento
        {
            get { return vel_viento; }
            set
            {
                vel_viento = value;
            }
        }
        [DataMember]
        public int Prob_lluvias
        {
            get { return prob_lluvias; }
            set
            {
                if (value <= 0 && value >= 100)
                    throw new Exception("Indique un valor del 0 al 100 % (Prob Tormentas)");
                else
                    prob_lluvias = value;
            }
        }
        [DataMember]
        public int Prob_tormenta
        {
            get { return prob_tormenta; }
            set
            {
                if (value <= 0 && value >= 100)
                    throw new Exception("Indique un valor del 0 al 100 % (Prob Tormentas)");
                else
                    prob_tormenta = value;
            }
        }
        [DataMember]
        public string Tipo_cielo
        {
            get { return tipo_cielo; }
            set
            {
                if (value != "despejado" && value != "parcialmente_nuboso" && value != "nuboso")
                    throw new Exception("Tipo de Cielo Incorrecto.");
                else
                    tipo_cielo = value;
            }
        }

        public Pronostico_hora(int pHora, int pMax, int pMin, int pVen, int pLluvia, int pTorm, string pCielo)
        {
            Hora = pHora;
            Temp_max = pMax;
            Temp_min = pMin;
            V_viento = pVen;
            Tipo_cielo = pCielo;
            Prob_tormenta = pTorm;
            Prob_lluvias = pLluvia;
        }
    }
}
