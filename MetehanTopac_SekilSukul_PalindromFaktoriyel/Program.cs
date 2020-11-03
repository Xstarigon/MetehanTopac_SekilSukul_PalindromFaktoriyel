using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;
using System.Threading;
using System.ComponentModel.Design;

namespace MetehanTopac_SekilSukul_PalindromFaktoriyel
{
    class Program
    {
        static void Main(string[] args)
        {
            Title();
            ProgressBar();
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Menu();

            } else if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            Console.ReadLine();
        }

        static void Menu()
        {
            Console.WriteAscii("Palindrom ve", Color.Orange);
            Console.WriteAscii(" Faktoriyel Odevi", Color.Orange);
            Console.WriteLine("Lütfen görüntülemek istediğiniz ödevi seçiniz.", Color.LightBlue);
            Console.WriteLine("1) Palindrom", Color.LightBlue);
            Console.WriteLine("2) Faktoriyel", Color.LightBlue);
            Console.WriteLine("3) Bonus: Dama Tahtası", Color.LightBlue);
            Console.WriteLine("4) Çıkış", Color.IndianRed);
            SecimAl();
            

        }

        private static void SecimAl()
        {
            Console.Write("Ödev Numarası: ", Color.LightBlue);
            int selection = int.Parse(Console.ReadLine());
            while (selection == 1 || selection == 2 || selection == 3 || selection == 4)
            {
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        Palindrom();
                        break;
                    case 2:
                        Console.Clear();
                        Faktoriyel();
                        break;
                    case 3:
                        Console.Clear();
                        Bonus();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
            Console.WriteLine("Lütfen geçerli bir ödev numarası giriniz!", Color.Red);
            SecimAl();
        }

        static void Bonus()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    if (j == 1)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            Console.Write("*", Color.Blue);
                            Console.Write(" ");
                            Thread.Sleep(40);
                        }
                    }
                    if (j == 2)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            Console.Write(" ");
                            Console.Write("*", Color.Red);
                            Thread.Sleep(40);
                        }
                    }
                    Console.WriteLine();
                    Thread.Sleep(25);
                }
                Thread.Sleep(25);
            }

            Console.WriteLine("Programdan çıkmak için ESC'ye, yeniden görmek için ENTER'a ve ana menüye dönmek için TAB'e tıklayınız.", Color.DarkCyan);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Tab:
                    Console.Clear();
                    Menu();
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    Bonus();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }

        static void Faktoriyel()
        {
            Console.WriteAscii("Faktoriyel", Color.Orange);
            Console.WriteLine("Faktoriyel hesaplama aracına hoşgeldiniz. Lütfen faktoriyeli alınacak sayıyı giriniz.", Color.LightBlue);
            FaktoriyelHesapla();

            Console.WriteLine("Programdan çıkmak için ESC'ye, yeni bir işlem yapmak için ENTER'a ve ana menüye dönmek için TAB'e tıklayınız.", Color.DarkCyan);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Tab:
                    Console.Clear();
                    Menu();
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    Faktoriyel();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }

        static void FaktoriyelHesapla()
        {
            Console.Write("Faktoriyeli alınacak sayı: ", Color.White);
            string sayi = Console.ReadLine();
            double sonuc = 1;
            if (IsString(sayi) == false)
            {
                int number = int.Parse(sayi);
                for (int i = number; i > 0; i--)
                {
                    sonuc = sonuc * i;
                }
                Console.WriteLine(number + "! = " + sonuc.ToString());
            }
            else
            {
                Console.WriteLine("Lütfen bir sayı giriniz.", Color.Red);
                FaktoriyelHesapla();
            }
        }

        static void Palindrom()
        {
            Console.WriteAscii("Palindrom", Color.Orange);
            Console.WriteLine("Palindrom test aracına hoşgeldin! Lütfen bir kelime giriniz.", Color.LightBlue);
            PalindromBul();
            Console.WriteLine("Programdan çıkmak için ESC'ye, yeni bir işlem yapmak için ENTER'a ve ana menüye dönmek için TAB'e tıklayınız.", Color.DarkCyan);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Tab:
                    Console.Clear();
                    Menu();
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    Palindrom();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }

        static void PalindromBul()
        {
            Console.Write("Kelime: ", Color.White);
            string kelime = Console.ReadLine();
            if (kelime.Length < 2)
            {
                Console.WriteLine("Kelime en az 2 karakter içermelidir!");
                PalindromBul();
            }
            else if (IsString(kelime) == false)
            {
                Console.WriteLine("Kelime sadece harflerden oluşmalıdır!");
                PalindromBul();
            }
            else
            {
                string terskelime = "";
                for (int i = kelime.Length - 1; i >= 0; i--)
                {
                    terskelime = terskelime + kelime[i].ToString();
                }
                Console.Write("Kelimenin tersi: ", Color.White);
                Console.WriteLine(terskelime);
                if (kelime == terskelime)
                {
                    Console.WriteLine("\"" + kelime + "\"" + " kelimesi bir palindromdur.", Color.Green);
                }
                else
                {
                    Console.WriteLine("\"" + kelime + "\"" + " kelimesi bir palindrom değildir.", Color.Red);
                }
            }
        }

        static bool IsString(string kelime)
        {
            bool output = true;
            byte[] numbers = new byte[10]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 0
            };
            foreach (var number in numbers)
            {
                if (kelime.Contains(number.ToString()))
                {
                    output = false;
                }
            }
            return output;
        }
        static void Title()
        {
            Console.WriteAscii("BilgeAdam Teknoloji", Color.Aqua);
            Console.WriteAscii("  Palindrom ve", Color.MediumPurple);
            Console.WriteAscii("   Faktoriyel Odevi", Color.Purple);
            Console.WriteLine("                                         Coded by Metehan Topac", Color.Red);
            Console.WriteLine();
        }
        static void ProgressBar()
        {
            for (int i = 0; i <= 100; i++)
            {
                Console.Write($"\rBaşlatılıyor: {i}%   ", Color.Blue);
                Thread.Sleep(30);
            }

            Console.Write("\rTamamlandı! Lütfen devam etmek için ENTER a tıklayınız.", Color.Green);
        }
    }
}
