# TP1 - Tests

## I. Difficultés liées à la validation

### Qualité faible

_La qualité du project actuelle est négativement impacté par plusieurs facteurs_

-   Présence de dysfonctionnements / bugs

Les deux classes, `PuissanceQuatre` et `Morpion`, présentent entre autres des bugs dans la fonction `verifVictoire`. Elles ne vérifient pas tous les cas de figure entraînant la poursuite de la partie malgré la victoire d'un des joueurs et inversement parfois la victoire survient sans que cela devrait se produire.

Parfois le même joueur joue une deuxième fois automatiquement

-   Performance faible

L'absence d'optimisation dans plusieurs fonctions (`verifVictoire`, `verifEgalite`) peut affecter la performance, surtout pour les grandes grilles.

**Axes de la qualité impactés**

-   Fiabilité

    -   Nombreux bugs
    -   Image dégradé car l'outil ne répond pas aux besoins correctement, il y a une inadéquation entre ce qui est attendu et le produit final

-   Efficacité

    -   L'architecture acutelle (pas d'architecture) ne garantit pas l'éfficacité du logiciel en phase d'exploitation

-   Maintenabilité
    -   La lisibilité du code actuel peut rendre la transférabilité du projet ardu
    -   Les nombreux défauts (code smells) présents sont une métrique témoignant de la faible qualité du projet

**Exemples concrets issus du code impactant la qualité**

-   Bloaters

> Méthodes trop longues

```csharp
public void tourJoueur()
public void BoucleJeu()
```

Certaines méthodes contiennent beaucoup trop de lignes, rendant le code difficile à lire. Elles font également trop de choses. Une méthode ne doit pas dépasser plus de **10 lignes** environ.

> Classes trop importantes

```csharp
public class Morpion {
	public void BoucleJeu(){...}
	public void tourJoueur(){...}
	public void tourJoueur2(){...}
	public void affichePlateau(){...}
	public void verifVictoire(){...}
	public void verifEgalite(){...}
	public void finPartie(){...}
}
```

Il n'y a que 3 classes dans ce projet. `Morpion`, `PuissanceQuatre`, `Program`. Chaque classe contient beaucoup trop de fonctions et de ligne de code. Elles font également tout, ce qui est une violation du Single Responsibility Principle (SRP)

> Obsession des primitives

```csharp
var (row, column) = (0, 0);
grille = new char[3, 3];
```

Utilisation abusive de primitives et de nombres magiques.

---

-   Object-Orientation Abusers

> Utilisation de switch non approprié

```csharp
switch (Console.ReadKey(true).Key)
{
    case ConsoleKey.Escape:
        quiterJeu = true;
        Console.Clear();
        break;

    case ConsoleKey.RightArrow:
        if (column >= 2)
        {
            column = 0;
        }
        else
        {
            column = column + 1;
        }
        break;

    case ConsoleKey.LeftArrow:
        if (column <= 0)
        {
            column = 2;
        }
        else
        {
            column = column - 1;
        }
        break;

    case...
    case...
    case...
}
```

---

-   "Dispensables"

Switch cases beaucoup trop longs et complexes rendant la lisibilité complexe.

> Code mort

```csharp
//case ConsoleKey.UpArrow:
//    if (row <= 0)
//    {
//        row = 3;
//    }
//    else
//    {
//        row = row - 1;
//    }
//    break;
```

Code commenté inutilisé

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
```

Imports inutilisés

> Duplicate code

```csharp
 public void tourJoueur()
 public void tourJoueur2()
```

Certaines fonctions sont dupliquées et effectuent exactement la même chose. Il y a **4** fois la fonction `tourJoueur` dans ce projet.

---

-   Autres difficultés :

> Complexité cyclomatique élevée

```csharp
public void BoucleJeu()
{
    while (!quiterJeu)
    {
        grille = new char[4, 7]
        {
            { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        };
        while (!quiterJeu)
        {
            if (tourDuJoueur)
            {
                tourJoueur();
                if (verifVictoire('X'))
                {
                    finPartie("Le joueur 1 à gagné !");
                    break;
                }
            }
            else
            {
                tourJoueur2();
                if (verifVictoire('O'))
                {
                    finPartie("Le joueur 2 à gagné !");
                    break;
                }
            }
            tourDuJoueur = !tourDuJoueur;
            if (verifEgalite())
            {
                finPartie("Aucun vainqueur, la partie se termine sur une égalité.");
                break;
            }
        }
        if (!quiterJeu)
        {
            Console.WriteLine("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
        GetKey:
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Enter:
                    break;
                case ConsoleKey.Escape:
                    quiterJeu = true;
                    Console.Clear();
                    break;
                default:
                    goto GetKey;
            }
        }

    }
}
```

Beaucoup trop d'indentation rendant le code difficilement lisible.

> Pas de gestion d'erreurs

> Pas de tests pour vérifier l'absence de dysfonctionnements

## II. Méthodes de résolution des problèmes

-   **Tests et identification des défauts**
    -   Écrire des tests unitaires pour chaque fonction du code afin de vérifier leur fonctionnement indépendant.
    -   Exécuter les tests sur le code actuel et identifier les tests qui échouent.
    -   Analyser les causes des échecs et identifier les bugs et les dysfonctionnements dans le code.

*   **Correction des défauts et refactorisation**

    -   Corriger les bugs identifiés en modifiant le code source.
    -   Appliquer des refactorisations pour améliorer la qualité du code, telles que :
        -   Découper les longues méthodes en fonctions plus petites et plus précises.
        -   Supprimer le code mort et les commentaires inutiles.
        -   Remplacer les primitives par des types personnalisés pour une meilleure encapsulation.
        -   Utiliser des structures de données appropriées pour représenter les données du jeu.
        -   Appliquer des principes de conception tels que SRP et KISS pour rendre le code plus flexible et maintenable.

*   **Nouvelle série de tests et validation**

    -   Exécuter à nouveau les tests unitaires sur le code refactorisé pour s'assurer que les corrections ont été apportées et que de nouveaux bugs n'ont pas été introduits.
    -   Effectuer des tests manuels pour tester le comportement global du jeu et s'assurer qu'il répond aux exigences.

*   **Amélioration continue**

    -   Ajouter de nouveaux tests pour couvrir les nouvelles fonctionnalités et les cas de bord.
    -   Mettre à jour la documentation du code pour refléter les modifications apportées.

## III. Développement des fonctionnalités manquantes

### Jouer contre l'ordinateur

Implémentation d'une fonctionnalité permettant de jouer contre l'ordinateur avec différents niveaux de difficulté.

### Persistance et historisation

Implémentation d'une fonctionnalité permettant de sauvegarder et charger une partie.

### Tests

Mise en place de process de tests et validation permettant de vérifier et valider l'existant.
