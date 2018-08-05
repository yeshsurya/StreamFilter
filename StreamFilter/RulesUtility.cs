using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamFilter
{
    class RulesUtility
    {
        //Method give true if the rule is valid else it returns false
        //Example : ATL1 value should not rise above 240.00 -> Rule1
        public static bool ValidateRule1(Rule test)
        {
            bool result = false;
            if (test.ValueType.Contains("Integer"))
            {
                if (test.Signal.Contains("ATL1") && test.Operator == "not above")
                {
                    test.Value = test.Value.Replace(" ", "");
                    test.Value = test.Value.Replace("\"", "");
                    test.Operand = test.Operand.Replace(" ", "");
                    test.Operand = test.Operand.Replace("\"", "");
                    var test_val = float.Parse(test.Value);
                    var threshod = float.Parse(test.Operand);
                    if (test_val > threshod)
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                }
            }
            if(test.ValueType.Contains("String"))
            {

            }
            if(test.ValueType.Contains("Datetime"))
            {

            }
          
            return result; 
        }
        public static List<Dictionary<string,string>> Filter(List<Dictionary<string,string>> payload , string rule )
        {
            List<Dictionary<string, string>> results = new List<Dictionary<string,string>>(); 
            switch (rule)
            {
                case "rule1": // 
                    foreach(var ele in payload)
                    {
                        try
                        {

                             //Rule local = new Rule(ele["signal"], ele["value"], ele["value_type"], "240", "not above");
                            Rule local = new Rule();
                            foreach(var ls in ele.Keys)
                            {
                                if (ls.Contains("signal")) { local.Signal = ele[ls]; }
                                if (ls.Contains("value")) { local.Value = ele[ls]; }
                                if (ls.Contains("value_type")) { local.ValueType = ele[ls]; }
                                local.Operand = "240"; local.Operator = "not above"; 
                            }
                            if (ValidateRule1(local))
                            {
                                results.Add(ele);
                            }
                        }
                        catch (Exception e) { }
                        
                    }
                    break;
                case "rule2": //
                    break;
                default: //
                    break; 
            }
            return results; 
        }
    
    }
}
