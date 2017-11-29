using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharedEntities;
using LogicLayer;

namespace UILayer
{
    class Program
    {
        //Iniciamos la Logica de Nuestro Programa, la cual a su vez, inicializara la Data.
        public static Logic SystemLogic { get; set; } = new Logic();

        static void Main(string[] args)
        {
            //Cambiamos el titulo de la ventana Consola:
            Console.Title = "LinQ en 3 Capas";
            StartApp();
        }

        public static void StartApp()
        {
            //Creamos la condicion de salida del While
            bool running = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Menu - Practico LinQ en 3 capas:");
                Console.ResetColor();
                Console.WriteLine("--------------------------------");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  1) ");
                Console.ResetColor();
                Console.WriteLine("Agregar personas");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  2) ");
                Console.ResetColor();
                Console.WriteLine("Listar Personas");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  3) ");
                Console.ResetColor();
                Console.WriteLine("Listar Personas ordenadas por edad");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  4) ");
                Console.ResetColor();
                Console.WriteLine("Listar solo edad MAYOR a 20");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  5) ");
                Console.ResetColor();
                Console.WriteLine("Listar Personas (edad mayor a 20 y se llaman Pablo)");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  6) ");
                Console.ResetColor();
                Console.WriteLine("Listar proyección de objeto anónimo");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  0 : ");
                Console.ResetColor();
                Console.WriteLine("Salir");

                //Eleccion de usuario:
                string userChoice = Console.ReadKey(true).KeyChar.ToString();

                //Operamos segun eleccion:
                switch (userChoice)
                {
                    case "1":
                        {
                            Console.Clear();

                            //Pedimos nombre:
                            Console.Write("Ingrese nombre: ");
                            string name = Console.ReadLine();
                            
                            //Pedimos Cedula
                            Console.Write("Ingrese Cedula: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            
                            //Pedimos Edad:
                            Console.Write("Ingrese Edad: ");
                            int age = Convert.ToInt32(Console.ReadLine());

                            //Creamos la persona
                            Person aPerson = new Person(name,id,age);

                            /*
                             * Agregamos la persona a la lista de personas, pasandola al metodo que esta en 
                             * la capa Logic y desde ahi pasandolo al metodo de agregar de la capa data... 
                            */
                            SystemLogic.LogicAddPerson(aPerson);
                            break;
                        }//Fin case 1.

                    case "2":
                        {
                            //Pedimos la lista de personas y la mostramos la lista en pantalla
                            ShowList(SystemLogic.ListAllPersons());
                            break;
                        }//Fin Case 2

                    case "3":
                        {
                            //Pedimos La lista ordenada por edad y la mostramos
                            ShowList(SystemLogic.ListPersonsByAge());
                            break;
                        }//Fin Case 3

                    case "4":
                        {
                            ShowList(SystemLogic.ReturnHigherThan(20));
                            break;
                        }//Fin Case 4

                    case "5":
                        {
                            ShowList(SystemLogic.ListByAgeAndName(20, "Pablo"));
                            break;
                        }//Fin case 5

                    case "6":
                        {
                            Console.Clear();

                            //Pedimos a la Logica que nos devuelva la lista de personas registradas:
                            List<Person> pList = SystemLogic.ListAllPersons();

                            /* No se como devolver desde la logica la lista que genera la siguiente consulta LinQ
                             ya que es anonimo y a la hora de especificar el tipo de retorno en el encabezado del metodo
                             no se puede poner VAR :( */

                            //Creamos el tipo anonimo:
                            var anonymousList = from p in pList
                                                 select new { Upper = p.Name.ToUpper(), Lower = p.Name.ToLower() };

                            if (anonymousList.Count() >= 1)
                            {
                                foreach (var e in anonymousList)
                                {
                                    Console.WriteLine("Nombre en mayúscula: " + e.Upper);
                                    Console.WriteLine("Nombre en minúscula: " + e.Lower);
                                    Console.WriteLine("----------------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Lista vacia...");
                            }

                            Console.WriteLine("Presione cualquier tecla para salir");
                            Console.ReadKey();

                            break;
                        }//Fin Case 6
                        
                    case "0":
                        {
                            running = false;
                            break;
                        }//Fin Case 0

                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opcion Incorrecta \nPresione Cualquier tecla para reintentar...");
                            Console.ResetColor();
                            Console.ReadKey(true);
                            break;
                        }//Fin default

                }//Fin Switch

            } while (running);

        }//Fin StartApp

        public static void ShowList(List<Person> aList)
        {
            Console.Clear();
            if (aList.Count() >= 1)
            {
                foreach (var aPerson in aList)
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Nombre: " + aPerson.Name);
                    Console.WriteLine("CI: " + aPerson.Id);
                    Console.WriteLine("Edad: " + aPerson.Age);
                }
                Console.WriteLine("--------------------");
            }
            else
            {
                Console.WriteLine("Lista vacia...");
            }
            Console.WriteLine("Presione cualquier tecla para salir");
            Console.ReadKey(true);

        }//Fin ShowList
    }
}
