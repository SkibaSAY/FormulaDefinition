using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaDefinition.Class.Operators
{
    class ImplicationOperators : OperatorBase
    {
        public override IEnumerable<string> Symbols => new List<string>(){ "→" };
        public override bool ComputeValue(params bool[] values)
        {
            var result = values[0];
            for (var i = 1; i < values.Length; i++)
            {
                result = !result || values[i];
            }
            return result;
        }
    }
}
