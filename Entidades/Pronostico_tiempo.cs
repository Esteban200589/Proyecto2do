using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class Pronostico_tiempo
    {
        private int interno;
        private DateTime fecha;
        private Ciudad ciudad;
        private Usuario usuario;
        private List<Pronostico_hora> list_pronosticos_hora;

        [DataMember]
        public int Interno
        {
            get { return interno; }
            set { 
                interno = value; 
            }
        }
        [DataMember]
        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                fecha = value;
            }
        }
        [DataMember]
        public Ciudad Ciudad
        {
            get { return ciudad; }
            set
            {
                if (value != null)
                    throw new Exception("Debe pertenecer a una Ciudad.");
                else
                    ciudad = value;
            }
        }
        [DataMember]
        public Usuario Usuario
        {
            get { return usuario; }
            set
            {
                if (value != null)
                    throw new Exception("Debe tener un Usuario.");
                else
                    usuario = value;
            }
        }
        [DataMember]
        public List<Pronostico_hora> LIST_pronosticos_hora
        {
            get { return list_pronosticos_hora; }
            set {
                //if (value == null || value.Count <= 0)
                //    throw new Exception("El Pronostico debe contener al menos una hora registrada");
                //else
                    
                list_pronosticos_hora = value;
            }
        }

        public Pronostico_tiempo(int pInt, DateTime pDate, Ciudad pCity, Usuario pUser, List<Pronostico_hora> pList)
        {
            Interno = pInt;
            Fecha = pDate;
            Ciudad = pCity;
            Usuario = pUser;
            LIST_pronosticos_hora = pList;
        }
    }
}
