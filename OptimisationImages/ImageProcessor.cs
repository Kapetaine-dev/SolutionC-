using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace OptimisationImages;

public static class ImageProcessor
{
    public static readonly string[] SupportedExtensions = [".jpg", ".jpeg", ".png", ".bmp", ".webp"];

    // VERSION SANS OPTIMISATION 
    public static void ProcessSequential(IEnumerable<string> files, string outputFolder)
    {
        Directory.CreateDirectory(outputFolder);

        foreach (var file in files)
            ProcessFile(file, outputFolder);
    }

    // VERSION AVEC OPTIMISATION 
    public static void ProcessParallel(IEnumerable<string> files, string outputFolder)
    {
        Directory.CreateDirectory(outputFolder);

        Parallel.ForEach(files, file => ProcessFile(file, outputFolder));
    }

    private static void ProcessFile(string file, string outputFolder)
    {
        using var source = Image.Load(file);

        foreach (var resolution in Resolution.All)
        {
            using var resized = source.Clone(x => x.Resize(resolution.Width, 0));
            SaveImage(resized, file, outputFolder, resolution);
        }
    }

    private static void SaveImage(Image image, string sourcePath, string outputFolder, Resolution resolution)
    {
        var fileName   = Path.GetFileNameWithoutExtension(sourcePath);
        var extension  = Path.GetExtension(sourcePath);
        var outputPath = Path.Combine(outputFolder, $"{fileName}_{resolution.Name}{extension}");

        image.Save(outputPath);
        Console.WriteLine($"  [OK] {fileName} -> {resolution.Name} ({image.Width}x{image.Height})");
    }
}
