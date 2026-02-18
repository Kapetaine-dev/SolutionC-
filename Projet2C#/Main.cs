public abstract class Main
{
    protected List<Carte> cartes = new();

    public string Nom { get; protected set; } = "Main";
    public double Probabilite { get; protected set; } = 0;

    public void AjouterCarte(Carte carte) => cartes.Add(carte);

    public void AfficherCartes()
    {
        Console.WriteLine($"\n{Nom}:");
        foreach (var carte in cartes)
            Console.WriteLine($"  - {carte}");
    }

    public abstract string Description();
}
