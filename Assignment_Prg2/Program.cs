using Assignment_Prg2;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection.Emit;

//==========================================================
// Student Number : S10270367
// Student Name : Chong Yu Keat Jack
// Partner Name : Fang Yu Xuan 
// Partner Number : S1026700
//========================================================== 

//Jack 1,4,7 & 8    Yu Xuan 2,3,5,6 & 9//

Terminal terminal = new Terminal ("Changi Terminal 5");
LoadAirlines();
LoadBG();
LoadFlights();
Console.WriteLine($"Loading Airlines...\n{terminal.Airlines.Count()} Airlines Loaded!\nLoading Boarding Gates...\n{terminal.BoardingGates.Count()} Boarding Gates Loaded!\nLoading Flights...\n{terminal.Flights.Count()} Flights Loaded!");
Space();
void Space() 
{
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
}


while (true)
{
    try
    {
        Console.WriteLine("=============================================\nWelcome to Changi Airport Terminal 5\n=============================================\n1. List All Flights\n2. List Boarding Gates\n3. Assign a Boarding Gate to a Flight\n4. Create Flight\n5. Display Airline Flights\n6. Modify Flight Details\n7. Display Flight Schedule\n0. Exit");
        Console.WriteLine();
        Console.WriteLine("Please select your option: ");
        int UserOp = Convert.ToInt32(Console.ReadLine());
        if (UserOp == 1)
        {
            ListAllFlights();
            Space();
        }
        else if (UserOp == 2)
        {
            ListBoardingGates();
            Space();
        }
        else if (UserOp == 3)
        {
            AssignBGtoFlight();
            Space();
        }
        else if (UserOp == 4)
        {
            CreateFlight();
            Space();
        }
        else if (UserOp == 5)
        {
            DisplayAirlineFlights();
            Space();
        }
        else if (UserOp == 6)
        {
            ModifyFlightDetails();
            Space();
        }
        else if (UserOp == 7)
        {
            DisplayFLightSchedule();
            Space();
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
    catch (Exception) 
    {
        Console.WriteLine("Invalid Input.");
    }
}

//Feature 1 Load files (Airline) Jack//
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

//Feature 1 Load files (Boarding Gate) Jack//
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


//Feature 2 (Load Files (flights)) Yu Xuan//

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
                    DDJBFlight flight = new DDJBFlight(flightNumber, origin, destination, expectedTime, status);
                    terminal.Flights.Add(flightNumber, flight);
                }
                else if (flightData[4] == "LWTT")
                {
                    LWTTFlight flight = new LWTTFlight(flightNumber, origin, destination, expectedTime, status);
                    terminal.Flights.Add(flightNumber, flight);
                }
                else if (flightData[4] == "CFFT")
                {
                    CFFTFlight flight = new CFFTFlight(flightNumber, origin, destination, expectedTime, status);
                    terminal.Flights.Add(flightNumber, flight);
                }
                else
                {
                    NORMFlight flight = new NORMFlight(flightNumber, origin, destination, expectedTime, status);
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

//feature 3 (List all flights with basic info) Yu xuan//
void ListAllFlights() 
{
    Console.WriteLine($"============================================= \r\nList of Boarding Gates for Changi Airport Terminal 5\r\n=============================================");
    Console.WriteLine("Flight Number     Airline Name        Origin              Destination         Expected Departure");

    foreach (var f in terminal.Flights)
    {
        var airline = terminal.GetAirlineFromFlight(f.Value);
        string AirlineName = airline != null ? airline.Name : "Unknown"; ;
        Console.WriteLine($"{f.Value.FlightNumber,-18}{AirlineName,-20}{f.Value.Origin,-20}{f.Value.Destination,-20}{f.Value.ExpectedTime}");
    }
    return;
}

//feature 4 (List all boarding gates) Jack//
void ListBoardingGates() 
{
    Console.WriteLine($"=============================================\r\nList of Boarding Gates for Changi Airport Terminal 5\r\n=============================================");
    Console.WriteLine("Gate Name     DDJB        CFFT       LWTT");
    foreach (var bg in terminal.BoardingGates) 
    {
        Console.WriteLine($"{bg.Value.GateName,-14}{bg.Value.SupportDDJB,-12}{bg.Value.SupportsCFFT,-11}{bg.Value.SupportLWTT}");
    }
}

//Feature 5 (Assign a boarding gate to flight) Yu Xuan//
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
            Console.WriteLine($"Expected Time: {flight.ExpectedTime}");
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

//Feature 6 (Create new flight) Yu Xuan//
void CreateFlight() 
{
    while (true)
    {
        //string? status = ;
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
            newflight = new DDJBFlight(fn, org, dest, eta, Reqcode);
        }
        else if (Reqcode == "CFFT")
        {
            newflight = new CFFTFlight(fn, org, dest, eta, Reqcode);
        }
        else if (Reqcode == "LWTT")
        {
            newflight = new LWTTFlight(fn, org, dest, eta, Reqcode);
        }
        else
        {
            newflight = new NORMFlight(fn, org, dest, eta, Reqcode);
        }

        terminal.Flights.Add(fn, newflight);
        using (StreamWriter sw = new StreamWriter("flights.csv", true))
        {
            sw.WriteLine($"{fn},{org},{dest},{eta},{Reqcode}");
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

//Feature 7 (Display full flight details from an airline) Jack//
void DisplayAirlineFlights()
{
        Console.WriteLine("=============================================\r\nList of Airlines for Changi Airport Terminal 5\r\n=============================================\r\nAirline Code Airline Name");
        foreach (var ac in terminal.Airlines)
        {
            Console.WriteLine($"{ac.Value.Code}        {ac.Value.Name}");
        }
        Console.WriteLine("Enter Airline Code:");
        string? userAc = Console.ReadLine().ToUpper();
        if (userAc != "SQ" && userAc != "MH" && userAc != "JL" && userAc != "CX" && userAc != "QF" && userAc != "TR" && userAc != "EK" && userAc != "BA")
        {
            Console.WriteLine("Invalid. Enter another airline code");
        }
        else
        {
            Dictionary<string, Flight> airlinesflight = new Dictionary<string, Flight>(terminal.Flights);
            Console.WriteLine("=============================================\r\nList of Airlines for Changi Airport Terminal 5\r\n=============================================\r\n");
            Console.WriteLine("Airline Code     Airline Name       Origin          Destination        Expected");
            foreach (KeyValuePair<string, Flight> flights in airlinesflight)
            {
                Airline airlines = terminal.GetAirlineFromFlight(flights.Value);
                if (airlines != null && airlines.Code == userAc)
                {
                    Console.WriteLine($"{flights.Value.FlightNumber,-16} {airlines.Name,-19}{flights.Value.Origin,-16}{flights.Value.Destination,-19}{flights.Value.ExpectedTime}");
                }
            }
            return;
        }
}


//Feature 8 (Modify flight details) Jack//
void ModifyFlightDetails() 
{

    Console.WriteLine("=============================================\r\nList of Airlines for Changi Airport Terminal 5\r\n=============================================\r\nAirline Code Airline Name");
    bool flightdoesnotexist = false;
    Dictionary<string, Flight> airlinesflight = new Dictionary<string, Flight>(terminal.Flights);

    foreach (var ac in terminal.Airlines)
    {
        Console.WriteLine($"{ac.Value.Code}        {ac.Value.Name}");
    }

    Console.WriteLine("Enter Airline Code:");
    string? userAc = Console.ReadLine().ToUpper();

    if (userAc != "SQ" && userAc != "MH" && userAc != "JL" && userAc != "CX" && userAc != "QF" && userAc != "TR" && userAc != "EK" && userAc != "BA")
    {
        Console.WriteLine("Invalid. Enter another airline code");
    }
    else
    {
        Console.WriteLine("=============================================\r\nList of Airlines for Changi Airport Terminal 5\r\n=============================================\r\n");
        Console.WriteLine("Airline Code     Airline Name       Origin          Destination        Expected");

        foreach (KeyValuePair<string, Flight> flights in airlinesflight)
        {
            Airline airlines = terminal.GetAirlineFromFlight(flights.Value);
            if (airlines != null && airlines.Code == userAc)
            {
                Console.WriteLine($"{flights.Value.FlightNumber,-16} {airlines.Name,-19}{flights.Value.Origin,-16}{flights.Value.Destination,-19}{flights.Value.ExpectedTime}");
            }
        }
        flightdoesnotexist = true;
    }

    if (!flightdoesnotexist)
    {
        Console.WriteLine("No flights with that name. Try again");
        return;
    }

    Console.WriteLine("Choose an existing Flight to modify or delete:");
    string? userAC2 = Console.ReadLine().ToUpper();

    if (!terminal.Flights.ContainsKey(userAC2))
    {
        Console.WriteLine("Invalid flight number. Please add spacing e.g.(AB 123).");
        return;
    }
    else
    {
        Flight flight = terminal.Flights[userAC2];
    }

    Console.WriteLine("1. Modify Flight\r\n2. Delete Flight\r\nChoose an option:");
    string? userOp12 = Console.ReadLine();

    if (userOp12 != "1" && userOp12 != "2")
    {
        Console.WriteLine("Invalid input. Chose 1 or 2.");
    }

    if (userOp12 == "1")
    {
        DateTime userTime = DateTime.Now;
        Console.WriteLine("1. Modify Basic Information\r\n2. Modify Status\r\n3. Modify Special Request Code\r\n4. Modify Boarding Gate\r\nChoose an option");
        string? userOp1 = Console.ReadLine();

        if (userOp1 == "1")
        {
            Console.WriteLine("Enter new Origin: ");
            string? userOri = Console.ReadLine();
            Console.WriteLine("Enter new Destination: ");
            string? userDes = Console.ReadLine();
            Console.WriteLine("Enter new Expected Departure/Arrival Time (dd/mm/yyyy hh:mm): ");
            userTime = Convert.ToDateTime(Console.ReadLine());
            Flight flight = terminal.Flights[userAC2];

            string codes = " ";
            if (flight is NORMFlight)
            {
                codes = "NONE";
            }
            else if (flight is DDJBFlight)
            {
                codes = "DDJB";
            }
            else if (flight is CFFTFlight)
            {
                codes = "CFFT";
            }
            else if (flight is LWTTFlight)
            {
                codes = "LWTT";
            }
            string gateNum = " ";
            foreach (var bg in terminal.BoardingGates)
            {
                if (bg.Value.Flight == null)
                {
                    gateNum = "Unassigned";
                }
                else
                {
                    gateNum = bg.Value.GateName;
                }
            }

            string airline = terminal.GetAirlineFromFlight(flight).Name;
            flight.Origin = userOri;
            flight.Destination = userDes;
            flight.ExpectedTime = userTime;
            Console.WriteLine("Flight Updated!");
            Console.WriteLine($"Flight Number: {userAC2}\r\nAirline Name: {airline}\r\nOrigin: {userOri}\r\nDestination: {userDes}\r\nExpected Departure/Arrival Time: {userTime}\r\nStatus: {flight.Status}\r\nSpecial Request Code: {codes}\r\nBoarding Gate: {gateNum}");
        }
        else if (userOp1 == "2")
        {
            Console.WriteLine($"Modifying status for {userAC2}");
            Console.WriteLine("1. Delayed\r\n2. Boarding\r\n3. On Time\r\nPlease select the new status of the flight: ");
            string userStat = Console.ReadLine();
            if (userStat == "1")
            {
                terminal.Flights[userAC2].Status = "Delayed";
            }
            else if (userStat == "2")
            {
                terminal.Flights[userAC2].Status = "Boarding";
            }
            else if (userStat == "3")
            {
                terminal.Flights[userAC2].Status = "On Time";
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
                return;
            }
        }
        else if (userOp1 == "3")
        {
            Console.WriteLine($"Modifying speacial request code for {userAC2}");
            Console.WriteLine("Input a new special request code: ");
            string? userSrq = Console.ReadLine().ToUpper();
            if (userSrq != "CFFT" && userSrq != "LWTT" && userSrq != "NONE" && userSrq != "DDJB")
            {
                Console.WriteLine("Invalid code try (CFFT,LWTT,DDJB or None)");
            }
            if (userSrq == "NONE")
            {
                userSrq = "None";
            }
            Flight flight = terminal.Flights[userAC2];
            terminal.Flights.Remove(userAC2);
            if (userSrq == "CFFT")
            {
                flight = new CFFTFlight(userAC2, flight.Origin, flight.Destination, flight.ExpectedTime, flight.Status);
                terminal.Flights.Add(userAC2, flight);
            }
            if (userSrq == "LWTT")
            {
                flight = new LWTTFlight(userAC2, flight.Origin, flight.Destination, flight.ExpectedTime, flight.Status);
                terminal.Flights.Add(userAC2, flight);
            }
            if (userSrq == "DDJB")
            {
                flight = new DDJBFlight(userAC2, flight.Origin, flight.Destination, flight.ExpectedTime, flight.Status);
                terminal.Flights.Add(userAC2, flight);
            }
            else
            {
                flight = new NORMFlight(userAC2, flight.Origin, flight.Destination, flight.ExpectedTime, flight.Status);
                terminal.Flights.Add(userAC2, flight);
            }
        }
        else if (userOp1 == "4")
        {
            Console.WriteLine("Enter boarding Gate Name");
            string? boardingGateName = Console.ReadLine();

            if (!terminal.BoardingGates.ContainsKey(boardingGateName))
            {
                Console.WriteLine("Invalid boarding gate. Please try again.");
                return;
            }

            BoardingGate gate = terminal.BoardingGates[boardingGateName];

            if (gate.Flight != null)
            {
                Console.WriteLine($"Boarding Gate {gate.GateName} is already assigned to Flight {gate.Flight.FlightNumber}. Please choose a different gate.");
                return;
            }
            Console.WriteLine($"Boarding Gate Name: {gate.GateName}");
        }
    }
    else if (userOp12 == "2") 
    {
        Console.WriteLine($"Are you sure you want to delete {userAC2} [Y] to delete [N] to cancel Y/N?: ");
        string? userYN = Console.ReadLine().ToUpper();
        if (userYN == "Y")
        {
            terminal.Flights.Remove(userAC2);
            Console.WriteLine($"Flight {userAC2} has successfully been deleted.");
        }
        else if (userYN == "N") 
        {
            Console.WriteLine("Cancelling. Returning to menu.");
        }
    }


}


//Feature 9 (Display scheduled flights in chronological order, with boarding gate assignmetns where applicable) Yu Xuan//
void DisplayFLightSchedule() 
{
    
}


//Advanced Part a (Process all unassigned flights to boarding gates in bulk) Jack//

void ProcessFlights() 
{

}