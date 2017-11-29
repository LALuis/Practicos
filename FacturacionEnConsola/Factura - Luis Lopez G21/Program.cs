using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factura___Luis_Lopez_G21
{
    class Program
    {
        private static Sistema MiSistema;
        private static Consola MiConsola;

        static void Main(string[] args)
        {
            MiSistema = new Sistema();
            MiConsola = new Consola(MiSistema);
            MiConsola.MenuPrincipal();
        }
    }
}
