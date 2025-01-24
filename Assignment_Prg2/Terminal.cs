using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Prg2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;

    namespace prgassm
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

            public Terminal(string terminalName, Dictionary<string, Airline> airlines=null, Dictionary<string, Flight> flights=null, Dictionary<string, BoardingGate> boardingGates=null, Dictionary<string, double> gateFees=null)
            {
                TerminalName = terminalName;
                Airlines = airlines=new Dictionary<string, Airline>();
                Flights = flights=new Dictionary<string, Flight>();
                BoardingGates = boardingGates=new Dictionary<string, BoardingGate>();
                GateFees = gateFees=new Dictionary<string, double>();
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
}

        
