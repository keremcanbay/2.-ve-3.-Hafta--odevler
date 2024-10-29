using System;
using System.Collections.Generic;

class Soru_8
{
    static void Main()
    {
        Console.Write("Şifreli mesajı girin: ");
        string encryptedMessage = Console.ReadLine();

        string originalMessage = DecryptMessage(encryptedMessage);

        Console.WriteLine("Orijinal mesaj: " + originalMessage);
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadLine(); // Konsolun açık kalmasını sağlamak için
    }

    static string DecryptMessage(string encryptedMessage)
    {
        List<char> originalChars = new List<char>();

        for (int i = 0; i < encryptedMessage.Length; i++)
        {
            char encryptedChar = encryptedMessage[i];
            int position = i + 1; // Pozisyon 1'den başlar

            // ASCII değerini elde et
            int encryptedAscii = (int)encryptedChar;

            // Modüler çözümleme tersini uygula
            int modValue;
            if (IsPrime(position))
            {
                modValue = encryptedAscii * 100; // Pozisyon asal ise 100 ile çarp
                modValue %= 256; // 256'ya mod al
            }
            else
            {
                modValue = encryptedAscii * 256; // Pozisyon asal değilse 256 ile çarp
                modValue %= 100; // 100'e mod al
            }

            // Fibonacci dönüşümünü tersine uygula
            int fibonacciValue = Fibonacci(position);
            int originalAscii = modValue / fibonacciValue; // Orijinal ASCII değerine ulaş

            // Orijinal karakteri ekle
            originalChars.Add((char)originalAscii);
        }

        return new string(originalChars.ToArray());
    }

    // Fibonacci hesaplama
    static int Fibonacci(int n)
    {
        if (n <= 0) return 0;
        if (n == 1 || n == 2) return 1;

        int a = 1, b = 1, c = 0;
        for (int i = 3; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return c;
    }

    // Asal sayı kontrolü
    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}
