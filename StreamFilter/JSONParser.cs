using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamFilter
{
    class JSONParser
    {
        //Converts a single json object to a dictionar ; Example : { "signal" : "ATL" , "signal_value":"10", "signal_type":"integer" } 
        //                                             ; Resulting dictionary will have three elements with "signal","signal_value","signal_type" as keys 
        //                                             ; and their corresponding values
        public static Dictionary<string, string> JSONToDict(string jsonElement)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string t1 = jsonElement.Replace("{", ""); t1 = t1.Replace("}", ""); t1 = t1.Replace("[", ""); t1 = t1.Replace("]", "");
            string[] t2 = t1.Split(',');
            for (int i = 0; i < t2.Length; i++)
            {
                string[] keyValSplit = t2[i].Split(':');
                try
                {
                    result.Add(keyValSplit[0], keyValSplit[1]);
                }
                catch (Exception e)
                {

                }
            }
            return result;
        }
        //An array of json objects will be converted to an list of dictionaries representing each json objects
        public static List<Dictionary<string, string>> JSONArrayToDict(String jsonString)
        {
            //Remove []
            List<Dictionary<string, string>> test = new List<Dictionary<string, string>>();
            Dictionary<string, string> local = new Dictionary<string, string>();
            String rp1 = jsonString.Replace("[", "");
            rp1 = rp1.Replace("]", "");
            string[] elements = rp1.Split('}');
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] += "}";
                local = JSONToDict(elements[i]);
                test.Add(local);
            }
            return test;

        }
    }
}
