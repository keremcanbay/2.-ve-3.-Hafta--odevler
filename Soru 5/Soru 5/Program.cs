using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Soru_5
{
    static void Main()
    {
        Console.WriteLine("Polinom işlemleri için 'exit' yazarak çıkana kadar polinom girin.");

        while (true)
        {
            Console.Write("Birinci polinomu girin (örneğin: 2x^2 + 3x - 5): ");
            string polinom1 = Console.ReadLine();
            if (polinom1.ToLower() == "exit") break;

            Console.Write("İkinci polinomu girin (örneğin: x^2 - 4): ");
            string polinom2 = Console.ReadLine();
            if (polinom2.ToLower() == "exit") break;

            var sonucToplama = PolinomTopla(polinom1, polinom2);
            var sonucCikarma = PolinomCikar(polinom1, polinom2);

            Console.WriteLine($"Toplama Sonucu: {sonucToplama}");
            Console.WriteLine($"Çıkarma Sonucu: {sonucCikarma}");
            Console.WriteLine();
        }
    }

    static string PolinomTopla(string p1, string p2)
    {
        return PolinomIslem(p1, p2, true);
    }

    static string PolinomCikar(string p1, string p2)
    {
        return PolinomIslem(p1, p2, false);
    }

    static string PolinomIslem(string p1, string p2, bool toplama)
    {
        Dictionary<int, int> terimler = new Dictionary<int, int>();

        ProcessPolinom(p1, terimler, toplama);
        ProcessPolinom(p2, terimler, !toplama);

        return FormatPolinom(terimler);
    }

    static void ProcessPolinom(string polinom, Dictionary<int, int> terimler, bool toplama)
    {
        // Polinomdaki terimleri ayır
        var matches = Regex.Matches(polinom, @"([-+]?\s*\d*x(?:\^\d+)?)|([-+]?\s*\d+)");

        foreach (Match match in matches)
        {
            string term = match.Value.Replace(" ", "");
            int coef = 1;
            int exp = 0;

            if (term.Contains("x"))
            {
                var parts = term.Split('x');
                coef = parts[0].Length > 0 && parts[0] != "+" && parts[0] != "-" ? int.Parse(parts[0]) : (parts[0] == "-" ? -1 : 1);
                exp = parts.Length > 1 && parts[1].StartsWith("^") ? int.Parse(parts[1].Substring(1)) : 1;
            }
            else
            {
                coef = int.Parse(term);
                exp = 0;
            }

            if (toplama)
            {
                if (terimler.ContainsKey(exp))
                    terimler[exp] += coef;
                else
                    terimler[exp] = coef;
            }
            else
            {
                if (terimler.ContainsKey(exp))
                    terimler[exp] -= coef;
                else
                    terimler[exp] = -coef;
            }
        }
    }

    static string FormatPolinom(Dictionary<int, int> terimler)
    {
        List<string> sonuc = new List<string>();
        foreach (var term in terimler)
        {
            if (term.Value != 0)
            {
                string t = term.Value > 0 && sonuc.Count > 0 ? "+" : "";
                t += term.Value.ToString();

                if (term.Key > 0)
                {
                    t += "x";
                    if (term.Key > 1)
                        t += "^" + term.Key;
                }
                sonuc.Add(t);
            }
        }

        return sonuc.Count > 0 ? string.Join(" ", sonuc) : "0";
    }
}
