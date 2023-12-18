using FormulaDefinition;
using FormulaDefinition.Class.Operators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeorVer_MaxSAT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string Negative = new NegativeOperators().Symbols.First();
        private string Or = new OrOperators().Symbols.First();
        private string And = new AndOperators().Symbols.First();

        private void VerAlg_applyBtn_Click(object sender, EventArgs e)
        {
            VerAlg_True_listBox.Items.Clear();
            VerAlg_False_listBox.Items.Clear();

            var knv = KNF_textBox.Text;
            if(int.TryParse(VerAlg_TryCount_K.Text, out int k))
            {
                //взяли пользовательское к
            }
            else
            {
                k = 3;
                VerAlg_TryCount_K.Text = k.ToString();
            }

            try
            {
                var timer = new Stopwatch();

                var disUncList = new List<Formula>();
                foreach(var f in knv.Split(new string[] { And },StringSplitOptions.RemoveEmptyEntries))
                {
                    var formula = Formula.Load(f);
                    disUncList.Add(formula);
                }

                var variables = disUncList.SelectMany(d => d.GetPropozVariables()).ToHashSet();
                var maxTrueCount = 0;
                var maxTruePropozValues = new Dictionary<string, bool>();
                var trueDisuncts = new List<Formula>();
                var falseDisuncts = new List<Formula>();

                timer.Start();
                for (var i = 0; i < k; i++)
                {
                    var proposizValues = GetRandomValues(variables);
                    var tempTrueResult = new List<Formula>();
                    var tempFalseDisuncts = new List<Formula>();

                    var tempTrueCount = 0;
                    foreach(var item in disUncList)
                    {
                        var success = item.ComputeValueByVariables(proposizValues);
                        if (success)
                        {
                            tempTrueCount++;
                            tempTrueResult.Add(item);
                        }
                        else
                        {
                            tempFalseDisuncts.Add(item);
                        }
                    }

                    //заполнение более подходящий данных
                    if(tempTrueCount > maxTrueCount)
                    {
                        maxTrueCount = tempTrueCount;
                        maxTruePropozValues = proposizValues;
                        trueDisuncts = tempTrueResult;
                        falseDisuncts = tempFalseDisuncts;
                    }
                }
                timer.Stop();

                //вывод
                PrintToForm(maxTruePropozValues, trueDisuncts,falseDisuncts, timer.Elapsed);
            }
            catch(Exception ex)
            {

            }
        }

        private Dictionary<string,bool> GetRandomValues(HashSet<string> variables)
        {
            var dict = new Dictionary<string, bool>();

            foreach(var item in variables)
            {
                var value = RandomBool();

                dict.Add(item, value);
            }
            return dict;
        }

        private bool RandomBool()
        {
            var result = Rangom(0, 2);
            return result == 1;
        }

        private int Rangom(int left,int right)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var result = rnd.Next(left, right);
            return result;
        }

        private static Regex SkobkiRegex = new Regex(@"\(|\)");
        /// <summary>
        /// Выводит на форму полученный результат
        /// </summary>
        /// <param name="allDisuncts"></param>
        /// <param name="trueDisuncts"></param>
        private void PrintToForm(Dictionary<string,bool> postanovka,List<Formula> trueDisuncts, List<Formula> falseDisuncts, TimeSpan time)
        {
            VerAlg_time.Text = time.ToString();

            var trueCount = trueDisuncts.Count;
            VerAlg_trueCountLabel.Text = trueCount.ToString();

            var falseCount = falseDisuncts.Count;
            VerAlg_falseCountLabel.Text = falseCount.ToString();

            VerAlg_True_listBox.Items.Clear();

            //нет смысла выводить больше - зависает
            var maxPrintCount = 1024;
            var limitToPrintTrue = trueCount > maxPrintCount ? maxPrintCount : trueCount;
            for (var i = 0; i < limitToPrintTrue; i++)
            {
                var d = trueDisuncts[i];
                VerAlg_True_listBox.Items.Add(new ListViewItem() { Text = SkobkiRegex.Replace(d.ToString(), "") });
            }

            //нет смысла выводить больше - зависает
            var limitToPrintFalse = falseCount > maxPrintCount ? maxPrintCount : falseCount;
            for (var i = 0; i < limitToPrintFalse; i++)
            {
                var d = falseDisuncts[i];
                VerAlg_False_listBox.Items.Add(new ListViewItem() { Text = SkobkiRegex.Replace(d.ToString(), "") });
            }

            VerAlgPodstanovka.Text = $"{{{String.Join("; ", postanovka.Select(p=>$"{p.Key}={(p.Value ? 1: 0)}").OrderBy(x => x))}}}";
        }

        /// <summary>
        /// Сгенерировать КНФ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateBtn_Click(object sender, EventArgs e)
        {
            var success = int.TryParse(NCountTextBox.Text, out int n);

            if (!success || n < 1 || n > 100)
            {
                MessageBox.Show("Требование к n ( n = (1,100))");
                return;
            }

            var knv = GenerateKnf((int)Math.Pow(2,n) - 1,n);
            KNF_textBox.Text = knv;
        }

        private string GenerateKnf(int disunsCount,int variablesCount)
        {
            var disuncs = new List<string>();
            for (var i = 0; i < disunsCount; i++)
            {
                var curDisunct = GenerateDisunct(variablesCount);
                //с очень маленькой вероятностью могло получиться, что все элементы в дизьюнкции были пропущены
                if (curDisunct.Length != 0)
                {
                    disuncs.Add(curDisunct);
                }

            }

            var result = String.Join($"{And}", disuncs);
            return result;
        }
        /// <summary>
        /// формирует случайную дизьюнкцию по заданному набору пропозициональных переменных
        /// </summary>
        /// <param name="variablesCount"></param>
        /// <returns></returns>
        private string GenerateDisunct(int variablesCount)
        {
            var x = "x";

            var result = "";

            for (var i = 0; i < variablesCount; i++)
            {
                //случайно пропускаем элемент
                if (RandomBool())
                {
                    continue;
                }
                var newItem = $"{(RandomBool() ? Negative : "")}{x}{i}";
                
                if (result.Length > 0)
                {
                    result = $"({result}{Or}{newItem})";
                }
                else
                {
                    result = newItem;
                }
            }

            return result;
        }
    }
}
