using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factura___Luis_Lopez_G21
{
    public class Producto
    {
        //Atributos de la clase Producto:
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int ID { get; set; }
        public Double Precio { get; set; }

        //Creamos el constructor para definir los atributos del producto ni bien lo creamos:
        public Producto(string unNombre, string unaMarca, int unaID, Double unPrecio)
        {
            Nombre = unNombre;
            Marca = unaMarca;
            ID = unaID;
            Precio = unPrecio;
        }
    }
}
