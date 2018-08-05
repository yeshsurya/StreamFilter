using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamFilter
{
    class Rule
    {
        string signal;
        string _value;
        string value_type;
        string _operator;
        string _operand;
        public Rule() { }
        public Rule(string sig , string _val,string val_type,string op,string oprnd)
        {
            signal = sig; _value = _val; value_type = val_type; _operator = op; _operand = oprnd; 
        }
        public String Signal
        {
            get { return signal;  }
            set { signal = value; }
        }
        public String Value
        {
            get { return _value;  }
            set { _value = value; }
        }
        public String ValueType
        {
            get { return value_type;  }
            set { value_type = value; }
        }
        public String Operator
        {
            get { return _operator; }
            set { _operator = value;}
        }
        public String Operand
        {
            get { return _operand;  }
            set { _operand = value;  }
        }
    }
}
