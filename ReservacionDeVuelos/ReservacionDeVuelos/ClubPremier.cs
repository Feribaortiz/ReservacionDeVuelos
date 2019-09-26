using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionDeVuelos
{
    class ClubPremier
    {
        string Nombre;
        string Domicilio;
        double MillasAcumuladas;

        public ClubPremier(string nombre, string domicilio, double millasAcumuladas)
        {
            Nombre = nombre;
            Domicilio = domicilio;
            MillasAcumuladas = millasAcumuladas;
        }

        public string pNombre
        {
            set
            {
                Nombre = value;
            }
            get
            {
                return Nombre;
            }
        }

    }
}
