using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//==========================================================
// Student Number : S10270367
// Student Name : Chong Yu Keat Jack
// Partner Name : Fang Yu Xuan 
//==========================================================

namespace Assignment_Prg2
{
    internal class DDJBFlight : Flight
    {
        public double RequestFee { get; set; }

        ///public override double CalculateFees()
        

        public string ToString()
        {
            return "Property" + MyProperty + "Origin" + Origin + "Destination" + Destination + "Expected Time" + ExpectdTime + "Status" + Status;
        }

        public DDJBFlight(string myProperty, string origin, string destination, DateTime expectedTime, string status) : base(myProperty, origin, destination, expectedTime, status)
        {
            MyProperty = myProperty;
            Origin = origin;
            Destination = destination;
            ExpectdTime = ExpectdTime;
            Status = status;
        }
    }
}
