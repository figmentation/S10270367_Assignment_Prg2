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
        internal class Terminal
        {
            private string terminalName;
            private Dictionary<string, Airline> airlines;
            private Dictionary<string, Flight> flights;
            private Dictionary<string, BoardingGate> boardingGates;
            private Dictionary<string, double> gateFees;


            public string TerminalName { get; set; }


            public Dictionary<string, Airline> Airlines { get; set; } = new Dictionary<string, Airline>();
            public Dictionary<string, Flight> Flights { get; set; } = new Dictionary<string, Flight>();
            public Dictionary<string, BoardingGate> BoardingGates { get; set; } = new Dictionary<string, BoardingGate>();
            public Dictionary<string, double> GateFees { get; set; } = new Dictionary<string, double>();

            public Terminal(string terminalName)
            {
                TerminalName = terminalName;
              
            }

            public bool AddAirline(Airline airlines)
            {
                if (!Airlines.ContainsKey(airlines.Code))
                {
                    Airlines.Add(airlines.Code, airlines);
                    return true;
                }
                return false;
            }

            public bool AddBoardingGate(BoardingGate boardingGate)
            {
                if (!BoardingGates.ContainsKey(boardingGate.GateName))
                {
                    BoardingGates.Add(boardingGate.GateName, boardingGate);
                    return true;
                }
                return false;
            }

            public Airline GetAirlineFromFlight(Flight flight)
            {
                string airlineName = flight.FlightNumber.Split(" ")[0];
                return Airlines[airlineName];
            }

        }
    }
        
