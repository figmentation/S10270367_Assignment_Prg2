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
        internal class Terminal
        {
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
                string[] code = flight.FlightNumber.Split(' ');
                foreach (Airline airline in Airlines.Values)
                {
                    if (code[0] == airline.Code)
                    { return airline; }
                }
                return null;
            }

        }
    } 
        
