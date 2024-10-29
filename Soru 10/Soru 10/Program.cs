using System;
using System.Collections.Generic;

class Soru_10
{
    static void Main()
    {
        // Kullanıcıdan sayı dizisi al
        Console.WriteLine("Bir dizi sayı girin (virgülle ayırın): ");
        string[] inputNumbers = Console.ReadLine().Split(',');
        List<double> numbers = new List<double>();

        foreach (string num in inputNumbers)
        {
            if (double.TryParse(num.Trim(), out double result))
            {
                numbers.Add(result);
            }
        }

        // Geçerli operatörler
        char[] operators = { '+', '-', '*', '/' };

        // Geçerli ifadeleri bul
        List<string> validExpressions = new List<string>();
        GenerateExpressions(numbers, operators, "", validExpressions);

        // Geçerli ifadeleri yazdır
        Console.WriteLine("Geçerli İfadeler:");
        if (validExpressions.Count == 0)
        {
            Console.WriteLine("Geçerli bir ifade bulunamadı.");
        }
        else
        {
            foreach (string expression in validExpressions)
            {
                Console.WriteLine(expression);
            }
        }

        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadLine(); // Konsolun açık kalmasını sağlamak için
    }

    static void GenerateExpressions(List<double> numbers, char[] operators, string currentExpression, List<string> validExpressions)
    {
        // Eğer hiç sayı kalmadıysa, geri dön
        if (numbers.Count == 0) return;

        // Eğer bir sayı varsa, o zaman operatör ekleyebiliriz
        if (currentExpression.Length > 0)
        {
            foreach (var op in operators)
            {
                // Her sayıyı kullanarak yeni ifadeler oluştur
                for (int i = 0; i < numbers.Count; i++)
                {
                    string newExpression = currentExpression + " " + op + " " + numbers[i];
                    // Geçerli ifadeleri kontrol et
                    CheckValidExpressions(newExpression, validExpressions);
                }
            }
        }
        else
        {
            // İlk sayıyı ekle
            for (int i = 0; i < numbers.Count; i++)
            {
                string newExpression = numbers[i].ToString();
                GenerateExpressions(numbers, operators, newExpression, validExpressions);
            }
        }
    }

    static void CheckValidExpressions(string expression, List<string> validExpressions)
    {
        try
        {
            // Eğer ifade sıfırdan büyükse geçerli ifadeler listesine ekle
            double result = EvaluateExpression(expression);
            if (result > 0)
            {
                validExpressions.Add(expression);
            }
        }
        catch (Exception)
        {
            // Hatalı ifadeleri yok say
        }
    }

    static double EvaluateExpression(string expression)
    {
        // Basit bir hesaplama yapalım
        var dataTable = new System.Data.DataTable();
        return Convert.ToDouble(dataTable.Compute(expression, string.Empty));
    }
}
