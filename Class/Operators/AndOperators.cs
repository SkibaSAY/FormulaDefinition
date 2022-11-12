using FormulaDefinition.Class.Operators;
using System.Collections.Generic;

namespace FormulaDefinition
{
    public class AndOperators : OperatorBase
    {
        public override IEnumerable<string> Symbols => new List<string>(){ "∧","&","•" };

        public override bool ComputeValue(params bool[] values)
        {
            var result = values[0];
            for(var i = 1; i < values.Length; i++)
            {
                result = result && values[i];
            }
            return result;
        }
    }
}