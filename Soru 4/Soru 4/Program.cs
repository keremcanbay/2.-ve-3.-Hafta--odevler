using System;
using System.Collections.Generic;
using System.Data;

class Soru_4
{
    static void Main()
    {
        Console.Write("Bir matematiksel ifade girin (örneğin: 3 + 4 * 2 / (1 - 5) ^ 2): ");
        string ifade = Console.ReadLine();

        try
        {
            double sonuc = Hesapla(ifade);
            Console.WriteLine("Sonuç: " + sonuc);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata: " + ex.Message);
        }

        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }

    static double Hesapla(string ifade)
    {
        // İşlemlerin sırasını takip edecek bir liste
        var islemler = new List<string>();

        // İfade değerini hesaplamak için DataTable kullanıyoruz
        var table = new DataTable();
        table.Columns.Add("expression", typeof(string), ifade);
        var row = table.NewRow();
        table.Rows.Add(row);

        double result = Convert.ToDouble(row["expression"]);

        // Hangi işlemin yapıldığını göster
        IslemleriKaydet(ifade, result, islemler);

        // Yapılan işlemleri ekrana yazdır
        foreach (var islem in islemler)
        {
            Console.WriteLine(islem);
        }

        return result;
    }

    static void IslemleriKaydet(string ifade, double sonuc, List<string> islemler)
    {
        string[] tokens = ifade.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Her bir token için işlem sırasını kaydet
        foreach (var token in tokens)
        {
            if (double.TryParse(token, out _))
            {
                // Sayı ise işleme gerek yok
                continue;
            }

            if (IsOperator(token))
            {
                islemler.Add($"İşlem: {token} => Geçerli sonuç: {sonuc}");
            }
        }
    }

    static bool IsOperator(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/" || token == "^";
    }
}
