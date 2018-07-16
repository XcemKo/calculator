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
            double a = 2;
            double b = 0;
            double c = -1;
            try
            {
                c = a / b;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine(c);
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

