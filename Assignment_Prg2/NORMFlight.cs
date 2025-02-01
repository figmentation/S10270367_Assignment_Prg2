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
    internal class NORMFlight : Flight
    {
        //public abstract double CalculateFees() 
       

        public string ToString() 
        {
            return "Flight Number" + FlightNumber + "Origin" + Origin + "Destination" + Destination + "Expected Time" + ExpectedTime + "Status" + Status;
        }

        public NORMFlight(string flightNumber, string origin, string destination, DateTime expectedTime,string status) : base(flightNumber, origin, destination, expectedTime, status) 
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            
        }
    }
}
