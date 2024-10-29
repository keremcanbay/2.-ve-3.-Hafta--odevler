using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> sayilar = new List<int>();
        int girilenSayi;

        Console.WriteLine("Dizi elemanlarını girin (ardışık grupları bulmak için 0 girin):");

        // Kullanıcıdan sayıları al
        do
        {
            Console.Write("Bir sayı girin: ");
            girilenSayi = int.Parse(Console.ReadLine());

            if (girilenSayi != 0)
                sayilar.Add(girilenSayi);

        } while (girilenSayi != 0);

        // Dizi boş değilse ardışık grupları tespit et
        if (sayilar.Count > 0)
        {
            sayilar.Sort(); // Diziyi sırala

            List<string> gruplar = new List<string>();
            int baslangic = sayilar[0];
            int onceki = sayilar[0];

            for (int i = 1; i < sayilar.Count; i++)
            {
                // Eğer ardışık değilse grubu kaydet ve yenisine başla
                if (sayilar[i] != onceki + 1)
                {
                    gruplar.Add(baslangic == onceki ? $"{baslangic}" : $"{baslangic}-{onceki}");
                    baslangic = sayilar[i];
                }
                onceki = sayilar[i];
            }

            // Son grubu ekle
            gruplar.Add(baslangic == onceki ? $"{baslangic}" : $"{baslangic}-{onceki}");

            Console.WriteLine("Ardışık gruplar: " + string.Join(", ", gruplar));
        }
        else
        {
            Console.WriteLine("Geçerli bir sayı girilmedi.");
        }

        // Konsol ekranını açık tut
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }
}
