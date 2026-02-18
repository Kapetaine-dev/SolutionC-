Console.WriteLine("--- Calculatrice ---");
Console.WriteLine("Entrez votre opération :");

string input = Console.ReadLine();
string[] parts = input.Split(' ');

if (parts.Length != 3 || !double.TryParse(parts[0], out double num1) || !double.TryParse(parts[2], out double num2))
{
    Console.WriteLine("Format invalide. Faites par exemple : 1 + 1");
    return;
}

double result = parts[1] switch
{
    "+" => num1 + num2,
    "-" => num1 - num2,
    "*" => num1 * num2,
    "/" => num1 / num2,//on pourrait mettre une condition si /0 -> erreur mais bon 
    _ => throw new InvalidOperationException("Mauvais opérateur")
};

Console.WriteLine($"Résultat : {result}");