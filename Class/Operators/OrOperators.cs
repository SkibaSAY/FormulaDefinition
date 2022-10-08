using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaDefinition.Class.Operators
{
    public class OrOperators : OperatorBase
    {
        public override IEnumerable<string> Symbols => new List<string>(){ "∨" };
    }
}
