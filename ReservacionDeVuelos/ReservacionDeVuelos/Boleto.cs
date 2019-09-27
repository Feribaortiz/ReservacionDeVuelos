using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionDeVuelos
{
    class Boleto
    {
        int ClaveBoleto;
        string NombrePasajero;
        int EdadPasajero;
        string ClaveVuelo;
        int ClaveClubPremier;
        public Boleto(int claveboleto, string nombrepasajero, int edadpasajero, string clavevuelo, int claveclubpremier)
        {
            ClaveBoleto = claveboleto;
            NombrePasajero = nombrepasajero;
            EdadPasajero = edadpasajero;
            ClaveVuelo = clavevuelo;
            ClaveClubPremier = claveclubpremier;

        }

        public int pClavebBoleto
        {
            set
            {
                ClaveBoleto = value;
            }
            get
            {
                return ClaveBoleto;
            }
        }

        public string pNombrePasajero
        {
            set
            {
                NombrePasajero = value;
            }
            get
            {
                return NombrePasajero;
            }
        }

        public int pEdadPasajero
        {
            set
            {
                EdadPasajero = value;
            }
            get
            {
                return EdadPasajero;
            }
        }
        public string pClaveVuelo
        {
            set
            {
                ClaveVuelo = value;
            }
            get
            {
                return ClaveVuelo;
            }
        }

        public int pClaveClubPremier
        {
            set
            {
                ClaveClubPremier = value;
            }
            get
            {
                return ClaveClubPremier;
            }
        }


    }
}
