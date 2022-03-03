using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Entidades
{
    [DataContract]
    public class Meteorologo: Usuario
    {
        private string telefono;
        private string correo;

        [DataMember]
        public string Telefono
        {
            get { return telefono; }
            set
            {
                if (value == null)
                    throw new Exception("Debe tener un Correo.");
                else if (value.Length > 20)
                    throw new Exception("El telefono no puede ser mayor a 20 Caracteres de largo");
                else
                    telefono = value;
            }
        }

        [DataMember]
        public string Correo
        {
            get { return correo; }
            set
            {
                if (value == null)
                    throw new Exception("Debe tener un Correo.");
                else if (value.Length > 30)
                    throw new Exception("El Correo debe contener hasta un maximo de 30 caracteres");
                else if (Regex.IsMatch(value, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*") == false)
                    throw new Exception("El formato del Correo es incorrecto.");
                else
                    correo = value;
            }
        }

        //[DataMember]
        //public override string Tipo
        //{
        //    get { return "Meteorologo"; }
        //}

        public Meteorologo(string pTel, string pCo, string pUser, string pPass, string pName)
            : base(pUser, pPass, pName)
        {
            Telefono = pTel;
            Correo = pCo;
        }
    }
}
