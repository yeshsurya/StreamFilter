using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StreamFilter
{
    class Program
    {
        static void Main(string[] args)
        {

            String path = FileUtilities.GetFilePathAdjacentToModule("raw_data.json");
            if(File.Exists(path))
            {
                String jsonString = FileUtilities.ConvertStreamToString(path);
                List<Dictionary<string,string>> newDataSet = JSONParser.JSONArrayToDict(jsonString);
                List<Dictionary<string, string>> rule1Results = RulesUtility.Filter(newDataSet, "rule1");
                Console.WriteLine("Rule 1 results are out , count is {0}", rule1Results.Count);
            }
            Console.ReadKey();
        }
       
       
        
       
    }
}
