using System;
using System.Linq;

class MainClass
{

    public static string GasStation(string[] strArr)
    {

        int Count = strArr.Length;
        string[] myStations = new string[Count - 1];
        Array.Copy(strArr, 1, myStations, 0, Count - 1);
        int[] gas = new int[Count - 1];
        int[] station = new int[Count - 1];

        for (int i = 0; i < myStations.Count(); i++)   //Populating my 2 arrays to parse into int[][][]
        {
            var tempg = myStations[i].Split(':').First();
            gas[i] = int.Parse(tempg);
            station[i] = int.Parse(myStations[i].Split(':').Last());

        }
        var result = Cancomplete(gas, station);

        if (result == -1)
        {
            return "impossible";
        }
        else
        {
            return (result + 1).ToString();//the solution array of my copy is smaller than the origianl array since I removed the index.
        }

    }

    static void Main()
    {

        // keep this function call here
        Console.WriteLine(GasStation(Console.ReadLine()));

    }

    public static int Cancomplete(int[] gasstations, int[] costs)
    {
        if (gasstations.Sum() < costs.Sum())
        {          //if the current choice will nto be possible
            return -1;
        }

        int reserve = 0;
        int total = 0;


        for (int i = 0; i < gasstations.Length; i++)
        {
            total += gasstations[i] - costs[i];

            if (total < 0)
            {
                total = 0;
                reserve = i + 1;
            }
        }

        return reserve;
    }

}//this is weighted graph to traverse all nodes in a circular fashion
 //we can use the dijstras algorith to calculate this for the cycle
 //have done a similar one just need to clean up my input,
 //need to create a dictionariry <Node>{gas,gastravel} for each node