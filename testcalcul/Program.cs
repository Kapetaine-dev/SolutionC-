using System.Diagnostics;

Console.WriteLine("Calcul des performances - SÉQUENTIEL vs PARALLÈLE");
Console.WriteLine("====================================================)\n");

// SÉQUENTIEL
Console.WriteLine("MODE SÉQUENTIEL");
Console.WriteLine("----------------------------------------");
var globalSwSequential = Stopwatch.StartNew();

for (int iteration = 0; iteration < 10; iteration++)
{
    var sw = Stopwatch.StartNew();

    double result = 1;
    for (int i = 1; i <= 50_000_000; i++)
    {
        //cosinus
        result += Math.Cos(i) + Math.Sin(i);
        //racine carrée
        result += Math.Sqrt(i);
        // exp + log
        result += Math.Exp(i % 10) + Math.Log(i + 1);
        // puissance
        result += Math.Pow(i % 100, 3);
        // multiplication rule
        result *= 1.000001;
    }
    sw.Stop();
    Console.WriteLine($"Itération {iteration + 1:D2} : {sw.Elapsed.TotalMilliseconds:F2} ms");
}

globalSwSequential.Stop();
Console.WriteLine("\nTemps TOTAL (Séquentiel) : {0:F2} ms\n", globalSwSequential.Elapsed.TotalMilliseconds);

// PARALLÈLE
Console.WriteLine("MODE PARALLÈLE");
Console.WriteLine("----------------------------------------");
var globalSwParallel = Stopwatch.StartNew();

for (int iteration = 0; iteration < 10; iteration++)
{
    var sw = Stopwatch.StartNew();

    double result = 1;

    Parallel.For(1, 50_000_000, () => 1.0, (i, loop, localResult) =>
    {
        //cosinus
        localResult += Math.Cos(i) + Math.Sin(i);
        //racine carrée
        localResult += Math.Sqrt(i);
        // exp + log
        localResult += Math.Exp(i % 10) + Math.Log(i + 1);
        // puissance
        localResult += Math.Pow(i % 100, 3);
        // multiplication rule
        localResult *= 1.000001;

        return localResult;
    },
    localResult => 
    {
        lock (new object()) result += localResult;
    });

    sw.Stop();
    Console.WriteLine($"Itération {iteration + 1:D2} : {sw.Elapsed.TotalMilliseconds:F2} ms");
}

globalSwParallel.Stop();
Console.WriteLine("\nTemps TOTAL (Parallèle) : {0:F2} ms\n", globalSwParallel.Elapsed.TotalMilliseconds);

// RÉSUMÉ COMPARATIF
Console.WriteLine("RÉSUMÉ COMPARATIF");
Console.WriteLine($"Séquentiel : {globalSwSequential.Elapsed.TotalMilliseconds:F2} ms");
Console.WriteLine($"Parallèle  : {globalSwParallel.Elapsed.TotalMilliseconds:F2} ms");
