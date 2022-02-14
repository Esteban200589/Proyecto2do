using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace Entidades
{
    public class Usuario
    {
        private string nombre;
        private string password;
        private string username;

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
        public string Password
        {
            get { return password; }
            set {
                if (value.Trim().Length != 10)
                    throw new Exception("El Username debe contener 10 exactamente ");
                else if (Regex.IsMatch(value, "[0-9][0-9][0-9][A-Z][A-Z][A-Z][A-Z][^0-9A-Z][^0-9A-Z]") == false)
                    throw new Exception("El formato es incorrecto.");
                else
                    username = value;
            }
        }
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