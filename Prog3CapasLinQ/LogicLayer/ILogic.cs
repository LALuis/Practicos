using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharedEntities;
using DataLayer;

namespace LogicLayer
{
    public interface ILogic
    {
        //Agregar Persona:
        void LogicAddPerson(Person aPerson);

        //Lista de personas:
        List<Person> ListAllPersons();

        //Lista de personas segun su edad:
        List<Person> ListPersonsByAge();

        //Personas mayores a un parametro:
        List<Person> ReturnHigherThan(int anInt);

        //Personas Por edad y nombre:
        List<Person> ListByAgeAndName(int anInt, string aName);


    }
}
