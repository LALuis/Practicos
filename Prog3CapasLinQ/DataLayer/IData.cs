using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharedEntities;

namespace DataLayer
{
    public interface IData
    {
        //Definicion del metodo para agregar personas:
        void DataAddPerson(Person aPerson);

        //Metodo que retorna las personas Registradas
        List<Person> ReturnRegistered();
    }
}
