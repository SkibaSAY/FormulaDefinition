﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaDefinition.Class.Operators
{
    class ImplicationOperators : OperatorBase
    {
        public override IEnumerable<string> Symbols => new List<string>(){ "→" };
    }
}