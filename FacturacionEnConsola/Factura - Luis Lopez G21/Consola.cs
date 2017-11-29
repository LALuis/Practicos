using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Factura___Luis_Lopez_G21
{
    public class Consola
    {
        //Declaramos que existe un Sistema:
        Sistema MiSistema { get; set; }

        //Ni bien creamos la consola le decimos que iguale el sistema antes declarado al Sistema Principal:
        public Consola(Sistema unSistema)
        {
            MiSistema = unSistema;
        }

        //Metodos privados, no hay necesidad de hacerlos publicos SALVO MenuPrincipal que debemos acceder desde Program:

        //MENU PRINCIPAL:

        public void MenuPrincipal()
        {
            //Creamos la variable de control del while:
            bool termina = false;
            do
            {
                //Desplegamos el menu:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Escribir("Menu Principal:");
                Escribir("---------------");
                Console.ResetColor();
                Console.WriteLine();
                Escribir("a) Registros");
                Escribir("b) Listados");
                Escribir("Escape : Salir");

                //Apagamos el cursor:
                Console.CursorVisible = false;

                //Guardamos la eleccion del usuario:
                ConsoleKeyInfo eleccion = Console.ReadKey(true);

                //Operamos en base a la eleccion:
                switch (eleccion.Key.ToString())
                {
                    case "A":
                        {
                            MenuRegistros();
                            break;
                        }
                    case "B":
                        {
                            MenuListados();
                            break;
                        }
                    case "Escape":
                        {
                            termina = true;
                            break;
                        }
                    default:
                        {
                            Error("OpcionInco");
                            CuentaAtras("Error");
                            break;
                        }
                }

            } while (!termina);
        }//FIN MENU PRINCIPAL


        //MENU REGISTROS

        private void MenuRegistros()
        {
            //Creamos la variable de control del while:
            bool termina = false;
            do
            {
                //Desplegamos el menu:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Escribir("Menu Registros:");
                Escribir("---------------");
                Console.ResetColor();
                Console.WriteLine();
                Escribir("a)Registrar cliente");
                Escribir("b)Registrar factura");
                Escribir("c)Registrar producto");
                Escribir("Escape : Salir");

                //Guardamos la eleccion del usuario:
                ConsoleKeyInfo eleccion = Console.ReadKey(true);

                //Operamos en base a la eleccion:
                switch (eleccion.Key.ToString())
                {
                    case "A":
                        {
                            /*Pedimos los datos y lo registramos desde aqui, si lo fueramos a utilizar desde varios 
                             * lugares creariamos un metodo, pero solo se usara desde este menu*/

                            //Limpiamos la pantalla y encendemos el cursor.
                            Console.Clear();
                            Console.CursorVisible = true;

                            //Pedimos Nombre:
                            bool condicion = true;
                            string nombre = "";
                            do
                            {
                                Console.Clear();
                                Escribir("Ingrese Nombre: ", 1);
                                nombre = "";
                                try
                                {
                                    nombre = Console.ReadLine();
                                    if (nombre == "")
                                    {
                                        Error("Nulo");
                                        CuentaAtras("Error");
                                    }
                                    else
                                    {
                                        condicion = false;
                                    }

                                }
                                catch (FormatException)
                                {
                                    Error("Formato");
                                    CuentaAtras("Error");
                                }
                            } while (condicion);


                            //Pedimos Cedula:

                            condicion = true; //Reseteamos el valor de condicion para no declarar mas variables.
                            int cedula = 0;
                            do
                            {
                                Console.Clear();
                                Escribir("Ingrese cedula o RUT sin puntos ni guiones: ", 1);
                                try
                                {
                                    cedula = Convert.ToInt32(Console.ReadLine());
                                    if (!MiSistema.CedulaRegistrada(cedula))
                                    {
                                        condicion = false;
                                    }
                                    else
                                    {
                                        Error("CRegistrado");
                                        CuentaAtras("Error");
                                    }
                                }
                                catch (Exception)
                                {
                                    Error("Formato");
                                    CuentaAtras("Error");
                                }
                            } while (condicion);

                            //Pedimos domicilio:
                            condicion = true;
                            string domicilio = "";
                            do
                            {
                                Console.Clear();
                                Escribir("Ingrese domicilio: ", 1);
                                try
                                {
                                    domicilio = Console.ReadLine();
                                    if (domicilio == "")
                                    {
                                        Error("Nulo");
                                        CuentaAtras("Error");
                                    }
                                    else
                                    {
                                        condicion = false;
                                    }

                                }
                                catch
                                {
                                    Error("Formato");
                                    CuentaAtras("Error");
                                }

                            } while (condicion);

                            //Pedimos fecha de nacimiento
                            condicion = true;
                            //Definimos la fecha en el formato de uruguay:
                            CultureInfo miFormatoCultu = new CultureInfo("es-UY");
                            String formato = "dd/MM/yyyy";
                            DateTime fechaNacimiento = new DateTime();
                            do
                            {
                                Console.Clear();
                                Escribir("Ingrese fecha de Nacimiento dd/mm/aaaa: ", 1);
                                try
                                {
                                    fechaNacimiento = DateTime.ParseExact(Console.ReadLine(), formato, miFormatoCultu);
                                    condicion = false;
                                    CuentaAtras("Exito");
                                }
                                catch (Exception)
                                {
                                    Error("Formato");
                                    CuentaAtras("Error");
                                }

                            } while (condicion);


                            //Creamos el cliente y lo agregamos a la lista:
                            Cliente unCliente = new Cliente(nombre, cedula, domicilio, fechaNacimiento);
                            MiSistema.ListaClientes.Add(unCliente);
                            
                            break;
                        }

                    /*   FIN DE REGISTRAR CLIENTE, CASE "A"*/

                    case "B":
                        {
                            //REGISTRAR FACTURA:
                            /*Pedimos los datos y lo registramos desde aqui, si lo fueramos a utilizar desde varios 
                             * lugares creariamos un metodo, pero solo se usara desde este menu*/

                            //FECHA DE LA FACTURA
                            bool condicion = true;
                            //Definimos la fecha en el formato de uruguay:
                            CultureInfo miFormatoCultu = new CultureInfo("es-UY");
                            String formato = "dd/MM/yyyy";
                            DateTime fechaFactura = new DateTime();
                            do
                            {
                                Console.Clear();
                                Escribir("Ingrese fecha: dd/mm/aaaa: ", 1);
                                try
                                {
                                    fechaFactura = DateTime.ParseExact(Console.ReadLine(), formato, miFormatoCultu);
                                    condicion = false;
                                }
                                catch (Exception)
                                {
                                    Error("Formato");
                                    CuentaAtras("Error");
                                }

                            } while (condicion);

                            //NUMERO DE FACTURA:
                            int numFactura = 0;
                            condicion = true;
                            do
                            {
                                Console.Clear();
                                Escribir("Ingrese el numero de Factura: ", 1);
                                try
                                {
                                    numFactura = Convert.ToInt32(Console.ReadLine());
                                    if ((!MiSistema.FacturaRegistrada(numFactura)) && (numFactura >= 0))
                                    {
                                        condicion = false;
                                    }
                                    else if (numFactura <= 0)
                                    {
                                        Error("EnteroPos");
                                        CuentaAtras("Error");
                                    }
                                    else
                                    {
                                        Error("FRegistrada");
                                        CuentaAtras("Error");
                                    }
                                }
                                catch (Exception)
                                {
                                    Error("Formato");
                                    CuentaAtras("Error");
                                }
                            } while (condicion);

                            //PEDIMOS NUMERO DE CLIENTE
                            condicion = true;
                            int idCliente = 0;
                            Cliente unCliente = null;
                            do
                            {
                                Console.Clear();
                                Escribir("Ingrese cedula o RUT de Cliente: ", 1);
                                try
                                {
                                    idCliente = Convert.ToInt32(Console.ReadLine());
                                    //Si el cliente no esta registrado unCliente sera null
                                    unCliente = MiSistema.BuscarCliente(idCliente);
                                    if (unCliente != null)
                                    {
                                        condicion = false;
                                    }
                                    else
                                    {
                                        Error("ClienteNoR");
                                        CuentaAtras("Error");
                                    }
                                }
                                catch (Exception)
                                {
                                    Error("Formato");
                                    CuentaAtras("Error");
                                }
                            } while (condicion);

                            /********************************************************/
                            //Agregamos la lista de productos y vamos sumando el total
                            
                            //MENU AGREGAR PRODUCTOS

                            //Variables
                            condicion = true;
                            List<Producto> productosFactura = new List<Producto>();
                            Double montoTotal = 0;

                            do
                            {
                                Console.Clear();
                                Escribir("Productos de la factura N° " + numFactura);
                                Escribir("-------------------------------");
                                Console.WriteLine();
                                Escribir("a) Agregar Producto");
                                Escribir("b) Terminar");

                                //Tomamos el ingreso del usuario
                                ConsoleKeyInfo usuario = Console.ReadKey(true);

                                switch (usuario.KeyChar.ToString().ToLower())
                                {
                                    case "a":
                                        {
                                            //PEDIMOS ID DEL PRODUCTO:
                                            bool control = true;
                                            do
                                            {
                                                Console.Clear();
                                                Escribir("Ingrese la ID del producto: ", 1);
                                                try
                                                {
                                                    int idProducto = Convert.ToInt32(Console.ReadLine());

                                                    //Verificamos que el id sea correcto
                                                    Producto unProducto = MiSistema.BuscarProducto(idProducto);
                                                    if(unProducto == null)
                                                    {
                                                        Error("ProductoNoR");
                                                        CuentaAtras("Error");
                                                    }
                                                    else if(idProducto < 0)
                                                    {
                                                        Error("EnteroPos");
                                                        CuentaAtras("Error");
                                                    }
                                                    else
                                                    {
                                                        //Pasamos control a false para no olvidarnos
                                                        control = false;

                                                        //PEDIMOS CANTIDAD:
                                                        bool loopCantidad = true;
                                                        do
                                                        {
                                                            Console.Clear();
                                                            Escribir("Ingrese la cantidad de " + unProducto.Nombre + " " + unProducto.Marca + " que desea agregar: ", 1);
                                                            try
                                                            {
                                                                int cantidad = Convert.ToInt32(Console.ReadLine());
                                                                if(cantidad <= 0)
                                                                {
                                                                    //Si la cantidad no es un entero mayor que cero:
                                                                    Error("EnteroPos");
                                                                    CuentaAtras("Error");
                                                                }
                                                                else
                                                                {
                                                                    //Loop Cantidad termina
                                                                    loopCantidad = false;
                                                                    //Preguntamos si desea agregar esa cantidad de ese producto
                                                                    bool controlSiNo = true;
                                                                    do
                                                                    {
                                                                        Console.Clear();
                                                                        Escribir("Esta seguro que desea agregar " + cantidad + " " + unProducto.Nombre + " " + unProducto.Marca + " por " + (unProducto.Precio * cantidad) + "? (Y/N)");
                                                                        ConsoleKeyInfo eleccionUsuario = Console.ReadKey(true);
                                                                        if (eleccionUsuario.KeyChar.ToString().ToUpper() == "Y")
                                                                        {
                                                                            //Agregamos el mmonto al total:
                                                                            montoTotal += (unProducto.Precio * cantidad);
                                                                            //Agregamos el producto a la lista de la factura:
                                                                            productosFactura.Add(unProducto);
                                                                            //Terminamos loop:
                                                                            controlSiNo = false;
                                                                        }
                                                                        else if(eleccionUsuario.KeyChar.ToString().ToUpper() == "N")
                                                                        {
                                                                            controlSiNo = false;
                                                                            CuentaAtras();
                                                                        }
                                                                        else
                                                                        {
                                                                            Error("OpcionInco");
                                                                            CuentaAtras("Error");
                                                                        }
                                                                    } while (controlSiNo);
                                                                    
                                                                }
                                                            }
                                                            catch (Exception)
                                                            {
                                                                //Si nos ingresan algo que no es un int32
                                                                Error("Formato");
                                                                CuentaAtras("Error");
                                                            }
                                                        } while (loopCantidad);
                                                    }
                                                }
                                                catch (Exception)
                                                {
                                                    Error("Formato");
                                                    CuentaAtras("Error");
                                                }
                                            } while (control);
                                            break;//CASE A
                                        }
                                    case "b":
                                        {
                                            condicion = false;
                                            break;
                                        }
                                    default:
                                        {
                                            Error("OpcionInco");
                                            CuentaAtras("Error");
                                            break;
                                        }
                                }

                            } while (condicion);

                            //Agregamos la factura a la lista de Facturas:
                            Factura unaFactura = new Factura(fechaFactura, numFactura, unCliente, montoTotal, productosFactura);
                            MiSistema.ListaFacturas.Add(unaFactura);
                            //Mensaje de Exito
                            CuentaAtras("Exito");
                            break;//CASE B MENU REGISTRAR
                        }

                    /*   FIN DE REGISTRAR FACTURA, CASE "B"*/

                    case "C":
                        {
                            //REGISTRAR PRODUCTO
                            /*Pedimos los datos y lo registramos desde aqui, si lo fueramos a utilizar desde varios 
                             * lugares creariamos un metodo, pero solo se usara desde este menu*/

                            //PEDIMOS NOMBRE:
                            string nombre = "";
                            bool condicion = true;
                            do
                            {
                                Console.Clear();
                                Escribir("Ingrese el nombre: ", 1);
                                try
                                {
                                    nombre = Console.ReadLine();
                                    if (nombre != "")
                                    {
                                        condicion = false;
                                    }
                                    else
                                    {
                                        Error("Nulo");
                                        CuentaAtras("Error");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Error("Formato");
                                    CuentaAtras("Error");
                                }
                            } while (condicion);

                            //PEDIMOS MARCA:
                            string marca = "";
                            condicion = true;
                            do
                            {
                                Console.Clear();
                                Escribir("Ingrese la Marca: ",1);
                                try
                                {
                                    marca = Console.ReadLine();
                                    if (marca != "")
                                    {
                                        condicion = false;
                                    }
                                    else
                                    {
                                        Error("Formato");
                                        CuentaAtras("Error");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Error("Formato");
                                    CuentaAtras("Error");
                                }

                            } while (condicion);

                            //PEDIMOS ID:
                            int id=0;
                            condicion = true;
                            do
                            {
                                Console.Clear();
                                Escribir("Ingrese la ID del producto: ", 1);
                                try
                                {
                                    id = Convert.ToInt32(Console.ReadLine());
                                    if (!MiSistema.ProductoRegistrado(id))
                                    {
                                        condicion = false;
                                    }
                                    else
                                    {
                                        Error("PRegistrado");
                                        CuentaAtras("Error");
                                    }
                                }
                                catch (Exception)
                                {
                                    Error("Formato");
                                    CuentaAtras("Error");
                                }
                            } while (condicion);

                            //INGRESAMOS PRECIO POR UNIDAD:
                            Double precio=0;
                            condicion = true;
                            do
                            {
                                Console.Clear();
                                Escribir("Ingrese el precio POR UNIDAD: ", 1);
                                try
                                {
                                    precio = Convert.ToDouble(Console.ReadLine());
                                    if (precio >= 0)
                                    {
                                        condicion = false;
                                    }
                                    else
                                    {
                                        Error("EnteroPos");
                                        CuentaAtras("Error");
                                    }
                                }
                                catch
                                {
                                    Error("Formato");
                                    CuentaAtras("Error");
                                }

                            } while (condicion);

                            //AGREGAMOS EL PRODUCTO A LA LISTA:
                            Producto unProducto = new Producto(nombre, marca, id, precio);
                            MiSistema.ListaProductos.Add(unProducto);
                            CuentaAtras("Exito");
                            break;
                        }

                    /*   FIN DE REGISTRAR PRODUCTO, CASE "C"*/

                    case "Escape":
                        {
                            termina = true;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine();
                            Error("OpcionInco");
                            CuentaAtras("Error");
                            break;
                        }
                }

            } while (!termina);

        }//FIN MENU REGISTROS


        //MENU LISTADOS y sus Metodos:

        private void MenuListados()
        {//Creamos la variable de control del while:
            bool termina = false;
            do
            {
                //Desplegamos el menu:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Escribir("Menu Listados:");
                Escribir("---------------");
                Console.ResetColor();
                Console.WriteLine();
                Escribir("a)Listar clientes");
                Escribir("b)Listar facturas");
                Escribir("c)Listar productos");
                Escribir("Escape : Salir");

                //Guardamos la eleccion del usuario:
                ConsoleKeyInfo eleccion = Console.ReadKey(true);

                //Operamos en base a la eleccion:
                switch (eleccion.Key.ToString())
                {
                    case "A":
                        {
                            Escribir("Listado de Clientes:");
                            Escribir("--------------------");
                            ListarClientes();
                            Escribir("Presione cualquier tecla para salir...");
                            Console.ReadKey();
                            break;
                        }
                    case "B":
                        {
                            Escribir("Listado de Facturas:");
                            Escribir("--------------------");
                            ListarFacturas();
                            Escribir("Presione cualquier tecla para salir...");
                            Console.ReadKey();
                            break;
                        }
                    case "C":
                        {
                            Escribir("Listado de Productos:");
                            Escribir("--------------------");
                            ListarProductos();
                            Escribir("Presione cualquier tecla para salir...");
                            Console.ReadKey();
                            break;
                        }
                    case "Escape":
                        {
                            termina = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine();
                            Error("OpcionInco");
                            CuentaAtras("Error");
                            break;
                        }
                }

            } while (!termina);

        }

        private void ListarClientes()
        {
            Console.Clear();
            if (MiSistema.ListaClientes.Count > 0)
            {
                foreach (Cliente cliente in MiSistema.ListaClientes)
                {
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("Nombre: " + cliente.Nombre);
                    Console.WriteLine("Cedula o RUT: " + cliente.Cedula_RUT);
                    Console.WriteLine("Domicilio: " + cliente.Domicilio);
                    Console.WriteLine("Fecha de Nacimiento: " + cliente.FechaNacimiento.ToString("dd/MM/yyyy"));
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                Error("SinClientes");
            }
        }

        private void ListarProductos()
        {
            Console.Clear();
            if (MiSistema.ListaProductos.Count > 0)
            {
                foreach (Producto producto in MiSistema.ListaProductos)
                {
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("Nombre: " + producto.Nombre);
                    Console.WriteLine("Marca: " + producto.Marca);
                    Console.WriteLine("ID: " + producto.ID);
                    Console.WriteLine("Precio: " + producto.Precio);
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine();
                }
            }
            else
            {
                Error("SinProductos");
            }
        }

        private void ListarFacturas()
        {
            Console.Clear();
            if (MiSistema.ListaFacturas.Count > 0)
            {
                foreach (Factura factura in MiSistema.ListaFacturas)
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Numero de Factura: " + factura.Numero + "| Fecha: " + factura.Fecha.ToString("dd/MM/yyyy"));
                    Console.WriteLine("Cliente: " + factura.Cliente.Nombre);
                    Console.WriteLine("Direccion: " + factura.Cliente.Domicilio);
                    Console.WriteLine();
                    Console.WriteLine("Productos: ");
                    Console.WriteLine();
                    foreach (Producto producto in factura.Productos)
                    {
                        Console.WriteLine("     ->" + producto.Nombre + "..........$"  + producto.Precio);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Total: " + factura.Total);
                    Console.WriteLine("-------------------------------------------------");
                }
            }
            else
            {
                Error("SinFacturas");
            }
        }




        //METODOS DE CONSOLA:
        /* Su utilidad tiene qe ver con la Interfaz de usuario
         y tratar de hacer mas agradable la vista del programa*/

        private void Escribir(string unTexto, int opcion = 0)
        {
            //Si opcion es distinto de cero, es poruqe queremos que el cursor quede pegado a lo que se escribe
            if(opcion != 0)
            {
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) + (unTexto.Length / 2)) + "}", unTexto));
            }
            //Si opcion es cero, es porque queremos agregar un enter y que el cursor quede en la linea siguiente 
            else
            {
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (unTexto.Length / 2)) + "}", unTexto));
            }
        }

        private void CuentaAtras(string condicion = "default")
        {
            Console.WriteLine();

            //Desactivamos el cursor:
            Console.CursorVisible = false;
            
            //Operamos segun el parametro:
            switch (condicion.ToLower().Trim())
            {
                
                case "error":
                    {
                        //Cambiamos el color:
                        Console.ForegroundColor = ConsoleColor.Red;
                        //Mostramos la cuenta regresiva:
                        Escribir("Cargando ", 1);
                        string[] cargador = new string[12] { "[", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "]" };

                        for (int i = 1, j = 0; i <= cargador.Count() - 2; j++)
                        {
                            if (j % 1500 == 0)
                            {
                                cargador[i] = "■";
                                i++;
                            }
                            Console.CursorLeft = (Console.WindowWidth / 2) - 6;
                            Console.Write(cargador[0] + cargador[1] + cargador[2] + cargador[3] + cargador[4] + cargador[5] + cargador[6] + cargador[7] + cargador[8] + cargador[9] + cargador[10] + cargador[11]);
                        }
                        /*
                         * ASI ESTABA HECHO CON EL THREAD QUE IBA A USAR EN UN PRINCIPIO:
                        for (int a = 0; a <= 100; a++)
                        {
                            Console.CursorLeft = (Console.WindowWidth / 2) + 5;
                            Console.Write(a + "%");
                            //System.Threading.Thread.Sleep(1000);
                            System.Threading.Thread.SpinWait(2000000);
                        }*/
                        //Reseteamos el color:
                        Console.ResetColor();
                    break;
                    }
                case "exito":
                    {
                        //Cambiamos el color:
                        Console.ForegroundColor = ConsoleColor.Green;

                        //Mostramos la cuenta regresiva:
                        Escribir(" Operacion exitosa!!");
                        Escribir("Cargando: ");
                        string[] cargador = new string[12] { "["," ", " ", " ", " ", " ", " ", " ", " ", " ", " ","]" };
                        
                        for (int i=1,j=0; i <= cargador.Count() - 2;j++)
                        {
                            if (j % 1000 == 0)
                            {
                                cargador[i] = "■";
                                i++;
                            }
                            Console.CursorLeft = (Console.WindowWidth / 2) -6;
                            Console.Write(cargador[0] + cargador[1] + cargador[2] + cargador[3] + cargador[4] + cargador[5] + cargador[6] + cargador[7] + cargador[8] + cargador[9] + cargador[10] + cargador[11]);
                        }

                                
                        /*
                         *  ASI ESTABA ANTES CON THREAD (TENIA MUCHAS GANAS DE USARLO JEJEJE)
                         *  for (int a = 0; a <= 100; a++)
                         *   {
                         *  Console.CursorLeft = (Console.WindowWidth / 2) + 5;
                         *  Console.Write(a + "%");
                         *  //System.Threading.Thread.Sleep(1000);
                         *  System.Threading.Thread.SpinWait(1500000);
                         *  }
                        */

                        //Reseteamos el color:
                        Console.ResetColor();
                        break;
                    }
                default:
                    {
                        Escribir("Cargando ", 1);
                        string[] cargador = new string[12] { "[", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "]" };

                        for (int i = 1, j = 0; i <= cargador.Count() - 2; j++)
                        {
                            if (j % 1000 == 0)
                            {
                                cargador[i] = "■";
                                i++;
                            }
                            Console.CursorLeft = (Console.WindowWidth / 2) - 6;
                            Console.Write(cargador[0] + cargador[1] + cargador[2] + cargador[3] + cargador[4] + cargador[5] + cargador[6] + cargador[7] + cargador[8] + cargador[9] + cargador[10] + cargador[11]);
                        }

                        /* ASI ESTABA CON EL THREAD
                         
                        for (int a = 0; a <= 100; a++)
                        {
                            Console.CursorLeft = (Console.WindowWidth / 2) + 5;
                            Console.Write(a + "%");
                            //System.Threading.Thread.Sleep(1000);
                            System.Threading.Thread.SpinWait(750000);
                        }*/
                        break;
                    }
            }
            //Activamos nuevamente el cursor:
            Console.CursorVisible = true;
        }

        private void Error(string condicion)
        {
            //Cambiamos a Color de Error:
            Console.ForegroundColor = ConsoleColor.Red;

            switch (condicion.Trim().ToLower())
            {
                case "opcioninco":
                    {
                        Console.Beep();
                        Escribir("ERROR:");
                        Escribir("Opcion Incorrecta");
                        Escribir("Aguarde e intente nuevamente.");
                        break;
                    }
                case "formato":
                    {
                        Console.Beep();
                        Escribir("ERROR:");
                        Escribir("Error en el formato de ingreso");
                        Escribir("Aguarde e intente nuevamente.");
                        break;
                    }
                case "nulo":
                    {
                        Console.Beep();
                        Escribir("ERROR:");
                        Escribir("No se permiten ingresos vacios");
                        Escribir("Aguarde e intente nuevamente.");
                        break;
                    }
                case "pregistrado":
                    {
                        Console.Beep();
                        Escribir("ERROR:");
                        Escribir("Producto ya registrado");
                        Escribir("Aguarde e intente nuevamente.");
                        break;
                    }
                case "cregistrado":
                    {
                        Console.Beep();
                        Escribir("ERROR:");
                        Escribir("Cliente ya registrado");
                        Escribir("Aguarde e intente nuevamente.");
                        break;
                    }
                case "productonor":
                    {
                        Console.Beep();
                        Escribir("ERROR:");
                        Escribir("Producto NO registrado");
                        Escribir("Aguarde e intente nuevamente.");
                        break;
                    }
                case "clientenor":
                    {
                        Console.Beep();
                        Escribir("ERROR:");
                        Escribir("Cliente NO registrado");
                        Escribir("Aguarde e intente nuevamente.");
                        break;
                    }
                case "fregistrada":
                    {
                        Console.Beep();
                        Escribir("ERROR:");
                        Escribir("Factura ya registrada");
                        Escribir("Aguarde e intente nuevamente.");
                        break;
                    }
                case "enteropos":
                    {
                        Console.Beep();
                        Escribir("ERROR:");
                        Escribir("Solo se permiten numeros mayores a cero");
                        Escribir("Aguarde e intente nuevamente.");
                        break;
                    }
                case "sinproductos":
                    {
                        //El color es normal, ya que no es un error, sino un caso especial
                        Console.ResetColor();
                        Escribir("No hay ningún Producto registrado en el sistema");
                        break;
                    }
                case "sinclientes":
                    {
                        //El color es normal, ya que no es un error, sino un caso especial
                        Console.ResetColor();
                        Escribir("No hay ningún Cliente registrado en el sistema");
                        break;
                    }
                case "sinfacturas":
                    {
                        //El color es normal, ya que no es un error, sino un caso especial
                        Console.ResetColor();
                        Escribir("No hay ninguna Factura registrada en el sistema");
                        break;
                    }
            }

            //Reseteamos el Color:
            Console.ResetColor();
        }



        //Fin Metodos...
    }
}
