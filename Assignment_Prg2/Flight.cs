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
    class Flight
    {
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ExpectedTime { get; set; }
        public string Status { get; set; } = "Scheduled";

        public Flight(string flightNumber, string origin, string destination, DateTime expectedTime) 
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
        }

        //public abstract double CalculateFees() 

        public override string  ToString() 
        {
            return "Flight Number" + FlightNumber + "Origin" + Origin + "Destination" + Destination + "Expected Time" + ExpectedTime + "Status" + Status;
        }
    }
}
