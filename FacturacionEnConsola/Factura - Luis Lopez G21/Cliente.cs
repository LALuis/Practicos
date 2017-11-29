using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factura___Luis_Lopez_G21
{
    public class Cliente
    {
        //Declaramos los atributos de la clase cliente:
        public string Nombre { get; set; }
        public int Cedula_RUT { get; set; }
        public string Domicilio { get; set; }
        public DateTime FechaNacimiento { get; set; }

        //Creamos el constructor que define al iniciar, todoslos atributos de la clase cliente: 
        public Cliente(string unNombre, int unaCed_RUT, string unDomicilio, DateTime unaFecha)
        {
            Nombre = unNombre;
            Cedula_RUT = unaCed_RUT;
            Domicilio = unDomicilio;
            FechaNacimiento = unaFecha;
        }
        
    }
}
