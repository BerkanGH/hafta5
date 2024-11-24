using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Lütfen bir sayı giriniz:");

        try
        {
            // Kullanıcıdan input alıyoruz
            string input = Console.ReadLine();

            // int e dönüştürdük
            int number = int.Parse(input);

            // Sayının karesini hesaplayıp veriyoruz
            Console.WriteLine($"Girdiğiniz sayının karesi: {number * number}");
        }
        catch (FormatException)
        {
            // Geçersiz giriş durumunda hata mesajı
            Console.WriteLine("Geçersiz giriş! Lütfen bir sayı giriniz.");
        }
    }
}
