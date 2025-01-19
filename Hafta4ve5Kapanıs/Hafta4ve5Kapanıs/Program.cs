using System;

namespace TeknolojiMagazasi
{
    abstract class BaseMakine
    {
        public DateTime UretimTarihi { get; private set; }
        public string SeriNumarasi { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public string IsletimSistemi { get; set; }

        public BaseMakine()
        {
            UretimTarihi = DateTime.Now;
        }

        public virtual void BilgileriYazdir()
        {
            Console.WriteLine($"Üretim Tarihi: {UretimTarihi}");
            Console.WriteLine($"Seri Numarası: {SeriNumarasi}");
            Console.WriteLine($"Ad: {Ad}");
            Console.WriteLine($"Açıklama: {Aciklama}");
            Console.WriteLine($"İşletim Sistemi: {IsletimSistemi}");
        }

        public abstract void UrunAdiGetir();
    }

    class Telefon : BaseMakine
    {
        public bool TrLisansli { get; set; }

        public override void BilgileriYazdir()
        {
            base.BilgileriYazdir();
            Console.WriteLine($"TR Lisanslı: {TrLisansli}");
        }

        public override void UrunAdiGetir()
        {
            Console.WriteLine($"Telefonunuzun adı ---> {Ad}");
        }
    }

    class Bilgisayar : BaseMakine
    {
        private int usbGirisSayisi;
        public int UsbGirisSayisi
        {
            get => usbGirisSayisi;
            set
            {
                if (value == 2 || value == 4)
                {
                    usbGirisSayisi = value;
                }
                else
                {
                    Console.WriteLine("Hatalı USB giriş sayısı! Varsayılan değer -1 olarak atanıyor.");
                    usbGirisSayisi = -1;
                }
            }
        }

        public bool Bluetooth { get; set; }

        public override void BilgileriYazdir()
        {
            base.BilgileriYazdir();
            Console.WriteLine($"USB Giriş Sayısı: {UsbGirisSayisi}");
            Console.WriteLine($"Bluetooth: {Bluetooth}");
        }

        public override void UrunAdiGetir()
        {
            Console.WriteLine($"Bilgisayarınızın adı ---> {Ad}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Telefon üretmek için 1, Bilgisayar üretmek için 2'ye basınız:");
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    Telefon telefon = new Telefon();

                    Console.Write("Seri Numarası: ");
                    telefon.SeriNumarasi = Console.ReadLine();
                    Console.Write("Ad: ");
                    telefon.Ad = Console.ReadLine();
                    Console.Write("Açıklama: ");
                    telefon.Aciklama = Console.ReadLine();
                    Console.Write("İşletim Sistemi: ");
                    telefon.IsletimSistemi = Console.ReadLine();
                    Console.Write("TR Lisanslı mı? (Evet/Hayır): ");
                    telefon.TrLisansli = Console.ReadLine().ToLower() == "evet";

                    Console.WriteLine("Telefon başarıyla üretildi!");
                    telefon.BilgileriYazdir();
                    telefon.UrunAdiGetir();
                }
                else if (secim == "2")
                {
                    Bilgisayar bilgisayar = new Bilgisayar();

                    Console.Write("Seri Numarası: ");
                    bilgisayar.SeriNumarasi = Console.ReadLine();
                    Console.Write("Ad: ");
                    bilgisayar.Ad = Console.ReadLine();
                    Console.Write("Açıklama: ");
                    bilgisayar.Aciklama = Console.ReadLine();
                    Console.Write("İşletim Sistemi: ");
                    bilgisayar.IsletimSistemi = Console.ReadLine();
                    Console.Write("USB Giriş Sayısı (2/4): ");
                    bilgisayar.UsbGirisSayisi = int.Parse(Console.ReadLine());
                    Console.Write("Bluetooth var mı? (Evet/Hayır): ");
                    bilgisayar.Bluetooth = Console.ReadLine().ToLower() == "evet";

                    Console.WriteLine("Bilgisayar başarıyla üretildi!");
                    bilgisayar.BilgileriYazdir();
                    bilgisayar.UrunAdiGetir();
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                    continue;
                }

                Console.Write("Başka bir ürün üretmek istiyor musunuz? (Evet/Hayır): ");
                string devam = Console.ReadLine().ToLower();
                if (devam != "evet")
                {
                    Console.WriteLine("İyi günler!");
                    break;
                }
            }
        }
    }
}
