using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Runtime.InteropServices;

class MainClass
{

    static void Main()
    {

        WebClient client = new WebClient();
        string s = client.DownloadString("https://coderbyte.com/api/challenges/json/json-cleaning");
        Console.WriteLine(s);

        JObject converted = JsonConvert.DeserializeObject<JObject>(s);
        dynamic jsonDynamic = JObject.Parse(s);

        if (converted != null)
        {
            Dictionary<string, string> keyValueMap = new Dictionary<string, string>();
            foreach ( KeyValuePair<string, JToken> keyValuePair in converted ) {
                keyValueMap.Add(keyValuePair.Key, keyValuePair.Value.ToString());
            }
            var keys = keyValueMap.Keys.ToArray();
            for( int i = 0; i < keys.Length; i++ )
            {

                var check = jsonDynamic[keys[i]];
                if (check.ToString() == "-")
                {
                    jsonDynamic.Remove(keys[i]);
                }
                else
                {
                    RemoveProperty(jsonDynamic[keys[i]]);
                }   
            }
            //var current = (0, 0);
            Console.WriteLine(jsonDynamic);
        }
    }

    static void RemoveProperty(dynamic node)
    {
        bool removed = true;
        while (removed)
        {
            try
            {

               
                foreach (var item in node)
                {
                     
                    if (item.Value.ToString() == "" || item.Value.ToString() == "N/A" || item.Value.ToString()=="-" )
                    {
                        item.Remove();
                        removed = true;
                        break;
                    }
                    else
                        removed = false;
                }
            }
            catch (Exception)
            {
                removed = false;
            }
        }
    }

    



}