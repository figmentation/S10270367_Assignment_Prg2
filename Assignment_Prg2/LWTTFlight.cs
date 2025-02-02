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
    class LWTTFlight : Flight 
    {
        public double RequestFee { get; set; }

        //public double CalculateFees()
        

        public string ToString()
        {
            return "Flight Number" + FlightNumber + "Origin" + Origin + "Destination" + Destination + "Expected Time" + ExpectedTime + "Status" + Status;
        }

        public LWTTFlight(string flightNumber, string origin, string destination, DateTime expectedTime) : base(flightNumber, origin, destination, expectedTime)
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
        }
    }
}
