using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace BSICodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Pilih menu:");
                Console.WriteLine("1. Hitung total 3 nilai teratas");
                Console.WriteLine("2. Filter bilangan genap berurutan descending piramida");
                Console.WriteLine("3. Tampilkan n bilangan prima pertama");
                Console.WriteLine("4. Keluar");
                Console.Write("\nPilih menu (1-4): ");
                string? pilihan = Console.ReadLine();
                Console.WriteLine();

                switch (pilihan)
                {
                    case "1":
                        MenuSatu();
                        break;
                    case "2":
                        MenuDua();
                        break;
                    case "3":
                        MenuTiga();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan pilih menu 1-4.");
                        break;
                }
            }
        }

        static void MenuSatu()
        {
            Console.WriteLine("-- - Menu 1: Hitung total 3 nilai teratas ---");
            Console.Write("Masukan angka dipisahkan oleh koma (tekan Enter untuk default [1,2,3,4,5]): ");
            string? input = Console.ReadLine();
            int[] numbers;
            if (string.IsNullOrWhiteSpace(input))
            {
                numbers = new int[] { 1, 2, 3, 4, 5 };
                Console.WriteLine("Default array: " + string.Join(", ", numbers));
            }
            else
            {
                numbers = input.Split(',').Select(int.Parse).ToArray();
            }
            int total = numbers.OrderByDescending(n => n).Take(3).Sum();
            Console.WriteLine("Total 3 nilai teratas: " + total);
        } //end menu satu

        static void MenuDua()
        {
            Console.WriteLine("-- - Menu 2: Filter bilangan genap berurutan descending piramida ---");
            Console.Write("Masukan angka dipisahkan oleh koma (tekan Enter untuk default [2,4,6,5,3,1,7,9,10,8] ");
            string? input = Console.ReadLine();
            int[] numbers;
            if (string.IsNullOrWhiteSpace(input))
            {
                numbers = new int[] { 2, 4, 6, 5, 3, 1, 7, 9, 10, 8 };
                Console.WriteLine("Default array: " + string.Join(", ", numbers));
            }
            else
            {
                numbers = input.Split(',').Select(int.Parse).ToArray();
            }

            var evenNumbers = numbers.Where(n => n % 2 == 0).OrderBy(n => n).ToList();
            Console.WriteLine("Hasilnya:");
            for (int i = evenNumbers.Count; i > 0; i--)
            {
                Console.WriteLine(string.Join(",", evenNumbers.Take(i)));
            }
        } //end menu dua

        static void MenuTiga()
        {
            Console.WriteLine("3. Deret Bilangan Prima");
            Console.Write("Masukan jumlah bilangan prima yang ingin ditampilkan (tekan Enter untuk default n=6): ");
            string? input = Console.ReadLine();

            int n = string.IsNullOrEmpty(input) ? 6 : int.Parse(input);

            List<int> primes = new List<int>();
            int num = 2;
            while (primes.Count < n)
            {
                if (IsPrime(num))
                {
                    primes.Add(num);
                }
                num++;
            }
            Console.WriteLine("Outputnya: " + string.Join(", ", primes));
        } //end menu tiga

        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0) return false;
            }
            return true;

        } //end helper fungsi prima
    }
}
    