public class CarteLaplusHaute : Main
{
    public CarteLaplusHaute() 
    { 
        Nom = "Carte la plus haute";
        Probabilite = 37.26;
    }

    public override string Description() => "Aucune combinaison";
}

public class Paire : Main
{
    public Paire() 
    { 
        Nom = "Paire";
        Probabilite = 42.26;
    }

    public override string Description() => "Paire de Dame";
}

public class DeuxPaires : Main
{
    public DeuxPaires() 
    { 
        Nom = "Deux Paires";
        Probabilite = 4.75;
    }

    public override string Description() => "Deux paires: Roi et 5";
}

public class Brelan : Main
{
    public Brelan() 
    { 
        Nom = "Brelan";
        Probabilite = 4.83;
    }

    public override string Description() => "Brelan de 10";
}

public class Couleur : Main
{
    public Couleur() 
    { 
        Nom = "Couleur";
        Probabilite = 3.03;
    }

    public override string Description() => "Couleur de Pique";
}

public class Suite : Main
{
    public Suite() 
    { 
        Nom = "Suite";
        Probabilite = 4.62;
    }

    public override string Description() => "Suite: 5-6-7-8-9";
}

public class Full : Main
{
    public Full() 
    { 
        Nom = "Full";
        Probabilite = 2.60;
    }

    public override string Description() => "Full aux As";
}

public class Carre : Main
{
    public Carre() 
    { 
        Nom = "Carré";
        Probabilite = 0.168;
    }

    public override string Description() => "Carre de 8";
}

public class QuinteFlush : Main
{
    public QuinteFlush() 
    { 
        Nom = "Quinte Flush";
        Probabilite = 0.0279;
    }

    public override string Description() => "Quinte Flush: 5-6-7-8-9 de Carreau";
}

public class QuinteFlushRoyale : Main
{
    public QuinteFlushRoyale() 
    { 
        Nom = "Quinte Flush Royale";
        Probabilite = 0.0032;
    }

    public override string Description() => "Quinte Flush Royale: 10-V-D-R-A de Coeur";
}
