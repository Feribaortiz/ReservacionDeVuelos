using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionDeVuelos
{
    class Program
    {
        static void Main(string[] args)
        {
            int op = -1;
            Program p = new Program();
            do
            {
                try
                {
                    Console.WriteLine("Seleccione una opcion: ");
                    op = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Seleccione una opcion valida.");
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
                    default:
                        Console.WriteLine("Seleccione una opcion valida.");
                        break;
                }

            } while (op != -1);
        }

        private static void ConsulataVuelos()
        {
            
        }

        private static void CompraBoleto()
        {

        }

        private static void AltaClubPremier()
        {

        }

        private static void AltaVuelos()
        {
            
        }

        private static void AltaCiudades()
        {
            
        }
    }
}
