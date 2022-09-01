using System;
using System.Collections;
using System.Collections.Generic;

namespace TestTask
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("4 задание:");
            //Console.WriteLine(GetNumberSum(123));
            //Console.WriteLine();

            //Console.WriteLine("5 задание:");
            //var res = GetMoneys(-144);
            //Console.WriteLine($"N:{res["Nickels"]}; P:{res["Pennies"]}; D:{res["Dimes"]}; Q:{res["Quarters"]}");
            //Console.WriteLine();

            //Console.WriteLine("6 задание:");
            //Console.WriteLine(GetMaxFromNumber(545802));
            //Console.WriteLine();

            //Console.WriteLine("7 задание:");

            //Console.WriteLine("8 задание:");
            //Console.WriteLine(GetFive());
            //Console.WriteLine();

            Console.WriteLine(GetPiramidRowSum(4));

            Console.ReadKey();
        }

        //1 - за 4 дня. Мы делим все 1000 пробирок на 10. получаем группы пробирок по 100. Даем каждой мыши по капли лекарства из каждой пробирки своей группы.
        //Ждем сутки. Одна из мышей умерла => в этой группе и был яд. дальше делим 100 пробирок на 9 групп (8 по 11 и 1 по 12). Даем мышам по капле из каждой пробирки своей группы.
        //Ждем сутки. Одна из мышей умерла => в этой группе и был яд. В худшем случае умрет мышь которой досталась группа из 12 пробирок. Делим 12 пробирок на 8 групп для каждой из мышек(4 - по 1 пробирки и 4 по 2).
        //Даем каждой мышке. Ждем сутки. Одна из мышей умерла => в этой группе и был яд. В хужшем случае яд окажется в группе с 2 пробирками => повторяем процедуру и однозначно идетифицируем пробирку с ядом за 4 дня.
        //
        //2 - 2100 нужно отдать руководителю, поскольку в условиях стояла задача решить задачу первым. Ни синьер, ни джун не решил её первым => все деньги получает руководитель
        //ИЛИ
        //составляем уравнение: x + 2x + 4x = 2100. x - доля джуна. 2x - доля руководителя. 4x - доля синьера. Поскольку джун должен получить в 2 раза меньше чем руководитель
        //4x - доля синьера, поскольку синьер должен получить в 2 раза больше руководителя. Дальше решаем уравнение и получаем x = 300$
        //Значит джун должен получить 300, руководитель 600, синьер 1200
        //
        //3 - нужна 1 попытка. Поскольку на всех автоматах неправильные наклейки. Включаем автомат с наклейкой Чай\кофе.
        //Смотрим, что получили. Если чай, тогда автомат с наклейкой чай будет наливать кофе, поскольку если автомат с наклейкой чай будет наливать чай\кофе, то не будут выполнены условия
        //по которым все наклейки перепутаны. В автомате с наклейкой кофе будет наливаться чай\кофе по остаточному принципу.
        //
        //Если же в автомате с наклейкой чай\кофе появился кофе, то в автомате с наклейкой кофе будет наливаться чай, а в автомате с наклейкой чай - чай\кофе

        //4:
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
        public static int GetMaxFromNumber(int N)
        {
            string strN = N.ToString();
            int[] tmpArr = new int[strN.Length];
            for (int i = 0; i < strN.Length; i++)
            { 
                tmpArr[i] = (int)Char.GetNumericValue(strN[i]);
            }
            Array.Sort(tmpArr);
            string res = string.Empty;
            foreach (var i in tmpArr.Reverse())
            { 
                res += i.ToString();
            }
            return Convert.ToInt32(res);
        }

        //7:
        public static int GetPiramidRowSum(int RowIndex)
        {
            if (RowIndex > 0)
            {
                int startNumber = RowIndex * (RowIndex - 1) + 1;
                int result = startNumber;
                for (int i = 1; i < RowIndex; i++)
                {
                    startNumber += 2;
                    result += startNumber;
                }
                return result;
            }
            else
                throw new ArgumentException("Row index value must be more then zero");
        }

        //8:
        public static int GetFive()
        {
            return '';
        }
    }
}