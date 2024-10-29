using System;

class Soru_1
{
    static void Main()
    {
        // Kullanıcıdan dizi elemanlarını al
        Console.Write("Dizi elemanlarını boşlukla ayırarak girin: ");
        string[] input = Console.ReadLine().Split();
        int[] dizi = Array.ConvertAll(input, int.Parse);

        // Diziyi sırala
        Array.Sort(dizi);
        Console.WriteLine("Sıralı dizi: " + string.Join(" ", dizi));

        // Kullanıcıdan aramak istediği sayıyı al
        Console.Write("Aramak istediğiniz sayıyı girin: ");
        int aranan = int.Parse(Console.ReadLine());

        // İkili arama ile sayıyı kontrol et
        bool bulundu = IkiliArama(dizi, aranan);

        if (bulundu)
            Console.WriteLine($"{aranan} sayısı dizide bulunuyor.");
        else
            Console.WriteLine($"{aranan} sayısı dizide bulunmuyor.");

        // Konsol ekranını açık tut
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }

    static bool IkiliArama(int[] dizi, int aranan)
    {
        int sol = 0;
        int sag = dizi.Length - 1;

        while (sol <= sag)
        {
            int orta = (sol + sag) / 2;

            if (dizi[orta] == aranan)
                return true;
            else if (dizi[orta] < aranan)
                sol = orta + 1;
            else
                sag = orta - 1;
        }

        return false;
    }
}
