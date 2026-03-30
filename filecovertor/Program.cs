using FileConvertor;
using FileConvertor.Interfaces;
using FileConvertor.Services;

var csvReader = new CsvReader();
var csvWriter = new CsvWriter();
var jsonWriter = new JsonWriter();
var dataService = new DataService();

Console.WriteLine("=== FileConvertor ===");
var sourcePath = "JeuDeCartes.csv";

var manager = new ConvertorManager(csvReader, csvWriter, dataService);
manager.Load(sourcePath);

var running = true;
while (running)
{
    Console.WriteLine("\n1. Prévisualiser  2. Rechercher  3. Trier  4. Exporter  5. Quitter");
    Console.Write("> ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            manager.Preview();
            break;

        case "2":
            Console.Write("Mot-clé : ");
            manager.Preview(keyword: Console.ReadLine());
            break;

        case "3":
            Console.WriteLine("Champs disponibles : " + string.Join(", ", manager.GetHeaders()));
            Console.Write("Trier par : ");
            var field = Console.ReadLine();
            Console.Write("Ordre croissant ? (o/n) : ");
            manager.Preview(sortField: field, ascending: Console.ReadLine() != "n");
            break;

        case "4":
            Console.Write("Nom du fichier de sortie (.csv ou .json) : ");
            var outputName = Console.ReadLine() ?? "output.csv";
            var outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", outputName);

            Console.WriteLine("Champs dispo : " + string.Join(", ", manager.GetHeaders()));
            Console.Write("Champs à exporter (vide = tous) : ");
            var input = Console.ReadLine();

            var selectedFields = string.IsNullOrWhiteSpace(input)
                ? null
                : input.Split(',').Select(f => f.Trim()).ToList();

            IWriter chosenWriter = outputPath.EndsWith(".json") ? new JsonWriter() : new CsvWriter();
            var exportManager = new ConvertorManager(csvReader, chosenWriter, dataService);
            exportManager.Load(sourcePath);
            exportManager.Export(outputPath, selectedFields);
            break;

        case "5":
            running = false;
            break;
    }
}