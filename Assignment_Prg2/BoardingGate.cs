using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//==========================================================
// Student Number : S10270367
// Student Name : Chong Yu Keat Jack
// Partner Name : Fang Yu Xuan 
// Partner Number : S1026700
//========================================================== 

namespace Assignment_Prg2
{
    class BoardingGate
    {  
        public string GateName { get; set; }
        public bool SupportsCFFT { get; set; }
        public bool SupportDDJB { get; set; }
        public bool SupportLWTT { get; set; }
        public Flight Flight { get; set; } = null;

        public BoardingGate(string gateName, bool supportsCFFT, bool supportsDDJB, bool supportsLWTT)
        {
            GateName = gateName;
            SupportsCFFT = supportsCFFT;
            SupportDDJB = supportsDDJB;
            SupportLWTT = supportsLWTT;
        }

        //public double CalculateFees()
        //{ 

        //}

        public override string ToString() 
        {
            return "Gate Name:" + GateName + "SupportsCFFT" + SupportsCFFT+ "SupportDDJB" + SupportDDJB + "SupportLWTT" + SupportLWTT;
        }
    }
}

