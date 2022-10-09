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

            //Задача 1 формула или нет
            if (Formula.ItIsFormula(inputFormula))
            {
                Console.WriteLine(inputFormula+"  -формула");
            }
            else
            {
                Console.WriteLine(inputFormula + "  -не формула");
                return;
            }
            Console.WriteLine(Formula.ItIsFormula(inputFormula));

            //задача 2 КНФ и ДНФ
        }
    }
}
