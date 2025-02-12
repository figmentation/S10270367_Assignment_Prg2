﻿using System;
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
    class Airline
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public Dictionary<string, Flight> Flights { get; set; } = new Dictionary<string, Flight>();

        public Airline(string name, string code)
        {
            Name = name;
            Code = code;
        }

        public bool AddFlight(Flight flights)
        {
            if (!Flights.ContainsKey(flights.FlightNumber))
            {
                Flights.Add(flights.FlightNumber, flights);
                return true;
            }
            return false;
        }

        public bool RemoveFlight(Flight flights)
        {
            if (Flights.ContainsKey(flights.FlightNumber))
            {
                Flights.Remove(flights.FlightNumber);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "Name:" + Name + "Code:" + Code; 
        }

    }
}
