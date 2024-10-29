using System;
using System.Collections.Generic;
using System.Linq;

class Soru_2
{
    static void Main()
    {
        List<int> sayilar = new List<int>();
        int girilenSayi;

        Console.WriteLine("Pozitif tam sayılar girin. Hesaplama yapmak için 0 girin.");

        // Kullanıcıdan sayıları al
        do
        {
            Console.Write("Bir sayı girin: ");
            girilenSayi = int.Parse(Console.ReadLine());

            if (girilenSayi > 0)
                sayilar.Add(girilenSayi);

        } while (girilenSayi != 0);

        // Sayılar varsa ortalama ve medyanı hesapla
        if (sayilar.Count > 0)
        {
            // Ortalama hesaplama
            double ortalama = sayilar.Average();
            Console.WriteLine("Ortalama: " + ortalama);

            // Medyan hesaplama
            sayilar.Sort();
            double medyan;
            int ortaIndex = sayilar.Count / 2;

            if (sayilar.Count % 2 == 0)
            {
                // Çift sayı varsa, ortadaki iki değerin ortalamasını al
                medyan = (sayilar[ortaIndex - 1] + sayilar[ortaIndex]) / 2.0;
            }
            else
            {
                // Tek sayı varsa, ortadaki değeri al
                medyan = sayilar[ortaIndex];
            }

            Console.WriteLine("Medyan: " + medyan);
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
