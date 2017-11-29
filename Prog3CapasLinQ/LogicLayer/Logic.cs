using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharedEntities;
using DataLayer;

namespace LogicLayer
{
    public class Logic: ILogic
    {
        //Instanciamos nuestra Data (Privada para que no entren desde UILayer:
        private Data SystemData { get; set; } = new Data();

        //Metodo que devuelve la lista de personas registradas:
        public List<Person> ListAllPersons()
        {
            //Le pedimos a Data que nos de la lista
            List<Person> aList = SystemData.ReturnRegistered();
            return aList;
        }

        //Metodo que devuelve una lista de personas ordenadas por edad
        public List<Person> ListPersonsByAge()
        {
            List<Person> aList = ListAllPersons();
            var ListP = from p in aList
                           orderby p.Age ascending
                           select p;

            //Como listP no es una lista de personas no lo puedo retornar entonces =>
            List<Person> OrdenatedList = new List<Person>();
            foreach(Person p in ListP)
            {
                OrdenatedList.Add(p);
            }
            //Ahora tenemos una lista del tipo List<Persons> Lista para retornar:
            return OrdenatedList;
        }

        //Metodo que devulve una lista de personas con edad mayor a anInt
        public List<Person> ReturnHigherThan(int anInt)
        {
            //Pedimos la lista de personas registradas:
            List<Person> aList = ListAllPersons();

            //Seleccionamos solo los que cumplan la condicion:
            var ListP = from p in aList
                        where p.Age > anInt
                        select p;

            //Creamos la lista resultante y le agregamos los valores:
            List<Person> ResultantList = new List<Person>();
            foreach (Person p in ListP)
            {
                ResultantList.Add(p);
            }

            return ResultantList;
        }

        //Metodo que devuelve una lista segun edad y nombre
        public List<Person> ListByAgeAndName(int anInt, string aName)
        {
            //Pedimos la lista de personas registradas:
            List<Person> aList = ListAllPersons();

            //Seleccionamos solo los que cumplan la condicion:
            var ListP = from p in aList
                        where ((p.Age > anInt) && (p.Name == aName))
                        select p;

            //Creamos la lista resultante y le agregamos los valores:
            List<Person> ResultantList = new List<Person>();
            foreach (Person p in ListP)
            {
                ResultantList.Add(p);
            }

            return ResultantList;
        }

        //Metodo para agregar personas ya definido en la interfaz:
        public void LogicAddPerson(Person aPerson)
        {
            Person myperson = aPerson;
            //Le pasamos la persona que nos llega a la capa Data donde se agregara la persona a la lista:
            SystemData.DataAddPerson(aPerson);
        }
    }
}
