using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaDefinition
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFormula = File.ReadAllText("input.txt");
            Console.WriteLine(Formula.ItIsFormula(inputFormula));
        }
    }
}
