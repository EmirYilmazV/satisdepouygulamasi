using System;
using System.Collections.Generic;

class Program
{
    class Urun
    {
        public string Urunismi { get; set; }
        public int Urundegeri { get; set; }
        public decimal Urunfiyat { get; set; }

        public Urun(string urunismi, int urundegeri, decimal urunfiyat)
        {
            Urunismi = urunismi;
            Urundegeri = urundegeri;
            Urunfiyat = urunfiyat;
        }
    }

    static void Main(string[] args)
    
    {
        List<Urun> urun = new List<Urun>();
        decimal gunlukkazanc = 0;

        while (true)
        {
            Console.WriteLine("\nAşşağıdakilerden Birini seçiniz");
            Console.WriteLine("1. Satış");
            Console.WriteLine("2. Eşya Alım");
            Console.WriteLine("0. İşlemi bitir");
            Console.Write("Numara giriniz: ");
            string secim = Console.ReadLine();

            if (secim == "0")
            {
                Console.WriteLine("İşleminiz sona erdi");
                Console.WriteLine($"Günlük kazanç: {gunlukkazanc}");
                break;
            }

            switch (secim)
            {
                case "1":
                    gunlukkazanc += Urunsat(urun);
                    break;
                case "2":
                    Urunekle(urun);
                    break;
                default:
                    Console.WriteLine("Seçim geçersiz");
                    break;
            }
        }
    }

    static void Urunekle(List<Urun> urun)
    {
        Console.Write("Ürün adı: ");
        string urunismi = Console.ReadLine();
        Console.Write("Alınacak miktar: ");
        int urundegeri = int.Parse(Console.ReadLine());
        Console.Write("Toplam fiyat: ");
        decimal urunfiyat = decimal.Parse(Console.ReadLine());

        Urun urunzatenvar = urun.Find(p => p.Urunismi.Equals(urunismi, StringComparison.OrdinalIgnoreCase));

        if (urunzatenvar != null)
        {
            urunzatenvar.Urundegeri += urundegeri;
            urunzatenvar.Urunfiyat += urunfiyat;
            Console.WriteLine($"{urunismi} ürününün stoğu güncellendi. Yeni miktar: {urunzatenvar.Urundegeri}, Birim fiyatı: {urunzatenvar.Urunfiyat}");
        }
        else
        {
            urun.Add(new Urun(urunismi, urundegeri, urunfiyat));
            Console.WriteLine($"{urunismi} ürünü eklendi.");
        }
    }
    
        static decimal Urunsat(List<Urun> urun)
    {
        Console.Write("Müşterinin Parası: "); 
        decimal musteripara = decimal.Parse(Console.ReadLine());
        Console.Write("Aldığı Ürün: ");
        string urunismi = Console.ReadLine();
        Console.Write("Aldığı Miktar: ");
        int urundegeri = int.Parse(Console.ReadLine());

        Urun urunzatenvar = urun.Find(p => p.Urunismi.Equals(urunismi, StringComparison.OrdinalIgnoreCase));

        if (urunzatenvar != null)
        {
            if (urunzatenvar.Urundegeri >= urundegeri)
            {
                
                decimal alinanmiktar = urunzatenvar.Urunfiyat * urundegeri;

                if (musteripara >= alinanmiktar)
                {
                    urunzatenvar.Urundegeri -= urundegeri;
                    Console.WriteLine("Satış Başarılı.Para üstü:{0}",musteripara - alinanmiktar);
                    return alinanmiktar;
                }
                else
                {
                    Console.WriteLine("Yetersiz para!");
                    return 0;
                }
            }
            else
            {
                Console.WriteLine($"Yetersiz stok! Mevcut miktar: {urunzatenvar.Urundegeri}");
                return 0;
            }
        }
        else
        {
            Console.WriteLine($"{urunismi} ürünü bulunamadı.");
            return 0;
        }
    }
    
}
