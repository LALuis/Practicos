using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factura___Luis_Lopez_G21
{
    public class Sistema
    {
        //Declaramos las listas:
        public List<Cliente> ListaClientes { get; set; }
        public List<Producto> ListaProductos { get; set; }
        public List<Factura> ListaFacturas { get; set; }

        //Inicializamos las listas al crear el Sistema:
        public Sistema()
        {
            //Establecemos el titulo de la ventana:
            Console.Title = "Sistema de Facturacion";
            //Inicializamos las listas del Sistema:
            ListaClientes = new List<Cliente>();
            ListaFacturas = new List<Factura>();
            ListaProductos = new List<Producto>();
        }

        //METODOS DE VERIFICACION
        public bool CedulaRegistrada(int id)
        {
            bool respuesta = false;
            foreach(Cliente unCliente in ListaClientes)
            {
                if (unCliente.Cedula_RUT == id)
                {
                    respuesta = true;
                }
            }
            return respuesta;
        }

        public bool ProductoRegistrado(int id)
        {
            bool respuesta = false;
            foreach(Producto unProducto in ListaProductos)
            {
                if (unProducto.ID == id)
                {
                    respuesta = true;
                }
            }
            return respuesta;
        }

        public bool FacturaRegistrada (int id)
        {
            bool respuesta = false;
            foreach (Factura unaFactura in ListaFacturas)
            {
                if (unaFactura.Numero == id)
                {
                    respuesta = true;
                }
            }
            return respuesta;
        }

        //METODOS QUE DEVUELVEN OBJETOS
        public Cliente BuscarCliente(int idCliente)
        {
            Cliente unCliente = null;
            foreach(Cliente buscador in ListaClientes)
            {
                if (buscador.Cedula_RUT == idCliente)
                {
                    unCliente = buscador;
                }
            }
            return unCliente;
        }

        public Producto BuscarProducto(int idProducto)
        {
            Producto unProducto = null;
            foreach(Producto buscador in ListaProductos)
            {
                if(buscador.ID == idProducto)
                {
                    unProducto = buscador;
                }
            }
            return unProducto;
        }

    }
}
