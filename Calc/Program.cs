using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("КАЛЬКУЛЯТОР\t Поддерживаются: + - * / ( )\tДля выхода введите \"exit\"");
            Console.Write("Введите выражение: ");
            string input = Console.ReadLine();
            double result = 0.0f;
            do
            {   
                Stack_calc st = new Stack_calc(input.Trim());
                result = st.CalcPolNot();
                if (st.Error == false)
                    Console.WriteLine("Результат: {0}", result);
                else {
                    st.Error = false;
                }
                input = Console.ReadLine();
            } while (input != "exit") ;
            Console.WriteLine("До свидания!");

        }
    }
}

