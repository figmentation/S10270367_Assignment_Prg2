using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//==========================================================
// Student Number : S10270367
// Student Name : Chong Yu Keat Jack
// Partner Name : Fang Yu Xuan 
//==========================================================

namespace Assignment_Prg2
{
    internal class CFFTFlight : Flight
    {
        public double RequestFee { get; set; }

        //public double CalculateFees() 
        


        public string ToString() 
        {
            return "Flight Number" + FlightNumber + "Origin" + Origin + "Destination" + Destination + "Expected Time" + ExpectdTime + "Status" + Status;
        }

        public CFFTFlight(string flightNumber, string origin, string destination, DateTime expectedTime) : base(flightNumber, origin, destination, expectedTime)
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
        }
    }
}
