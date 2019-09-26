using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ReservacionDeVuelos
{
    class Program
    {
        static Ciudad[] ciudad = new Ciudad[100];
        static List<Vuelos> vuelos = new List<Vuelos>();
        static int cc = 0;
        static void Main(string[] args)
        {
            int op = -1;
            Program p = new Program();
            do
            {
                try
                {
                    Console.WriteLine("--------------menú-------------");
                    Console.WriteLine("1.- Alta de Ciudad");
                    Console.WriteLine("2.- Alta de Vuelos");
                    Console.WriteLine("3.- Alta Club Premier");
                    Console.WriteLine("4.- Compra boletos");
                    Console.WriteLine("5.- Consulta vuelos disponibles");
                    Console.WriteLine("0.- Salir");
                    Console.Write("Seleccione una opcion: ");
                    op = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    op = -1;
                }
                switch(op){
                    case 1:
                        AltaCiudades();
                        break;
                    case 2:
                        AltaVuelos();
                        break;
                    case 3:
                        AltaClubPremier();
                        break;
                    case 4:
                        CompraBoleto();
                        break;
                    case 5:
                        ConsulataVuelos();
                        break;
                    case 0:
                        op = 0;
                        break;
                    default:
                        Console.WriteLine("Seleccione una opcion valida.");
                        break;
                }

            } while (op != 0);
        }

        private static void ConsulataVuelos()
        {

        }

        private static void CompraBoleto()
        {
            Console.WriteLine("b");
        }

        private static void AltaClubPremier()
        {
            Console.WriteLine("c");
        }

        private static void AltaVuelos()
        {
            string CodigoVuelo = "";
            int NumeroDePasajeros = 0;
            string Origen = "";
            string Destino = "";
            int Capacidad = 0;
            int BoletosVendidos = 0;
            int Costos= 0;
            double Millas = 0.0;
            string DiasEnQueSeRelizaElVuelo = "";
            do
            {
                Console.Write("Codigo del Vuelo: ");
                CodigoVuelo = Console.ReadLine();
                if (existeClaveCiudad(CodigoVuelo))
                {
                    Console.Write("El codigo ya existe");
                    CodigoVuelo = "";
                }

            } while (CodigoVuelo == "");
            do
            {
                Console.Write("Ciudad origen: ");
                Origen = Console.ReadLine();
            } while (Origen == "");
            do
            {
                Console.Write("Ciudad destino: ");
                Destino = Console.ReadLine();
            } while (Destino == "");
            do
            {
                try
                {
                    Console.Write("Capacidad: ");
                    Capacidad = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Favor de ingresar un dato numerico valido.");
                    Capacidad = 0;
                }
            } while (Capacidad <= 0);
            do
            {
                try
                {
                    Console.Write("Costo: ");
                    Costos = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Favor de ingresar un dato numerico valido.");
                    Costos = 0;
                }
            } while (Costos <= 0);

            do
            {
                try
                {
                    Console.Write("Millas: ");
                    Millas = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Favor de ingresar un dato numerico valido.");
                    Millas = 0;
                }
            } while (Millas <= 0);
            do
            {

            } while (DiasEnQueSeRelizaElVuelo == "");

        }

        private static void AltaCiudades()
        {
            Console.Clear();
            string claveciudad = "";
            string nombreciudad = "";
            string estado = "";
            Console.WriteLine("---Alta ciudades---");
            do
            {
                Console.Write("Clave Ciudad: ");
                claveciudad = Console.ReadLine();
                if (existeClaveCiudad(claveciudad))
                {
                    Console.WriteLine("La clave ya existe");
                    claveciudad = "";
                }

            } while (claveciudad == "");
            do
            {
                Console.Write("Nombre  Ciudad: ");
                nombreciudad = Console.ReadLine();

            } while (nombreciudad == "");
            do
            {
                Console.Write("Estado: ");
                estado = Console.ReadLine();

            } while (estado == "");
            Ciudad c = new Ciudad(claveciudad,nombreciudad,estado);
            ciudad[cc] = c;
            cc++;
        }

        static bool existeClaveCiudad(string claveC)
        {
            for(int i= 0; i < 100;i++)
            {
                if (ciudad[i]!=null)
                {
                    if (ciudad[i].pClaveCiudad == claveC)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static bool existeVuelos(string claveV)
        {
            foreach(Vuelos v in vuelos)
            {
                if (v.PCodigoVuelo == claveV)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
