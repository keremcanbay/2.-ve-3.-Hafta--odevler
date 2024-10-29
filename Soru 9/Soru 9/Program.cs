using System;

class Soru_9
{
    static void Main()
    {
        // Enerji maliyetlerini temsil eden matris
        int[,] energyCosts = {
            { 1, 3, 5, 8 },
            { 4, 2, 1, 7 },
            { 2, 4, 3, 6 },
            { 6, 1, 8, 3 }
        };

        int n = energyCosts.GetLength(0); // Matrisin boyutunu al
        int minEnergy = FindMinimumEnergyPath(energyCosts, n);

        Console.WriteLine("En az enerji harcayan yolun maliyeti: " + minEnergy);
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadLine(); // Konsolun açık kalmasını sağlamak için
    }

    static int FindMinimumEnergyPath(int[,] energyCosts, int n)
    {
        // Dinamik programlama matrisi
        int[,] dp = new int[n, n];

        // Başlangıç hücresinin maliyetini kopyala
        dp[0, 0] = energyCosts[0, 0];

        // İlk satırı doldur
        for (int j = 1; j < n; j++)
        {
            dp[0, j] = dp[0, j - 1] + energyCosts[0, j];
        }

        // İlk sütunu doldur
        for (int i = 1; i < n; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + energyCosts[i, 0];
        }

        // Diğer hücreleri doldur
        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j < n; j++)
            {
                int minCost = Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1]));
                dp[i, j] = minCost + energyCosts[i, j];
            }
        }

        // Hedef hücresinin maliyetini döndür
        return dp[n - 1, n - 1];
    }
}
