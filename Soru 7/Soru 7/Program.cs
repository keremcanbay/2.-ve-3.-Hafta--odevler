using System;
using System.Collections.Generic;

class Soru_7

{
    static void Main()
    {
        int M = 5; // Labirentin satır sayısı
        int N = 5; // Labirentin sütun sayısı
        bool[,] visited = new bool[M, N];

        List<Tuple<int, int>> path = new List<Tuple<int, int>>();

        if (FindPath(0, 0, M, N, visited, path))
        {
            Console.WriteLine("Şehre ulaşmak için izlenen yol:");
            foreach (var step in path)
            {
                Console.WriteLine($"({step.Item1}, {step.Item2})");
            }
        }
        else
        {
            Console.WriteLine("Şehir kayboldu!");
        }

        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadLine(); // Konsolun açık kalmasını sağlamak için
    }

    static bool FindPath(int x, int y, int M, int N, bool[,] visited, List<Tuple<int, int>> path)
    {
        // Hedef konum (M-1, N-1)
        if (x == M - 1 && y == N - 1)
        {
            path.Add(Tuple.Create(x, y));
            return true;
        }

        // Koordinatları kontrol et
        if (!IsValidCell(x, y, M, N, visited))
        {
            return false;
        }

        // Hücreyi ziyaret ettik
        visited[x, y] = true;
        path.Add(Tuple.Create(x, y));

        // Aşağı, Sağ, Yukarı, Sol yönlerine hareket et
        if (FindPath(x + 1, y, M, N, visited, path) || // Aşağı
            FindPath(x, y + 1, M, N, visited, path) || // Sağ
            FindPath(x - 1, y, M, N, visited, path) || // Yukarı
            FindPath(x, y - 1, M, N, visited, path))   // Sol
        {
            return true;
        }

        // Gerileme
        path.RemoveAt(path.Count - 1);
        visited[x, y] = false;
        return false;
    }

    static bool IsValidCell(int x, int y, int M, int N, bool[,] visited)
    {
        // Koordinatlar sınırlar içinde mi?
        if (x < 0 || x >= M || y < 0 || y >= N || visited[x, y])
        {
            return false;
        }

        // Asal sayı kontrolü
        if (!IsPrime(x) || !IsPrime(y))
        {
            return false;
        }

        // Kapının açılıp açılmadığını kontrol et
        int sum = x + y;
        int product = x * y;

        // Kapı açma koşulu
        if (product == 0 || sum % product != 0) // 0'a bölme hatası için kontrol
        {
            return false;
        }

        return true;
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
}
