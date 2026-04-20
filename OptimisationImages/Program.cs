using System.Diagnostics;
using OptimisationImages;

Console.WriteLine("-----_|Optimisator|_-----\n");

var projectRoot  = Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "images"))
    ? Directory.GetCurrentDirectory()
    : Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));

var inputFolder  = Path.Combine(projectRoot, "images");
var outputFolder = Path.Combine(projectRoot, "output");

if (!Directory.Exists(inputFolder))
{
    Console.WriteLine("Dossier 'images/' introuvable.");
    return;
}

var allImages = Directory
    .EnumerateFiles(inputFolder)
    .Where(f => ImageProcessor.SupportedExtensions.Contains(Path.GetExtension(f).ToLowerInvariant()))
    .ToList();

if (allImages.Count == 0)
{
    Console.WriteLine("Aucune image trouvée dans le dossier 'images'. Ajoutez des fichiers jpg, png...");
    return;
}

Console.WriteLine("Images disponibles :\n");
for (var i = 0; i < allImages.Count; i++)
    Console.WriteLine($"  [{i + 1}] {Path.GetFileName(allImages[i])}");

Console.Write("\nNuméro de l'image (ou \"tous\") : ");
var imageInput = Console.ReadLine()?.Trim().ToLower();

List<string> toProcess;
if (imageInput == "tous")
    toProcess = allImages;
else if (int.TryParse(imageInput, out var index) && index >= 1 && index <= allImages.Count)
    toProcess = [allImages[index - 1]];
else
{
    Console.WriteLine("Choix invalide.");
    return;
}

Console.WriteLine("\nMode :\n");
Console.WriteLine("  [1] Séquentiel  (sans optimisation)");
Console.WriteLine("  [2] Parallèle   (avec optimisation)");
Console.WriteLine("  [3] Comparer les deux");
Console.Write("\nChoix : ");
var modeInput = Console.ReadLine()?.Trim();

Console.WriteLine();

switch (modeInput)
{
    case "1":
        RunAndDisplay("Séquentiel", () => ImageProcessor.ProcessSequential(toProcess, outputFolder));
        break;

    case "2":
        RunAndDisplay("Parallèle", () => ImageProcessor.ProcessParallel(toProcess, outputFolder));
        break;

    case "3":
        var seqMs = RunAndDisplay("Séquentiel", () => ImageProcessor.ProcessSequential(toProcess, outputFolder));
        Console.WriteLine();
        var parMs = RunAndDisplay("Parallèle",  () => ImageProcessor.ProcessParallel(toProcess, outputFolder));

        Console.WriteLine("\n--- Comparaison ---");
        Console.WriteLine($"  Séquentiel : {seqMs} ms");
        Console.WriteLine($"  Parallèle  : {parMs} ms");
        Console.WriteLine($"  Gain       : {seqMs - parMs} ms ({(seqMs > 0 ? (1.0 - (double)parMs / seqMs) * 100 : 0):F0}% plus rapide)");
        break;

    default:
        Console.WriteLine("Choix invalide.");
        return;
}

Console.WriteLine($"\nRésultats dans : {outputFolder}");

static long RunAndDisplay(string label, Action process)
{
    Console.WriteLine($"[{label}] Traitement en cours...\n");
    var sw = Stopwatch.StartNew();
    process();
    sw.Stop();
    Console.WriteLine($"\n[{label}] Terminé en {sw.ElapsedMilliseconds} ms.");
    return sw.ElapsedMilliseconds;
}
