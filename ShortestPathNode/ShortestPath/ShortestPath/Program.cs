using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

class MainClass
{
    public static string GraphChallenge(string[] strArr)
    {
        int nodeC = Int32.Parse(strArr[0]);
        string[] nodes = new string[nodeC];
        int max = strArr.Length;

        Array.Copy(strArr, 1, nodes, 0, nodeC);     //building the nodes on the graph
        string[] connections = new string[max - nodeC - 1];

        Array.Copy(strArr, nodeC + 1, connections, 0, max - nodeC - 1);   //building the connections array 
        connections = CleanArr(connections);    //cleaning the array from -

        //can use a stack to check nodes viisted
        var Dict = BuildGraph(nodes, connections);
        Console.WriteLine(Dict["A"].ToString());
        //plan create a stack of all the nodes. pop the stack if the node is reached. if not, calc the max distance and pull it back int
        return strArr[0];

    }

    public static int[][] ReturnAsBit(Dictionary<string,List<string>> dict)
    {
        int[][] result = new int[dict.Count][];

        return result;
    }
    public static Dictionary<string,List<string>> BuildGraph(string[] nodes, string[] connections ) //building a basic hasmap for every node and its connections. 
    {
        Dictionary<string,List<string>> keyValuePairs = new Dictionary<string,List<string>>();

        foreach(string node in nodes )
        {
            keyValuePairs.Add(node, new List<string>());
        }

        foreach(string key in keyValuePairs.Keys)
        {
            for (int i = 0; i < connections.Length; i++)
            {          
                if (connections[i].Contains(key))
                {
                    var temp = connections[i].Replace(key.ToString(), "");
                    keyValuePairs[key].Add(temp);
                }
            }
        }
        return keyValuePairs;
    }

    public static int[] ReturnToInt(string[] input)
    {
        var length = input.Length;


    }

    public static string ShortestPath(Dictionary<string,List<string>> dict, string start, string end)
    {
        int iterations = 0; 
        var stack = new Stack<string>();
        
        
        int maxDistance = 0;
        int n = dict.Keys.Count;
        var keys = dict.Keys.ToList();

        for(int k = 0; k < n; k++)       //populating a stack
        {
            stack.Push(keys[k]);
        }
        

        //for (int i = 0; i <= n; i++)
        //{
        //    foreach (string conn in dict[keys[i]])
        //    {
                
        //    }
        //}



        string shortest = "A-B";

        return shortest;
    }

    public static string[] CleanArr(string[] strArr)
    {
        int max = strArr.Length;

        for (int i = 0;i < max;i++)
        {
            if (strArr[i].Contains("-"))
            {
                strArr[i]= strArr[i].Replace("-", "");
            }
        }
        return strArr;
    }
    static void Main()
    {
        var test = new string[] { "5", "A", "B", "C", "D", "F", "A-B", "A-C", "B-C", "C-D", "D-F" };
        var result = GraphChallenge(test);
      
    }



}


