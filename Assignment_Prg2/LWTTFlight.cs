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
    internal class LWTTFlight : Flight 
    {
        public double RequestFee { get; set; }

        //public double CalculateFees()
        

        public string ToString()
        {
            return "Property" + MyProperty + "Origin" + Origin + "Destination" + Destination + "Expected Time" + ExpectdTime + "Status" + Status;
        }

        public LWTTFlight(string myProperty, string origin, string destination, DateTime expectedTime, string status) : base(myProperty, origin, destination, expectedTime, status)
        {
            MyProperty = myProperty;
            Origin = origin;
            Destination = destination;
            ExpectdTime = expectedTime;
            Status = status;
        }
    }
}
