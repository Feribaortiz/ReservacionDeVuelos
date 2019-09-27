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
        static Dictionary<int, ClubPremier> Club = new Dictionary<int, ClubPremier>();
        static Dictionary<int, Boleto> boletos = new Dictionary<int, Boleto>();
        static int ClaveClubPremier = 1000;
        static int ClaveBoleto = 10;
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
            Console.WriteLine("---Consulta vuelos---");
            foreach (Vuelos v in vuelos)
            {
                Console.WriteLine("Codigo de vuelo: " + v.PCodigoVuelo);
                Console.WriteLine("Origen: " + v.POrigen);
                Console.WriteLine("Destino: " + v.PDestino);
                Console.WriteLine("Dias en los que se realiza ese vuelo: " + v.PDiasEnQueSeRelizaElVuelo);
                Console.WriteLine("Costos: " + v.PCostos);
                Console.WriteLine("Capacidad: " + v.PCapacidad);
                Console.WriteLine("Boletos Vendidos: " + v.PBoletosVendidos);
                Console.WriteLine("Numero de pasajeros: " + v.PNumeroDePasajeros);
                Console.WriteLine("Millas: " + v.PMillas);
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
        }

        private static void CompraBoleto()
        {
            string TieneClub = "";
            string NombrePasajero = "";
            int EdadPasajero = 0;
            string ClaveVuelo = "";
            int ClaveClubPremier = 0;
            bool existe = true;
            double millasVuelo = 0;
            Console.WriteLine("---Compra Boletos---");
            foreach (Vuelos v in vuelos)
            {
                int asientosdisponible = v.PCapacidad - v.PBoletosVendidos;
                if (asientosdisponible != 0)
                {
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine("Vuelo: "+v.PCodigoVuelo);
                    Console.WriteLine("Origen: "+v.POrigen);
                    Console.WriteLine("Destino: "+v.PDestino);
                    Console.WriteLine("Asientos disponibles: "+asientosdisponible);
                    Console.WriteLine("------------------------------------------------");
                }
            }
            do
            {
                Console.Write("Escoja un vuelo: ");
                ClaveVuelo =  Console.ReadLine();
                if (existeVuelos(ClaveVuelo))
                {
                    Console.Write("Escoja un vuelo valido.");
                    ClaveVuelo = "";
                }
            } while (ClaveVuelo == "");

            millasVuelo = MillasVuelo(ClaveVuelo);
            do
            {
                Console.Write("¿Tiene club premier?");
                Console.Write("SI/NO:");
                TieneClub = Console.ReadLine();
                TieneClub = TieneClub.ToUpper();
                if (TieneClub != "SI" && TieneClub != "NO")
                {
                    Console.WriteLine("Favor de constestar Si o No");
                }
                
            } while (TieneClub != "SI" && TieneClub != "NO");
            
            if(TieneClub == "SI")
            {
                do
                {
                    Console.WriteLine("Clave club premier: ");
                    ClaveClubPremier = Convert.ToInt32(Console.ReadLine());
                    if (!existeClaveClubPremier(ClaveClubPremier))
                    {
                        Console.WriteLine("La clave club premier no exite.");
                        ClaveClubPremier = 0;
                        existe = false;
                        break;
                    }
                } while (ClaveClubPremier == 0);
                if(existe)
                {
                    foreach (int c in Club.Keys)
                    {
                        if (c == ClaveClubPremier)
                        {
                            NombrePasajero = Club[ClaveClubPremier].pNombre;
                            Club[ClaveClubPremier].pMillasAcumuladas += millasVuelo;
                        }
                    }
                    do
                    {
                        try
                        {
                            Console.Write("Edad del pasajero: ");
                            EdadPasajero = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Escriba una edad valida.");
                            EdadPasajero = 0;
                        }
                    } while (EdadPasajero == 0);
                    Boleto b = new Boleto(ClaveBoleto, NombrePasajero, EdadPasajero, ClaveVuelo, ClaveClubPremier);
                    boletos.Add(ClaveBoleto,b);
                    ClaveBoleto++;
                }

            }
            else
            {
                do
                {
                    Console.Write("Nombre pasajero: ");
                    NombrePasajero = Console.ReadLine();
                } while (NombrePasajero == "");

                do
                {
                    try
                    {
                        Console.Write("Edad del pasajero: ");
                        EdadPasajero = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Escriba una edad valida.");
                        EdadPasajero = 0;
                    }
                } while (EdadPasajero == 0);
                Boleto b = new Boleto(ClaveBoleto, NombrePasajero, EdadPasajero, ClaveVuelo, ClaveClubPremier);
                boletos.Add(ClaveBoleto, b);
                ClaveBoleto++;
            }
        }

        private static double MillasVuelo(string claveVuelo)
        {
            foreach (Vuelos v in vuelos)
            {
                if (v.PCodigoVuelo == claveVuelo)
                {
                    return v.PMillas;
                }
            }
            return 0;
        }

        private static void AltaClubPremier()
        {
            string Nombre = "";
            string Domicilio = "";
            double MillasAcumuladas = 0.0;
            Console.WriteLine("---Alta Club Premier---");
            do
            {
                Console.Write("Nombre: ");
                Nombre = Console.ReadLine();
            } while (Nombre == "");
            do
            {
                Console.Write("Domicilio: ");
                Domicilio = Console.ReadLine();
            } while (Domicilio=="");
            ClubPremier c = new ClubPremier(Nombre, Domicilio, MillasAcumuladas);
            Club.Add(ClaveClubPremier, c);
            ClaveClubPremier++;
            Console.WriteLine("Alta exitosa.");
            Console.Write("Precione cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();
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
            Console.Clear();
            Console.WriteLine("---Alta vuelos---");
            do
            {
                Console.Write("Codigo del Vuelo: ");
                CodigoVuelo = Console.ReadLine();
                if (existeVuelos(CodigoVuelo))
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
                Console.Write("En que dias de la semana se realiza este vuelo(Diaria, Lunes, Martes, Etc.): ");
                DiasEnQueSeRelizaElVuelo = Console.ReadLine();

            } while (DiasEnQueSeRelizaElVuelo == "");
            Vuelos v = new Vuelos(CodigoVuelo, NumeroDePasajeros,Origen,Destino,Capacidad,BoletosVendidos,Costos,Millas,DiasEnQueSeRelizaElVuelo);
            vuelos.Add(v);
            Console.Clear();
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
            Console.Clear();
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

        static bool existeClaveClubPremier(int claveC)
        {
            foreach (int c in Club.Keys)
            {
                if (c == claveC)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
