using System;

namespace ДЗ_версия_030622
{

    class Program
    {
        static void Main(string[] args)
        { 

            Console.WriteLine("Введите ЧИСЛО-ОПЕРАНД ОПЕРАТОР ЧИСЛО-ОПЕРАНД:");
            Calculate();

        }
        public static void Calculate()
        {
            string a = "";
            string b = "";
            string myОperator = "";
            string s = "";

            while (s != "стоп")
            {
                Console.WriteLine();
                s = Console.ReadLine();

                int i = 0;
                string[] words = s.Split(' ');

                if (s != "стоп")
                {
                    try
                    {
                        foreach (var word in words)
                        {
                            i++;
                            if (i == 1) a = word;
                            if (i == 2) myОperator = word;
                            if (i == 3) b = word;
                        }

                        if (i == 2)
                        {
                            throw new Case1Exception();
                        }

                        if (myОperator != "+" && myОperator != "-" && myОperator != "*" && myОperator != "/" && i == 3)
                        {
                            throw new Case2Exception();
                        }

                        if (i < 3 || i > 3)
                        {
                            throw new Case3Exception();
                        }

                        try
                        {
                            int aInt = int.Parse(a);
                        }
                        catch (FormatException)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Операнд {a} не является числом");
                            Console.ResetColor();
                            continue;
                        }
                        try
                        {
                            int bInt = int.Parse(b);
                        }
                        catch (FormatException)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Операнд {b} не является числом");
                            Console.ResetColor();
                            continue;
                        }


                        if (myОperator == "+") Sum(a, b);
                        if (myОperator == "-") Sub(a, b);
                        if (myОperator == "*") Mul(a, b);
                        if (myОperator == "/") Div(a, b);

                    }
                    catch (Case1Exception)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Укажите в выражении оператор: +, -, *, /");
                        Console.ResetColor();
                    }

                    catch (Case2Exception)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Я пока не умею работать с оператором {myОperator}");
                        Console.ResetColor();
                    }
                    catch (Case3Exception)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Выражение некорректное, попробуйте написать в формате \na + b\na * b\na - b\na / b");
                        Console.ResetColor();
                    }
                    catch (Case6Exception)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("вы получили ответ 13!");
                        Console.ResetColor();
                    }
                    catch (DivideByZeroException)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Деление на 0");
                        Console.ResetColor();
                    }
                    catch (OverflowException)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Результат выражения в целом типе не помещается в тип int");
                        Console.ResetColor();
                    }

                    catch (Exception)
                    {
                        Console.WriteLine("Я не смог обработать ошибку");
                        return;
                    }
                  
                }
            }

        }

        /// <summary>
        /// сложение
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Sum(string a, string b)
        {
            int iInt = checked(int.Parse(a) + int.Parse(b));
            Console.WriteLine($"Результат: {int.Parse(a) + int.Parse(b)}");
            if (iInt == 13) throw new Case6Exception();
        }

        /// <summary>
        /// вычитание
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Sub(string a, string b)
        {
            int iInt = checked(int.Parse(a) - int.Parse(b));
            Console.WriteLine($"Результат: {int.Parse(a) - int.Parse(b)}");
            if (iInt == 13) throw new Case6Exception();
        }

        /// <summary>
        /// деление
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Div(string a, string b)
        {
            int iInt = checked(int.Parse(a) / int.Parse(b));
            Console.WriteLine($"Результат: {int.Parse(a) / int.Parse(b)}");
            if (iInt == 13) throw new Case6Exception();
        }


        /// <summary>
        /// умножение
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Mul(string a, string b)
        {
            int iInt = checked(int.Parse(a) * int.Parse(b));
            Console.WriteLine($"Результат: {int.Parse(a) * int.Parse(b)}");
            if (iInt == 13) throw new Case6Exception();
        }

    }
    class Case1Exception : Exception
    {
        public Case1Exception() : base() { }
    }
    class Case2Exception : Exception
    {
        public Case2Exception() : base() {}
    }
    class Case3Exception : Exception
    {
        public Case3Exception() : base() {}
    }
    class Case6Exception : Exception
    {
        public Case6Exception() : base() { }
    }
}
//else
//{
//    Console.WriteLine(new DataTable().Compute(s, "").ToString());
//    Console.Read();
//}