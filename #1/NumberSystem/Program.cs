using System;

namespace NumberSystem
{
    internal class Program
    {
        static void ShowHeadInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Эта программа переводит число n в k-ичную систему счисления\n" +
                "и находит разность между произведением и суммой его цифр в СС.");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            int number = 0;
            int newNumber = 0;
            int numSystem = 0;
            int result = 0;

            Console.Clear();
            ShowHeadInfo();
            Console.WriteLine("Введите натуральное число в диапозоне [1..109].");
            number = EnterIntNumberInRange(1, 109);
            Console.WriteLine("Введите натуральное число, которое будет являться системой счисления. Диапозон [2..10].");
            numSystem = EnterIntNumberInRange(2, 10);
            newNumber = ConvertToNumberSystem(number, numSystem);
            Console.WriteLine($"Число {number} в {numSystem}-ой системе счисления равно числу {newNumber}.");
            result = MathIntByChar(newNumber, "*") - MathIntByChar(newNumber, "+");
            Console.WriteLine($"Ответ на задачу:  {result}.");
            Console.ReadKey();
        }

        static int[] DivideIntToArray(int number)
        {
            string strNumber = number.ToString();
            char[] chars = strNumber.ToCharArray();
            int[] intArray = new int[chars.Length];
            for (int i = 0; i < intArray.Length; i++)
                intArray[i] = (int)Char.GetNumericValue(chars[i]);
            return intArray;
        }

        static int MathIntByChar(int number, string sign) // Производит математические вычисления + - *
        {
            int tmp = 0;
            switch (sign)
            {
                case "+":
                    for (int i = 0; i < DivideIntToArray(number).Length; i++)
                        tmp += DivideIntToArray(number)[i];
                    break;
                case "-":
                    for (int i = 0; i < DivideIntToArray(number).Length; i++)
                        tmp -= DivideIntToArray(number)[i];
                    break;
                case "*":
                    tmp = 1;
                    for (int i = 0; i < DivideIntToArray(number).Length; i++)
                        tmp *= DivideIntToArray(number)[i];
                    break;
            }
            return tmp;
        }

        static int ReverseInt(int number) // Реверсирует входное целочисленное значение посредством обмена символов
        {
            char tmp;
            string strNumber = number.ToString();
            char[] chars = strNumber.ToCharArray();
            for (int i = 0; i < chars.Length - 1; i++)
            {
                tmp = chars[i];
                chars[i] = chars[chars.Length - i - 1];
                chars[chars.Length - i - 1] = tmp;
            }
            strNumber = String.Concat<char>(chars);
            number = int.Parse(strNumber);
            return number;
        }

        static int ConvertToNumberSystem(int number, int system) // Конвертирует число из десятичной СС в любую другую посредством деления
        {
            string strNumber = "";
            int tail;
            while (number > 0)
            {
                tail = number % system;
                number = (number - tail) / system;
                strNumber += tail.ToString();
            }
            number = int.Parse(strNumber);
            return ReverseInt(number); ;
        }

        static int EnterIntNumberInRange(int min, int max) // Контроль допустимости ввода целых чисел в диапозоне
        {
            int number;
            do
            {
                Console.Write("Ваше число: ");
                number = int.Parse(Console.ReadLine());
                if (number < min || number > max)
                    Console.WriteLine($"Число не входит в диапозон [{min}..{max}].");

            } while (number < min || number > max);
            return number;
        }
    }
}
