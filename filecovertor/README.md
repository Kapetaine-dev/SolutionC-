# FileConvertor

Application console C# .NET 10 pour convertir, consulter et manipuler des fichiers de données (CSV/JSON).
Explication de l'architecture, des fonctionnalités et de l'utilisation du projet.

---

## Architecture du Projet

### Point d'Entrée
- **Program.cs** : Interface utilisateur interactive. Gère le menu principal et les actions utilisateur (prévisualisation, recherche, tri, export).

### Modèles de Données
- **Models/Data.cs** : Classe représentant une ligne de données avec un dictionnaire de champs clé-valeur.

### Interfaces
- **Interfaces/IReader.cs** : Contrat pour les lecteurs de fichiers (méthodes `Read()` et `GetHeaders()`).
- **Interfaces/IWriter.cs** : Contrat pour les writers de fichiers (méthode `Write()`).

### Services de Lecture/Écriture
- **Services/CsvReader.cs** : Lecture de fichiers CSV avec parsing des lignes et headers.
- **Services/JsonReader.cs** : Lecture de fichiers JSON avec désérialisation.
- **Services/CsvWriter.cs** : Écriture de données en format CSV avec sélection de champs.
- **Services/JsonWriter.cs** : Écriture de données en format JSON avec sélection de champs.

### Logique Métier
- **Services/DataService.cs** : Opérations sur les données (recherche par mot-clé, tri par champ, filtrage, affichage formaté).
- **ConvertorManager.cs** : Orchestrateur principal. Charge les données, applique les transformations et exporte via le writer approprié.

---

## Utilisation

```bash
dotnet run
```

Le programme charge le fichier `JeuDeCartes.csv` et propose un menu pour :
1. Prévisualiser les données
2. Rechercher par mot-clé
3. Trier par champ
4. Exporter en CSV ou JSON
5. Quitter

---
