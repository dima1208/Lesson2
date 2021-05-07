using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Menu()
        {
            int menu;
            do
            {   Console.Title = "Пересёлкин Дмитрий Сергеевич";
                Console.Clear();
                Console.WriteLine("-------+++++++++++++++==================    Введите номер задания    ==================++++++++++++++++-------\n");
                Console.WriteLine(" 1. Написать метод, возвращающий минимальное из трёх чисел.");
                Console.WriteLine(" 2. Написать метод подсчета количества цифр числа.");
                Console.WriteLine(" 3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.");
                Console.WriteLine(" 4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. На выходе истина,\n    если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).\n    Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль,\n    программа пропускает его дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками.");
                Console.WriteLine(" 5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает,\n    нужно ли человеку похудеть, набрать вес или всё в норме.\n    б) * Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.");
                Console.WriteLine(" 6. *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.\n    «Хорошим» называется число, которое делится на сумму своих цифр.\n    Реализовать подсчёт времени выполнения программы, используя структуру DateTime.");
                Console.WriteLine(" 7. 7a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).");
                Console.WriteLine(" 8. 7б) * Разработать рекурсивный метод, который считает сумму чисел от a до b.");
                Console.WriteLine("\n 0. Выход");
                Console.Write("\nВаш выбор: ");
                menu = Int32.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        MinOfThree();
                        break;
                    case 2:
                        Console.Clear();
                        NumbersCount();
                        break;
                    case 3:
                        Console.Clear();
                        SumAllOdd();
                        break;
                    case 4:
                        Console.Clear();
                        Logon();
                        break;
                    case 5:
                        Console.Clear();
                        IMT();
                        break;
                    case 6:
                        Console.Clear();
                        GoodNumber();
                        break;
                    case 7:
                        Console.Clear();
                        Console.Write("Числа диапазона: ");
                        Rekurs1(1, 20);
                        Console.ReadLine();
                        break;
                    case 8:
                        Console.Clear();
                        Console.Write("Сумма чисел: " + Rekurs2(1, 10, 0));
                        Console.ReadLine();
                        break;
                    default:
                        Console.Clear();
                        continue;
                }
            }
            while (menu != 0);
        }

        static void MinOfThree()
        {
            Console.Write("Введите число a: ");
            int x = Int32.Parse(Console.ReadLine());
            Console.Write("Введите число b: ");
            int y = Int32.Parse(Console.ReadLine());
            Console.Write("Введите число c: ");
            int z = Int32.Parse(Console.ReadLine());
            int res = 0;
            if (x < y && x < z)
                res = x;
            else
            if (y < x && y < z)
                res = y;
            else
            if (z < x && z < y)
                res = z;
            Console.WriteLine($"Минимальное число: {res}");
            Console.WriteLine("\nДля возврата в меню нажмите Enter...");
            Console.ReadLine();
        }

        static void NumbersCount()
        {
            Console.Write("Введите число: ");
            int x = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"В числе {x} количество цифр = {Convert.ToString(x).Length}");
            Console.WriteLine("\nДля возврата в меню нажмите Enter...");
            Console.ReadLine();
        }

        static void SumAllOdd()
        {
            double number;
            double sum = 0;
            Console.WriteLine("Вводите числа, подтверждая нажатием Enter. Для завершения введите 0.\n");
            do
            {
                Console.Write("Ваше число: ");
                number = Convert.ToDouble(Console.ReadLine());
                if (number > 0 && number % 2 != 0)
                    sum += number;
            }
            while (number != 0);
            Console.WriteLine($"Сумма нечетных положительных чисел: {sum}");
            Console.WriteLine("\nДля возврата в меню нажмите Enter...");
            Console.ReadLine();
        }

        static bool LoginCheck(string login, string passwd)
        {
            string lo = "root";
            string pw = "GeekBrains";
            bool isMatch = false;
            if (login == lo && passwd == pw)
                isMatch = true;
            return isMatch;
        }

        static void Logon()
        {
            int cnt = 3;
            do
            {
                Console.Write("Введите логин: ");
                string l = Console.ReadLine();
                Console.Write("Введите пароль: ");
                string p = Console.ReadLine();
                bool b;
                b = LoginCheck(l, p);
                if (b == true)
                {
                    Console.WriteLine("Авторизация успешна! Нажмите любую клавишу для выхода в меню.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine($"Авторизация не прошла, осталось попыток: {cnt-1}! Нажмите любую клавишу.");
                    Console.ReadKey();
                    cnt--;
                }
            }
            while (cnt > 0);
        }

        static void IMT() // а) и b) в одном условии
        {
            Console.Write("Введите рост: ");
            byte height = Convert.ToByte(Console.ReadLine());
            Console.Write("Введите вес: ");
            byte weight = Convert.ToByte(Console.ReadLine());
            double imt = Math.Round(weight / Math.Pow(Convert.ToDouble(height) / 100, 2), 2);
            Console.WriteLine($"\nИндекс массы вашего тела: {imt} кг/м2.");
            if (imt >= 18.50 && imt <= 24.99)
                Console.WriteLine("У вас нормальный ИМТ.");
            else
                if (imt < 18.50)
            {
                Console.WriteLine("Вам нужно набрать вес!");
                Console.WriteLine($"До нормального веса вам нужно набрать {18.50 - imt} кг.");
            }
            else
                if (imt > 24.99)
            {
                Console.WriteLine("Вам нужно похудеть!");
                Console.WriteLine($"До нормального веса вам нужно похудеть на {imt - 24.99} кг.");
            }



            Console.WriteLine("\nДля возврата в меню нажмите Enter...");
            Console.ReadLine();
        }

        static void GoodNumber()
        {
            DateTime start = DateTime.Now;
            int goodnumbers = 0;
            bool b = false;
            for(int i = 1; i < 10000000; i++)
            {
                b = isNumGood(i);
                if (b) goodnumbers++;
            }
            DateTime stop = DateTime.Now;
            Console.WriteLine($"Количество хороших чисел: {goodnumbers}");
            Console.WriteLine($"Время работы функции составило: {stop - start}");
            Console.WriteLine("\nДля возврата в меню нажмите Enter...");
            Console.ReadLine();

        }

        static bool isNumGood(int i)
        {
            int tmp = i;
            int summaChisel = 0;
            while (tmp > 0)
            {
                summaChisel += tmp % 10;
                tmp /= 10;
            }
            return i % summaChisel == 0;
        }

        static void Rekurs1(int start, int end)
        {
            if (start == end)
            {
                Console.Write("\b\b");
                Console.Write(" ");
                return;
            }
            else
            {
                Console.Write(start + ", ");
                start++;
                Rekurs1(start, end);
            }
            Console.ReadLine();
        }

        static long Rekurs2(int start, int end, int res)
        {
            if (start == end) return res;
            else
            {
                res += start;
                start++;
                return Rekurs2(start, end, res);
            }
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
