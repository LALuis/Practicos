using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factura___Luis_Lopez_G21
{
    public class Factura
    {
        //Atributos de la clase factura:
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        public Cliente Cliente { get; set; }
        public Double Total { get; set; }
        public List<Producto> Productos { get; set; }

        //Constructor. Ni bien creemos una factura se definiran sus atributos:
        public Factura(DateTime unaFecha, int unNumero, Cliente unCliente, Double unTotal, List<Producto> listaProductos)
        {
            Fecha = unaFecha;
            Numero = unNumero;
            Cliente = unCliente;
            Total = unTotal;
            Productos = listaProductos;
        }
    }
}
