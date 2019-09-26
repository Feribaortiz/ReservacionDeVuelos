using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionDeVuelos
{
    class Ciudad
    {
        string claveciudad;
        string nombreciudad;
        string estado;

        public Ciudad(string ClaveCiudad, string NombreCiudad, string Estado)
        {
            claveciudad = ClaveCiudad;
            nombreciudad = NombreCiudad;
            estado = Estado;
        }

        public string pClaveCiudad
        {
            set
            {
                claveciudad = value;
            }
            get
            {
                return claveciudad;
            }
        }
        public string pNombreCiudad
        {
            set
            {
                nombreciudad = value;
            }
            get
            {
                return nombreciudad;
            }
        }
        public string pEstado
        {
            set
            {
                estado = value;
            }
            get
            {
                return estado;
            }
        }
    }
}
