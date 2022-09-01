using System;
using System.Collections;
using System.Collections.Generic;

namespace TestTask
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("4 задание:");
            Console.WriteLine(GetNumberSum(123));
            Console.WriteLine();

            Console.WriteLine("5 задание:");
            var res = GetMoneys(144);
            Console.WriteLine($"N:{res["Nickels"]}; P:{res["Pennies"]}; D:{res["Dimes"]}; Q:{res["Quarters"]}");
            Console.WriteLine();

            Console.WriteLine("6 задание:");
            Console.WriteLine(GetMaxFromNumber(545802));
            Console.WriteLine();

            Console.WriteLine("7 задание:");
            Console.WriteLine(GetPiramidRowSum(4));
            Console.WriteLine();

            Console.WriteLine("8 задание:");
            Console.WriteLine(GetFive());
            Console.WriteLine();

            Console.ReadKey();
        }

        
        //4:
        /// <summary>
        /// Получает сумму цифр числа до тех пор, пока количество цифр в числе не будет равно 1
        /// </summary>
        /// <param name="N">Число, чьи цифры необходимо ссумировать</param>
        /// <returns>int</returns>
        public static int GetNumberSum(int N)
        {
            int result = 0;
            while (N != 0)
            {
                result = result + N % 10;
                N = N / 10;
            }
            return result > 9 ? GetNumberSum(result) : result;
        }

        //5:
        /// <summary>
        /// Получает минимальное количество монет из которых можно получить переданную сумму
        /// </summary>
        /// <param name="Cents">Сумма в центах</param>
        /// <returns>Словарь с ключами: Nickels, Pennies, Dimes, Quarters </returns>
        public static Dictionary<string, int> GetMoneys(int Cents)
        {
            Dictionary<string, int> result = new Dictionary<string, int>(){ { "Nickels", 0 }, 
                                                                            { "Pennies", 0 }, 
                                                                            { "Dimes", 0 }, 
                                                                            { "Quarters", 0 } };
            if (Cents > 0)
            {
                int last = Cents;
                result["Quarters"] = Cents / 25;
                last = last - (result["Quarters"] * 25);
                result["Dimes"] = last / 10;
                last = last - (result["Dimes"] * 10);
                result["Pennies"] = last / 5;
                last = last - (result["Pennies"] * 5);
                result["Nickels"] = last;
            }
            return result;
        }

        //6:
        /// <summary>
        /// Получает максимальное значение из цифр переданного числа
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int GetMaxFromNumber(int N)
        {
            //Получаем строковое представление числа, чтобы можно перебрать каждую из цифр числа
            string strN = N.ToString();
            //Создаем временный массив для int-овых представлений цифр числа N
            int[] tmpArr = new int[strN.Length];
            //Заполняем временный массив
            for (int i = 0; i < strN.Length; i++)
            { 
                tmpArr[i] = (int)Char.GetNumericValue(strN[i]);
            }
            //Сортируем массив из цифр числа N
            Array.Sort(tmpArr);
            string res = string.Empty;
            //Разворачиваем отсортированный массив, чтобы получить максимальное число из цифр числа N
            foreach (var i in tmpArr.Reverse())
            { 
                //В соответствующем порядке добавляем значения к результату
                res += i.ToString();
            }
            //Возвращаем интовое представление результата
            return Convert.ToInt32(res);
        }

        //7:
        /// <summary>
        /// Получает сумму нечетных числе в строке пирамиды
        /// </summary>
        /// <param name="RowIndex">Индекс строки</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int GetPiramidRowSum(int RowIndex)
        {
            if (RowIndex > 0)
            {
                //Вычисляем первое число строки
                int startNumber = RowIndex * (RowIndex - 1) + 1;
                int result = startNumber;
                //Вычисляем результат, в цикле от 1, поскольку первое число было уже добавлено к результату, до индекса строки,
                //поскольку количество нечетных чисел в строке пирамиды равно индексу строки
                for (int i = 1; i < RowIndex; i++)
                {
                    //Прибавляем к стартовому числу 2, чтобы перескачить четные числа
                    startNumber += 2;
                    result += startNumber;
                }
                return result;
            }
            else
                throw new ArgumentException("Row index value must be more then zero");
        }

        //8:
        /// <summary>
        /// Возвращает 5 не используя цифры
        /// </summary>
        /// <returns>5</returns>
        public static int GetFive()
        {
            //Возвращает десятичное представление символа в unicode
            return '';
        }
    }
}