using System;
using System.Collections.Generic;

class Soru_6
{
    static void Main()
    {
        DateTime now = DateTime.Now;
        int startYear = 2000;
        int endYear = 3000;

        Console.WriteLine($"Geçerli tarihler (Bugünden sonraki) arasında bulunanlar:");
        List<string> validDates = FindValidDates(startYear, endYear, now);

        foreach (var date in validDates)
        {
            Console.WriteLine(date);
        }

        Console.WriteLine("Tarihler listelendi.");

        // Konsol ekranının açık kalmasını sağlamak için
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadLine();  // Kullanıcı bir tuşa basana kadar bekler
    }

    static List<string> FindValidDates(int startYear, int endYear, DateTime currentDate)
    {
        List<string> validDates = new List<string>();

        for (int year = startYear; year <= endYear; year++)
        {
            for (int month = 1; month <= 12; month++)
            {
                int daysInMonth = DateTime.DaysInMonth(year, month);
                for (int day = 1; day <= daysInMonth; day++)
                {
                    DateTime date = new DateTime(year, month, day);

                    // Gün asal mı?
                    if (IsPrime(day) &&
                        // Ayın basamaklarının toplamı çift mi?
                        IsEvenSumOfDigits(month) &&
                        // Yılın rakamlar toplamı, yılın dörtte birinden küçük mü?
                        IsLessThanQuarterOfYear(year))
                    {
                        // Şu andan sonraki tarihleri kontrol et
                        if (date > currentDate)
                        {
                            validDates.Add(date.ToString("dd-MM-yyyy"));
                        }
                    }
                }
            }
        }

        return validDates;
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static bool IsEvenSumOfDigits(int number)
    {
        int sum = 0;
        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }
        return sum % 2 == 0;
    }

    static bool IsLessThanQuarterOfYear(int year)
    {
        int sumOfDigits = 0;
        int tempYear = year;
        while (tempYear > 0)
        {
            sumOfDigits += tempYear % 10;
            tempYear /= 10;
        }
        return sumOfDigits < (year / 4);
    }
}
