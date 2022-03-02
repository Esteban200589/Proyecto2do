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
    public class Usuario
    {
        private string nombre;
        private string password;
        private string username;

        [DataMember]
        public string Username
        {
            get { return username; }
            set {
                if (value.Trim().Length >= 20)
                    throw new Exception("El Username debe contener hasta 20 caracteres máximo");   
                else
                    username = value; 
            }
        }
        [DataMember]
        public string Password
        {
            get { return password; }
            set {
                Regex Rx = new Regex("[0-9][0-9][0-9][A-z][A-z][A-z][A-z][^A-z0-9 ][^A-z0-9 ]");

                if (value.Trim().Length != 9)
                    throw new Exception("El Password es incorrecto ");
                else if (Rx.IsMatch(value.Trim()))
                    password = value;
                else
                    throw new Exception("El Password es incorrecto (expression).");

                //else if (Regex.IsMatch(value, "[0-9]{3}[A-Z]{4}[^0-9A-Z]{2}"))
                //    throw new Exception("El Password es incorrecto (expression).");
            }
        }
        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set {
                if (value.Trim().Length >= 50)
                    throw new Exception("El Nombre debe contener hasta un máximo de 50 caracteres");
                else
                    nombre = value;
            }
        }

        [DataMember]
        public virtual string Tipo
        {
            get { return "Sin tipo"; }
        }

        public Usuario(string pUser, string pPass, string pName)
        {
            Username = pUser;
            Password = pPass;
            Nombre = pName;
        }
    }
}

//else if (Regex.IsMatch(value, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*") == false)
// throw new Exception("El formato es incorrecto.");