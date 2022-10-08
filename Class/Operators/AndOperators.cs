using FormulaDefinition.Class.Operators;
using System.Collections.Generic;

namespace FormulaDefinition
{
    public class AndOperators : OperatorBase
    {
        public override IEnumerable<string> Symbols => new List<string>(){ "∧","&","•" };
    }
}