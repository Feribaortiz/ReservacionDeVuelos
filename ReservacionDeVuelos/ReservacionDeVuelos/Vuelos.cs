using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionDeVuelos
{
    class Vuelos
    {
        string CodigoVuelo;
        int NumeroDePasajeros;
        string Origen;
        string Destino;
        int Capacidad;
        int BoletosVendidos;
        int Costos;
        double Millas;
        string DiasEnQueSeRelizaElVuelo;


        public Vuelos(string codigovuelo, int numerodepasajeros, string origen, string destino, int capacidad, int boletosvendidos, int costos, double millas, string diasenqueserelizaelvuelo)
        {
            CodigoVuelo = codigovuelo;
            NumeroDePasajeros = numerodepasajeros;
            Origen = origen;
            Destino = destino;
            Capacidad = capacidad;
            BoletosVendidos = boletosvendidos;
            Costos = costos;
            Millas = millas;
            DiasEnQueSeRelizaElVuelo = diasenqueserelizaelvuelo;
        }

        public string PCodigoVuelo
        {
            set
            {
                CodigoVuelo = value;
            }
            get
            {
                return CodigoVuelo;
            }
        }
        public int PNumeroDePasajeros
        {
            set
            {
                NumeroDePasajeros = value;
            }
            get
            {
                return NumeroDePasajeros;
            }
        }
        public string POrigen
        {
            set
            {
                Origen = value;
            }
            get
            {
                return Origen;
            }
        }
        public string PDestino
        {
            set
            {
                Destino = value;
            }
            get
            {
                return Destino;
            }
        }
        public int PCapacidad
        {
            set
            {
                Capacidad = value;
            }
            get
            {
                return Capacidad;
            }
        }
        public int PBoletosVendidos
        {
            set
            {
                BoletosVendidos = value;
            }
            get
            {
                return BoletosVendidos;
            }
        }
        public int PCostos
        {
            set
            {
                Costos = value;
            }
            get
            {
                return Costos;
            }
        }
        public double PMillas
        {
            set
            {
                Millas = value;
            }
            get
            {
                return Millas;
            }
        }
        public string PDiasEnQueSeRelizaElVuelo
        {
            set
            {
                DiasEnQueSeRelizaElVuelo = value;
            }
            get
            {
                return DiasEnQueSeRelizaElVuelo;
            }
        }

    }
}
