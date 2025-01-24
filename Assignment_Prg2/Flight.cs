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
    abstract class Flight
    {
        public string MyProperty { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ExpectdTime { get; set; }
        public string Status { get; set; }

        public Flight(string myProperty, string origin, string destination, DateTime expectedTime, string status) 
        {
            MyProperty = myProperty;
            Origin = origin;
            Destination = destination;
            ExpectdTime = expectedTime;
            Status = status;
        }
        //public abstract double CalculateFees() 
       
        public string ToString() 
        {
            return "Property" + MyProperty + "Origin" + Origin + "Destination" + Destination + "Expected Time" + ExpectdTime + "Status" + Status;
        }
    }
}
