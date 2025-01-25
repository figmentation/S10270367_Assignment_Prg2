using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Prg2
{
    internal class BoardingGate
    {
        private string gateName;
        private bool supportsCFFT;
        private bool supportsDDJB;
        private bool supportsLWTT;
        private Flight flight;
        
        public string GateName { get; set; }
        public bool SupportsCFFT { get; set; }
        public bool SupportDDJB { get; set; }
        public bool SupportLWTT { get; set; }
        public Flight Flight { get; set; }

        public BoardingGate(string gateName, bool supportsCFFT, bool supportsDDJB, bool supportsLWTT, Flight flight)
        {
            GateName = gateName;
            SupportsCFFT = supportsCFFT;
            SupportDDJB = supportsDDJB;
            SupportLWTT = supportsLWTT;
            Flight = flight;

        }
            
        //public double CalculateFees()
        //{ 

        //}


    }
}
}
