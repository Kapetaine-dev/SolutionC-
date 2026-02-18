public class GestionnaireCombinaisonsPoker
{
    private readonly Dictionary<int, Main> _combinaisons = new();

    public GestionnaireCombinaisonsPoker()
    {
        _combinaisons[1] = new CarteLaplusHaute();
        _combinaisons[2] = new Paire();
        _combinaisons[3] = new DeuxPaires();
        _combinaisons[4] = new Brelan();
        _combinaisons[5] = new Suite();
        _combinaisons[6] = new Couleur();
        _combinaisons[7] = new Full();
        _combinaisons[8] = new Carre();
        _combinaisons[9] = new QuinteFlush();
        _combinaisons[10] = new QuinteFlushRoyale();
    }

    public void AfficherMenu()
    {
        Console.Clear();
        Console.WriteLine("\n╔═══════════════════════════════════════╗");
        Console.WriteLine("║   COMBINAISONS POKER                 ║");
        Console.WriteLine("╚═══════════════════════════════════════╝\n");

        foreach (var kvp in _combinaisons)
        {
            Console.WriteLine($"{kvp.Key}  - {kvp.Value.Nom}");
        }

        Console.WriteLine("\n0 - Quitter\n");
    }

    public void AfficherCombinaisonDetail(int choix)
    {
        if (!_combinaisons.ContainsKey(choix))
        {
            Console.WriteLine(" Choix invalide!");
            return;
        }

        var combinaison = _combinaisons[choix];

        CreerExemple(choix, combinaison);

        Console.WriteLine("\n" + new string('=', 40));
        Console.WriteLine($" {combinaison.Nom}");
        Console.WriteLine(new string('═', 40));

        combinaison.AfficherCartes();

        Console.WriteLine(combinaison.Description());
        Console.WriteLine($"\nProbabilite: {combinaison.Probabilite}%");
        Console.WriteLine($"Chance: 1 sur {Math.Round(100 / combinaison.Probabilite, 0)}");

        AfficherBarreChance(combinaison.Probabilite);
    }

    private void CreerExemple(int choix, Main combinaison)
    {
        switch (choix)
        {
            case 1:
                combinaison.AjouterCarte(new Carte("Pique", "As"));
                combinaison.AjouterCarte(new Carte("Coeur", "Roi"));
                combinaison.AjouterCarte(new Carte("Trefle", "Dame"));
                combinaison.AjouterCarte(new Carte("Carreau", "Valet"));
                combinaison.AjouterCarte(new Carte("Pique", "9"));
                break;
            case 2:
                combinaison.AjouterCarte(new Carte("Pique", "Dame"));
                combinaison.AjouterCarte(new Carte("Coeur", "Dame"));
                break;
            case 3:
                combinaison.AjouterCarte(new Carte("Pique", "Roi"));
                combinaison.AjouterCarte(new Carte("Coeur", "Roi"));
                combinaison.AjouterCarte(new Carte("Trefle", "5"));
                combinaison.AjouterCarte(new Carte("Carreau", "5"));
                break;
            case 4:
                combinaison.AjouterCarte(new Carte("Pique", "10"));
                combinaison.AjouterCarte(new Carte("Coeur", "10"));
                combinaison.AjouterCarte(new Carte("Trefle", "10"));
                break;
            case 5:
                combinaison.AjouterCarte(new Carte("Pique", "5"));
                combinaison.AjouterCarte(new Carte("Coeur", "6"));
                combinaison.AjouterCarte(new Carte("Trefle", "7"));
                combinaison.AjouterCarte(new Carte("Carreau", "8"));
                combinaison.AjouterCarte(new Carte("Pique", "9"));
                break;
            case 6:
                combinaison.AjouterCarte(new Carte("Pique", "As"));
                combinaison.AjouterCarte(new Carte("Pique", "Roi"));
                combinaison.AjouterCarte(new Carte("Pique", "Dame"));
                combinaison.AjouterCarte(new Carte("Pique", "Valet"));
                combinaison.AjouterCarte(new Carte("Pique", "9"));
                break;
            case 7:
                combinaison.AjouterCarte(new Carte("Pique", "As"));
                combinaison.AjouterCarte(new Carte("Coeur", "As"));
                combinaison.AjouterCarte(new Carte("Trefle", "As"));
                combinaison.AjouterCarte(new Carte("Carreau", "Roi"));
                combinaison.AjouterCarte(new Carte("Pique", "Roi"));
                break;
            case 8:
                combinaison.AjouterCarte(new Carte("Pique", "8"));
                combinaison.AjouterCarte(new Carte("Coeur", "8"));
                combinaison.AjouterCarte(new Carte("Trefle", "8"));
                combinaison.AjouterCarte(new Carte("Carreau", "8"));
                break;
            case 9:
                combinaison.AjouterCarte(new Carte("Carreau", "5"));
                combinaison.AjouterCarte(new Carte("Carreau", "6"));
                combinaison.AjouterCarte(new Carte("Carreau", "7"));
                combinaison.AjouterCarte(new Carte("Carreau", "8"));
                combinaison.AjouterCarte(new Carte("Carreau", "9"));
                break;
            case 10:
                combinaison.AjouterCarte(new Carte("Coeur", "10"));
                combinaison.AjouterCarte(new Carte("Coeur", "V"));
                combinaison.AjouterCarte(new Carte("Coeur", "D"));
                combinaison.AjouterCarte(new Carte("Coeur", "R"));
                combinaison.AjouterCarte(new Carte("Coeur", "A"));
                break;
        }
    }

    private void AfficherBarreChance(double probabilite)
    {
        int taille = 25;
        int rempli = (int)((probabilite / 100) * taille);

        Console.Write("\n   ");
        for (int i = 0; i < taille; i++)
        {
            Console.Write(i < rempli ? "#" : "-");
        }
        Console.WriteLine();
    }
}
