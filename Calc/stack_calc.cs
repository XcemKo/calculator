using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    delegate double Func(double left, double right);
    struct MapOperation {
        static public double Dummy(double l, double r) { return 0.0f; }
        static private double Sum(double l, double r) { return l + r; }
        static private double Minus(double l, double r) { return l- r; }
        static private double Mult(double l, double r) { return l * r; }
        static private double Div(double l, double r) { return r / l; } // обратная запись т.к. берется из стэка в другом порядке

        static public Dictionary<string, Func> Map = new Dictionary<string, Func> 
        {
            {"+", Sum },
            {"-", Minus },
            {"*", Mult },
            {"/", Div },

            {"(", null},
            {")", null }
        };
    }
    
    class Stack_calc{
        String[] mass_str;

        private int checkProirity(string oper) {
            int ret = 0;
            switch (oper)
            {
                case "+":
                case "-":
                    ret = 1; break;
                case "*":
                case "/":
                    ret = 2; break;
                case "(":
                case ")":
                    ret = 3; break;
            }
            return ret;
        }

        public Stack_calc(string _input) {
            mass_str = _input.Split().Where(s => s != String.Empty).ToArray<string>();
        }

        private string ConvertToPolish() {
            string outStack = "";
            double out_parse;
            Stack<string> st_oper = new Stack<string>();
            bool wait_bracket = false; ;
            foreach (var str in mass_str)
            {

                if (double.TryParse(str, out out_parse))
                {
                    outStack += str + " ";
                }
                else
                {
                    if (str.Length == 1) // оператор
                    {
                        if (!MapOperation.Map.ContainsKey(str))
                            throw new InvalidOperationException("Неверный оператор");
                        if (st_oper.Count == 0)
                            st_oper.Push(str);
                        else if (str == "(")
                        {
                            wait_bracket = true;
                            st_oper.Push(str);
                        } else if (str == ")")
                        {
                            while (st_oper.First() != "(")
                            {
                                if (st_oper.Count == 0)
                                    throw new IndexOutOfRangeException("Неверное количество скобок");
                                outStack += st_oper.Pop() + " ";
                            }
                            wait_bracket = false;
                            st_oper.Pop();
                        }
                        else if (checkProirity(str) > checkProirity(st_oper.First()))
                        {
                            st_oper.Push(str);
                        }
                        else
                        {   
                            if(st_oper.First() != "(")
                                outStack += st_oper.Pop() + " ";
                            st_oper.Push(str);
                        }
                    }
                    else
                        throw new InvalidOperationException("Неверный оператор");
                }
            }
            if (wait_bracket)
                throw new IndexOutOfRangeException("Неверное количество скобок");
            int size = st_oper.Count;
            while (size != 0) {
                outStack += st_oper.Pop() + " ";
                size--;
            }
            Console.WriteLine(outStack);
            return outStack.Trim(); ;
        }

        public double CalcPolNot() {
            
            Stack<double> st = new Stack<double>();
            try
            {
                mass_str = ConvertToPolish().Split();
            }
            catch (Exception e) {
                Console.WriteLine("{0} - ошибка",e.Message);
                return 0.0f;
            }
            
            for (int i=0;i< mass_str.Length;i++)
            {
                double num;
                string arg = mass_str[i];
                bool isNum = double.TryParse(arg, out num);
                if (isNum)
                    st.Push(num);
                else
                {
                    try
                    {
                        st.Push(MapOperation.Map[arg](st.Pop(), st.Pop()));
                    }
                    catch (Exception e) {
                        Console.WriteLine("{0} - ошибка", e.Message);
                        return 0.0f;
                    }
                }
            }
            return st.Pop();
        }

        public string Expression() {
            string ret = "";
            foreach (var el in mass_str) {
                ret += el + " ";
            }
            return ret;
        }
    }
}
