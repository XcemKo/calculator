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

            Console.WriteLine("КАЛЬКУЛЯТОР");
            Console.WriteLine("Пожалуйста, введите числа и операторы через пробел. Разделитель дробной части \",\"");

            string input = Console.ReadLine();
            do
            {   
                Stack_calc st = new Stack_calc(input.Trim());
                Console.WriteLine("Результат: {0}",st.CalcPolNot());
                input = Console.ReadLine();
            } while (input != "exit") ;


        }
    }
}

