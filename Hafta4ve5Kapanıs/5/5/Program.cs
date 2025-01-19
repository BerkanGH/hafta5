using System;
using System.Collections.Generic;

namespace ArabaFabrikasi
{
    class Araba
    {
        public DateTime UretimTarihi { get; private set; }
        public string SeriNumarasi { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Renk { get; set; }
        public int KapıSayisi { get; set; }

        public Araba()
        {
            UretimTarihi = DateTime.Now;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Araba> arabalar = new List<Araba>();
            while (true)
            {
                Console.Write("Araba üretmek istiyor musunuz? (e/h): ");
                string cevap = Console.ReadLine()?.Trim().ToLower();

                if (cevap == "h")
                {
                    Console.WriteLine("İyi günler! Üretilen arabalar:");
                    foreach (var araba in arabalar)
                    {
                        Console.WriteLine($"Seri Numarası: {araba.SeriNumarasi}, Marka: {araba.Marka}");
                    }
                    break;
                }
                else if (cevap == "e")
                {
                    Araba araba = new Araba();

                    Console.Write("Seri Numarası: ");
                    araba.SeriNumarasi = Console.ReadLine();
                    Console.Write("Marka: ");
                    araba.Marka = Console.ReadLine();
                    Console.Write("Model: ");
                    araba.Model = Console.ReadLine();
                    Console.Write("Renk: ");
                    araba.Renk = Console.ReadLine();

                KapıSayisiGir:
                    try
                    {
                        Console.Write("Kapı Sayısı: ");
                        araba.KapıSayisi = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Hatalı giriş! Lütfen sayısal bir değer giriniz.");
                        goto KapıSayisiGir;
                    }

                    arabalar.Add(araba);
                    Console.WriteLine("Araba başarıyla üretildi!");
                }
                else
                {
                    Console.WriteLine("Geçersiz bir cevap verdiniz, lütfen tekrar deneyiniz.");
                }
            }
        }
    }
}
