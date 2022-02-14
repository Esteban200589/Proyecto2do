using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciudad
    {
        private string pais;
        private string codigo;
        private string nombre_ciudad;

        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (value == "")
                    throw new Exception("Falta el código.");
                else if (value.Length != 6)
                    throw new Exception("El codigo debe contener 6 caracteres.");
                else
                    codigo = value;
            }
        }
        public string Nombre_ciudad
        {
            get { return nombre_ciudad; }
            set
            {
                if (value == null)
                    throw new Exception("Debe contener un nombre.");
                else if (value.Length >= 30)
                    throw new Exception("El nombre debe contener como máximo 30 caracteres.");
                else
                    nombre_ciudad = value;
            }
        }
        public string Pais
        {
            get { return pais; }
            set
            {
                if (value == null)
                    throw new Exception("Debe indicar el País.");
                else if (value.Length >= 20)
                    throw new Exception("El país debe contener como máximo 20 caracteres.");         
                else
                    pais = value;
            }
        }

        public Ciudad(string pCode, string pName, string pPais)
        {
            Pais = pPais;
            Codigo = pCode;
            Nombre_ciudad = pName;
        }
    }
}

//else if (Regex.IsMatch(value, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*") == false)
// throw new Exception("El formato es incorrecto.");