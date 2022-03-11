using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class Empleado : Usuario
    {
        private int carga_horaria;

        [DataMember]
        public int Carga_horaria
        {
            get { return carga_horaria; }
            set
            {
                if (value <= 0)
                    throw new Exception("La carga horaria debe ser mayor a Cero");
                else
                    carga_horaria = value;
            }
        }

        //[DataMember]
        //public override string Tipo
        //{
        //    get { return "Empleado"; }
        //}

        public Empleado(int pHoras, string pUser, string pPass, string pName) 
            : base(pUser, pPass, pName)
        {
            Carga_horaria = pHoras;
        }

        public Empleado()
        {
            // default
        }
    }
}
