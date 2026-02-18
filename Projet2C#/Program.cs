var gestionnaire = new GestionnaireCombinaisonsPoker();
bool actif = true;

while (actif)
{
    gestionnaire.AfficherMenu();

    Console.Write("Votre choix: ");
    if (int.TryParse(Console.ReadLine(), out int choix))
    {
        if (choix == 0)
        {
            Console.WriteLine("\nAu revoir!");
            actif = false;
        }
        else if (choix >= 1 && choix <= 10)
        {
            gestionnaire.AfficherCombinaisonDetail(choix);
            Console.Write("\nAppuyez sur Entree...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Choix invalide!");
            Console.Write("Appuyez sur Entree...");
            Console.ReadLine();
        }
    }
}
