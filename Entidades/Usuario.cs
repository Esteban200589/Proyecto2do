using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Entidades
{
    [KnownType(typeof(Empleado))]
    [KnownType(typeof(Meteorologo))]
    [DataContract]
    public class Usuario
    {
        private string username;
        private string password;
        private string nombre;

        [DataMember]
        public string Username
        {
            get { return username; }
            set {
                if (value.Trim().Length > 20)
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
                Regex exp = new Regex(@"[0-9]{3}[a-zA-Z]{4}[^A-Za-z0-9]{2}");

                if (value.Trim().Replace(" ","").Length != 9)
                    throw new Exception("El Password es incorrecto - debe contener 9 caracteres!");
                else if (string.IsNullOrEmpty(value))
                    throw new Exception("Ingrese el Password");
                else if (!exp.IsMatch(value))
                    throw new Exception("El Password es incorrecto (expression).");
                else
                    password = value;  
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

        //[DataMember]
        //public virtual string Tipo
        //{
        //    get { return "Sin tipo"; }
        //}

        public Usuario(string pUser, string pPass, string pName)
        {
            Username = pUser;
            Password = pPass;
            Nombre = pName;
        }

        public Usuario()
        {
            // default
        }
    }
}

//else if (Regex.IsMatch(value, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*") == false)
// throw new Exception("El formato es incorrecto.");
//Regex Rx = new Regex("[0-9][0-9][0-9][A-z][A-z][A-z][A-z][^A-z0-9 ][^A-z0-9 ]");
// else if (Rx.IsMatch(value.Trim()))
//    password = value;