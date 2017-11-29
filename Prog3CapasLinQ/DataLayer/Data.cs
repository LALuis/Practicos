using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities;

namespace DataLayer
{
    public class Data : IData
    {
        //Creamos la lista que contendra a todas las personas registradas (Privada) para no acceder desde otro lado
        private List<Person> RegisteredPersons { get; set; } = new List<Person>();

        //Agregamos una persona a la lista
        public void DataAddPerson(Person aPerson)
        {
            RegisteredPersons.Add(aPerson);
        }

        //Retornamos la lista de personas registradas:
        public List<Person> ReturnRegistered()
        {
            return RegisteredPersons;
        }
    }
}
