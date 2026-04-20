# Optimisation des images (MVP)

Programme console en C# qui redimensionne des images en plusieurs résolutions (1080p, 720p, 480p).
Séquentielle vs Parallèle !

## Archi
Resolution.cs  -> La liste des 3 résolutions cibles est dedans.

ImageProcessor.cs -> Les deux versions (séquentielle / parallèle), et pour chaque image : on charge une fois, on clone 3 fois, on sauvegarde.

Program.cs —> Liste les images dispo, demande quoi traiter, quel mode, et affiche le temps / les gains.

## Utilisation

1. Déposer les images dans le dossier `images/`
2. Lancer avec F5 
3. Choisir une image (ou "tous")
4. Choisir le mode : séquentiel, parallèle, ou les deux pour comparer
5. Les images modifiées apparaissent dans `output/`


## Les deux approches

**Séquentielle** — chaque opération attend la précédente :
```csharp
foreach (var file in files)
    ProcessFile(file, outputFolder);
```

**Parallèle** — les images sont traitées en même temps sur les threads disponibles :
```csharp
Parallel.ForEach(files, file => ProcessFile(file, outputFolder));
```

Dans les deux cas, chaque image est chargée **une seule fois** puis clonée pour chaque résolution.



## Résultats

Tests effectués sur 5 images :

| Version      | Temps   |
|--------------|---------|
| Séquentielle | 2543 ms |
| Parallèle    | 1889 ms |
| Gain         | ~26%    |

26% de gain c'est pas exceptionnel parce que même en parallèle, toutes les images passent par le même disque. 
Peut-être qu'avec plus d'images, le gain serait plus significatif.


## Visuel des étapes du test de l'app 

-----_|Optimisator|_-----

Images disponibles :

  [1] canaro.jpg
  [2] catto.jpg
  [3] dogo.png
  [4] oiso.jpg
  [5] singo.jpg

Numéro de l'image (ou "tous") : tous

Mode :

  [1] Séquentiel  (sans optimisation)
  [2] Parallèle   (avec optimisation)
  [3] Comparer les deux

Choix : 3

[Séquentiel] Traitement en cours...

  [OK] canaro -> 1080p (1920x2016)
  [OK] canaro -> 720p (1280x1344)
  [OK] canaro -> 480p (854x897)
  [OK] catto -> 1080p (1920x2885)
  [OK] catto -> 720p (1280x1923)
  [OK] catto -> 480p (854x1283)
  [OK] dogo -> 1080p (1920x1241)
  [OK] dogo -> 720p (1280x828)
  [OK] dogo -> 480p (854x552)
  [OK] oiso -> 1080p (1920x2762)
  [OK] oiso -> 720p (1280x1841)
  [OK] oiso -> 480p (854x1228)
  [OK] singo -> 1080p (1920x2560)
  [OK] singo -> 720p (1280x1707)
  [OK] singo -> 480p (854x1139)

[Séquentiel] Terminé en 2543 ms.

[Parallèle] Traitement en cours...

  [OK] canaro -> 1080p (1920x2016)
  [OK] singo -> 1080p (1920x2560)
  [OK] canaro -> 720p (1280x1344)
  [OK] oiso -> 1080p (1920x2762)
  [OK] canaro -> 480p (854x897)
  [OK] singo -> 720p (1280x1707)
  [OK] catto -> 1080p (1920x2885)
  [OK] oiso -> 720p (1280x1841)
  [OK] singo -> 480p (854x1139)
  [OK] oiso -> 480p (854x1228)
  [OK] catto -> 720p (1280x1923)
  [OK] catto -> 480p (854x1283)
  [OK] dogo -> 1080p (1920x1241)
  [OK] dogo -> 720p (1280x828)
  [OK] dogo -> 480p (854x552)

[Parallèle] Terminé en 1889 ms.

--- Comparaison ---
  Séquentiel : 2543 ms
  Parallèle  : 1889 ms
  Gain       : 654 ms (26% plus rapide)

## STack
SixLabors.ImageSharp (v3.0.0) 