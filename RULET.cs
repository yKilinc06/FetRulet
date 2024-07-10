using System;
using System.Threading;

namespace KumarhaneRuleti
{
    class Program
    {
        static void Main(string[] args)
        {
            int bakiye = 1000;
            int harcama;
            string kullaniciGirdisi = "";
            int sayi;
            bool gecerliGirdi = false;

            Console.WriteLine("Kumarhane Ruleti'ne Hoş Geldiniz!");
            while (true)
            {

                while (true)
                {
                    Console.WriteLine("Bakiyeniz: " + bakiye);
                    Console.Write("Ne kadar harcamak istiyorsunuz? ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out harcama) && harcama > 0 && harcama <= bakiye)
                    {
                        bakiye -= harcama;
                        Console.WriteLine("Harcama başarılı! Kalan bakiye: " + bakiye);
                        break;
                    }
                    else
                    {
                        Console.Write("Geçersiz miktar. Lütfen bakiyeden küçük bir değer girin.\n");
                    }
                }

                Console.WriteLine("Sadece bir sayı oynamak için direk o sayıyı\n" +
                                  "tek sayılara oynamak için 't'\n" +
                                  "çift sayılara oynamak için 'c' yazın.\n" +
                                  "Sadece bir sayı yazarsanız 36 kat, tek ya da çift seçerseniz 2 kat kazanırsınız.");

                while (!gecerliGirdi)
                {
                    kullaniciGirdisi = Console.ReadLine();

                    if (kullaniciGirdisi.ToLower() == "t" || kullaniciGirdisi.ToLower() == "c")
                    {
                        Console.WriteLine("Geçerli bir değer girdiniz: " + kullaniciGirdisi);
                        gecerliGirdi = true;
                    }
                    else if (int.TryParse(kullaniciGirdisi, out sayi) && sayi >= 0 && sayi <= 37)
                    {
                        Console.WriteLine("Geçerli bir sayı girdiniz: " + sayi);
                        gecerliGirdi = true;
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz giriş. Lütfen 't', 'c' ya da 0 ile 37 arasında bir sayı girin:");
                    }
                }

                Console.WriteLine("Çarkı çevirmek için Enter tuşuna basın...");
                Console.ReadLine();

                int kazananSayi = CarkiCevir();

                if (kullaniciGirdisi == "t")
                {
                    if (kazananSayi % 2 == 1)
                    {
                        bakiye += 2 * harcama;
                        Console.WriteLine("Kazandınız! Yeni bakiye: " + bakiye);
                    }
                    else
                    {
                        Console.WriteLine("Kaybettiniz. Yeni bakiye: " + bakiye);
                    }
                }
                else if (kullaniciGirdisi == "c")
                {
                    if (kazananSayi % 2 == 0)
                    {
                        bakiye += 2 * harcama;
                        Console.WriteLine("Kazandınız! Yeni bakiye: " + bakiye);
                    }
                    else
                    {
                        Console.WriteLine("Kaybettiniz. Yeni bakiye: " + bakiye);
                    }
                }
                else if (int.TryParse(kullaniciGirdisi, out sayi) && sayi == kazananSayi)
                {
                    bakiye += 35 * harcama;
                    Console.WriteLine("Kazandınız! Yeni bakiye: " + bakiye);
                }
                else
                {
                    Console.WriteLine("Kaybettiniz. Yeni bakiye: " + bakiye);
                }
            }
        }

        static int CarkiCevir()
            {
                string[] renkler = { "Kırmızı", "Siyah", "Yeşil" };
                int[] sayilar = new int[38];
                for (int i = 0; i < 38; i++)
                {
                    sayilar[i] = i;
                }

                Random random = new Random();
                int kazananSayi = sayilar[random.Next(sayilar.Length)];
                string kazananRenk = renkler[random.Next(renkler.Length)];

                Console.Clear();
                Console.WriteLine("Çark dönüyor...");


                for (int i = 0; i < 30; i++)
                {
                    int mevcutSayi = sayilar[random.Next(sayilar.Length)];
                    string mevcutRenk = renkler[random.Next(renkler.Length)];

                    Console.SetCursorPosition(0, 1);
                    Console.WriteLine($"Sayı: {mevcutSayi} Renk: {mevcutRenk}");

                    Thread.Sleep(100);
                }

                Console.Clear();
                Console.WriteLine($"Çark durdu!");
                Console.WriteLine($"Kazanan Sayı: {kazananSayi}");


                Console.WriteLine("Oynadığınız için teşekkürler!");

                return kazananSayi;
            
        }
    }
}

