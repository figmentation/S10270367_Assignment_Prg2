using Assignment_Prg2;
using System.Numerics;

//==========================================================
// Student Number : S10270367
// Student Name : Chong Yu Keat Jack
// Partner Name : Fang Yu Xuan 
//==========================================================

void LoadAirlines() 
{
    using(StreamReader reader = new StreamReader("airlines.csv"))
    {
        string? g;
        reader.ReadLine();
        while ((g = reader.ReadLine()) != null)
        {
            string[] phoneData = g.Split(',');
            if (phoneData.Length >= 3)
            {
                phoneList.Add(new Phone(Convert.ToString(phoneData[0]), Convert.ToInt32(phoneData[1]), Convert.ToString(phoneData[2])));

            }
        }
    }
}