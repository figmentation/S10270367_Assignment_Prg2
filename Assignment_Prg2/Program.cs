using Assignment_Prg2;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

//==========================================================
// Student Number : S10270367
// Student Name : Chong Yu Keat Jack
// Partner Name : Fang Yu Xuan 
//========================================================== 
Terminal terminal = new Terminal ("Changi Terminal 5");
LoadAirlines();
LoadBG();
Console.WriteLine($"Loading Airlines...\n{terminal.Airlines.Count()} Airlines Loaded!\nLoading Boarding Gates...\n{terminal.BoardingGates.Count()} Boarding Gates Loaded!\nLoading Flights...\n{terminal.Flights.Count()} Flights Loaded!");

while (true)
{
    Console.WriteLine("=============================================\nWelcome to Changi Airport Terminal 5\n=============================================\n1. List All Flights\n2. List Boarding Gates\n3. Assign a Boarding Gate to a Flight\n4. Create Flight\n5. Display Airline Flights\n6. Modify Flight Details\n7. Display Flight Schedule\n0. Exit\nPlease select your option:");
    int UserOp = Convert.ToInt32(Console.ReadLine());
    if (UserOp == 1)
    {
        ListFlights();
    }
    else if (UserOp == 2)
    {
        ListBoardingGates();
    }
    else if (UserOp == 3)
    {
        AssignBGtoFlight();
    }
    else if (UserOp == 4)
    {
        CreateFlight();
    }
    else if (UserOp == 5)
    {
        DisplayAirlineFlights();
    }
    else if (UserOp == 6)
    {
        ModifyFlightDetails();
    }
    else if (UserOp == 7)
    {
        DisplayFLightSchedule();
    }
    else if (UserOp == 0)
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid option try again.");
    }
}

//Feature 1 Load files (Airline)//
void LoadAirlines() 
{
    using(StreamReader reader = new StreamReader("airlines.csv"))
    {
        string? g;
        reader.ReadLine();

        while ((g = reader.ReadLine()) != null)
        {
            string[] airlineData = g.Split(',');
            if (airlineData.Length >= 2)
            {
                
                Airline airline = new Airline(airlineData[0], airlineData[1]);
                terminal.Airlines.Add(airlineData[0], airline);
            }
            else 
            {
                Console.WriteLine($"Invalid data format in line: Skipping...");
            }
        }
    }
}

//Feature 1 Load files (Boarding Gate)//
void LoadBG() 
{
    using (StreamReader reader = new StreamReader("boardinggates.csv"))
    {
        string? g;
        reader.ReadLine();

        while ((g = reader.ReadLine()) != null)
        {
            string[] bgData = g.Split(',');
            if (bgData.Length >= 2)
            {

                BoardingGate boardginggate = new BoardingGate(bgData[0], Convert.ToBoolean(bgData[1]), Convert.ToBoolean(bgData[2]), Convert.ToBoolean(bgData[3]));
                terminal.BoardingGates.Add(bgData[0], boardginggate);
            }
            else
            {
                Console.WriteLine("Invalid data format in line: Skipping...");
            }
        }
    }
}


//Feature 2 (Load Files (flights))//

void LoadFlights()
{
    using (StreamReader reader = new StreamReader("flights.csv"))
    {
        string? line;
        reader.ReadLine();

        while ((line = reader.ReadLine()) != null)
        {
            string[] flightData = line.Split(',');
            if ((flightData.Length >= 5))
            {
                string flightNumber = flightData[0].Trim();
                string origin = flightData[1].Trim();
                string destination = flightData[2].Trim();
                DateTime expectedTime = DateTime.Parse(flightData[3].Trim());
                string status = flightData[4].Trim();
                if (flightData[4] == "DDJB")
                {
                    DDJBFlight flight = new DDJBFlight(flightNumber, origin, destination, expectedTime);
                    terminal.Flights.Add(flightNumber, flight);
                }
                else if (flightData[4] == "LWTT")
                {
                    LWTTFlight flight = new LWTTFlight(flightNumber, origin, destination, expectedTime);
                    terminal.Flights.Add(flightNumber, flight);
                }
                else if (flightData[4] == "CFFT")
                {
                    CFFTFlight flight = new CFFTFlight(flightNumber, origin, destination, expectedTime);
                    terminal.Flights.Add(flightNumber, flight);
                }
                else 
                {
                    NORMFlight flight = new NORMFlight(flightNumber, origin, destination, expectedTime);
                    terminal.Flights.Add(flightNumber, flight);
                }
            }
            else
            {
                Console.WriteLine("Invalid data format in line: Skipping...");
            }
        }
    }

}


//feature 3 (list all flights and information)
void ListFlights()
{
    Console.WriteLine($"============================================= \r\nList of Boarding Gates for Changi Airport Terminal 5\r\n=============================================");
    Console.WriteLine("Flight Number     Airline Name     Origin     Destination     Expected Departure");
    foreach ( var f in terminal.Flights )
    {
        string AirlineName = terminal.GetAirlineFromFlight(f.Value).Name;
        Console.WriteLine($"{f.Value.FlightNumber,-13}{AirlineName,-10}{f.Value.Origin,-10}{f.Value.Destination,-10}{f.Value.ExpectdTime,-10}");
    }
}

//feature 4 (List all boarding gates)//

void ListBoardingGates() 
{
    Console.WriteLine($"=============================================\r\nList of Boarding Gates for Changi Airport Terminal 5\r\n=============================================");
    Console.WriteLine("Gate Name     DDJB     CFFT     LWTT");
    foreach (var bg in terminal.BoardingGates) 
    {
        Console.WriteLine($"{bg.Value.GateName,-13}{bg.Value.SupportDDJB,-10}{bg.Value.SupportsCFFT,-10}{bg.Value.SupportLWTT,-10}");
    }
}

// feature 5 
void AssignBGtoFlight()
{
    Console.WriteLine("=============================================");
    Console.WriteLine("Assign a Boarding Gate to a Flight");
    Console.WriteLine("=============================================");
    Console.WriteLine("Enter flight number:");
    string flightNumber = Console.ReadLine();

    if (!terminal.Flights.ContainsKey(flightNumber))
    {
        Console.WriteLine("Flight number not found. Please try again.");
    }
    else
    {
        Flight flight = terminal.Flights[flightNumber];
        string boardingGateName;

        while (true)
        {
            Console.WriteLine("Enter boarding Gate Name");
            boardingGateName = Console.ReadLine();

            if (!terminal.BoardingGates.ContainsKey(boardingGateName))
            {
                Console.WriteLine("Invalid boarding gate. Please try again.");
                continue;
            }

            BoardingGate gate = terminal.BoardingGates[boardingGateName];

            if (gate.Flight != null)
            {
                Console.WriteLine($"Boarding Gate {gate.GateName} is already assigned to Flight {gate.Flight.FlightNumber}. Please choose a different gate.");
                continue;
            }

            gate.Flight = flight;

            Console.WriteLine($"Flight Number: {flight.FlightNumber}");
            Console.WriteLine($"Origin: {flight.Origin}");
            Console.WriteLine($"Destination: {flight.Destination}");
            Console.WriteLine($"Expected Time: {flight.ExpectdTime}");
            Console.WriteLine($"Special Request Code: {flight.GetType().Name}");
            Console.WriteLine($"Boarding Gate Name: {gate.GateName}");
            Console.WriteLine($"Supports DDJB: {gate.SupportDDJB}");
            Console.WriteLine($"Supports CFFT: {gate.SupportsCFFT}");
            Console.WriteLine($"Supports LWTT: {gate.SupportLWTT}");
            break;
        }

        Console.WriteLine("Would you like to update the status of the flight? (Y/N)");
        string updateStatus = Console.ReadLine().ToUpper();

        if (updateStatus == "Y")
        {
            Console.WriteLine("1. Delayed");
            Console.WriteLine("2. Boarding");
            Console.WriteLine("3. On Time");
            Console.WriteLine("Please select the new status of the flight:");

            string statusChoice = Console.ReadLine();

            switch (statusChoice)
            {
                case "1":
                    flight.Status = "Delayed";
                    break;
                case "2":
                    flight.Status = "Boarding";
                    break;
                case "3":
                    flight.Status = "On Time";
                    break;
                default:
                    Console.WriteLine("Invalid selection. Setting status to 'On Time'.");
                    flight.Status = "On Time";
                    break;
            }
        }
        else if (updateStatus == "N")
        {
            flight.Status = "On Time";
        }

        else
        {
            Console.WriteLine("Invalid input. Setting status to 'On Time'.");
            flight.Status = "On Time";
        }

        Console.WriteLine($"Flight {flight.FlightNumber} has been assigned to Boarding Gate {boardingGateName}!");
    }
}

//feature 6 

void CreateFlight()
{
    while (true)
    {
        string? status = ;
        Console.WriteLine("Enter Flight Number:");
        string? fn = Console.ReadLine();
        Console.WriteLine("Enter Origin:");
        string? org = Console.ReadLine();
        Console.WriteLine("Enter Destination:");
        string? dest = Console.ReadLine();
        Console.WriteLine("Enter Expected Departure / Arrival Time(dd / mm / yyyy hh: mm):");
        DateTime eta = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Enter Special Request Code (CFFT/DDJB/LWTT/None):");
        string? Reqcode = Console.ReadLine().ToUpper();

        Flight newflight;
        if (Reqcode == "DDJB")
        {
            newflight = new DDJBFlight(fn, org, dest, eta, status);
        }
        else if (Reqcode == "CFFT")
        {
            newflight = new CFFTFlight(fn, org, dest, eta, status);
        }
        else if (Reqcode == "LWTT")
        {
            newflight = new LWTTFlight(fn, org, dest, eta, status);
        }
        else
        {
            newflight = new NORMFlight(fn, org, dest, eta, status);
        }

        terminal.Flights.Add(fn, newflight);
        using (StreamWriter sw = new StreamWriter("flights.csv", true))
        {
            sw.WriteLine($"{fn},{org},{dest},{eta},{status},{Reqcode}");
        }

        Console.WriteLine($"Flight {newflight.FlightNumber} has been added.");
        Console.WriteLine("Would you like to add another flight? (Y/N)");
        string? addAnother = Console.ReadLine().ToUpper();

        if (addAnother != "Y")
        {
            break;
        }
    }
}



// feature 9 

void DisplayFLightSchedule()
{
    Console.WriteLine("=============================================");
    Console.WriteLine("Flight Schedule for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine("Flight Number    Airline Name      Origin     Destination    Expected Departure/Arrival Time   Status  Boarding Gate");

     List<Flight> sortedFlights = new List<Flight>(terminal.Flights.Values);
    sortedFlights.Sort();
    foreach (var flight in sortedFlights)
    {
        Console.WriteLine(flight);
    }
}






