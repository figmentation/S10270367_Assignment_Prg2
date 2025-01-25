using Assignment_Prg2;
using Assignment_Prg2.prgassm;
using System.Numerics;

//==========================================================
// Student Number : S10270367
// Student Name : Chong Yu Keat Jack
// Partner Name : Fang Yu Xuan 
//========================================================== 
Terminal terminal = new Terminal ("Changi Terminal 5");
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
                           
            }
        }
    }
}


// feature 2 : load flights 

void LoadFlights()
{
    using (StreamReader reader = new StreamReader("airlines.csv"))
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
                Flight flight = new Flight(flightNumber, origin, destination, expectedTime, status);
                terminal.Flights.Add(flightNumber, flight);
            }
            else
            {
            
            }
        }
    }

}