using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaDefinition.Class.Operators
{
    public abstract class OperatorBase
    {
        public abstract IEnumerable<string> Symbols { get; }
        public override string ToString()
        {
            return String.Join("|", Symbols);
        }
    }
}
