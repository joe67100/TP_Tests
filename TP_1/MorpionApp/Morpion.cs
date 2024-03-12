using MorpionApp;
using MorpionApp.interfaces;

public class Morpion
{
    public bool quiterJeu = false;
    public bool tourDuJoueur = true;
    public IGrille grille;

    public Morpion()
    {
        this.grille = new Grille(3,3);
    }

    public void BoucleJeu()
    {
        while (!quiterJeu)
        {
            grille.InitGrille(' ');
            while (!quiterJeu && !verifEgalite())
            {
                char joueur = tourDuJoueur ? 'X' : 'O';
                TourJoueur(joueur);
                if (verifVictoire(joueur))
                {
                    finPartie($"Le joueur {(tourDuJoueur ? 1 : 2)} à gagné !");
                    break;
                }
                tourDuJoueur = !tourDuJoueur;
            }
            if (!quiterJeu && verifEgalite())
            {
                finPartie("Aucun vainqueur, la partie se termine sur une égalité.");
            }
            if (!quiterJeu)
            {
                Sortie.AfficherMessage("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
            GetKey:
                switch (Entree.LireTouche(true).Key)
                {
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Escape:
                        quiterJeu = true;
                        Sortie.Nettoyer();
                        break;
                    default:
                        goto GetKey;
                }
            }
        }
    }

    public void TourJoueur(char joueur)
    {
        bool moved = false;
        while (!moved)
        {
            Sortie.Nettoyer();
            affichePlateau();
            Sortie.AfficherMessage($"Joueur {joueur}, c'est votre tour. Entrez un numéro de case (1-9) : ");
            int caseNum = Convert.ToInt32(Entree.LireLigne()) - 1;
            int i = caseNum / 3;
            int j = caseNum % 3;
            if (grille.JoueurPossedantJeton(i, j) != 'X' && grille.JoueurPossedantJeton(i, j) != 'O')
            {
                grille.PlacerJeton(i, j, joueur);
                moved = true;
            }
            else
            {
                Sortie.AfficherMessage("Cette case est déjà occupée. Essayez encore.");
            }
        }
    }

    public void affichePlateau()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Sortie.AfficherLigne($" {grille.JoueurPossedantJeton(i, j)} ");
                if (j < 2)
                {
                    Sortie.AfficherLigne("|");
                }
            }
            if (i < 2)
            {
                Sortie.AfficherMessage("\n---+---+---");
            }
        }
        Sortie.AfficherMessage(" ");
    }

    public bool verifVictoire(char c) =>
        verifLignes(c) || verifColonnes(c) || verifDiagonales(c);

    public bool verifLignes(char c)
    {
        for (int i = 0; i < 3; i++)
        {
            if (grille.JoueurPossedantJeton(i, 0) == c && grille.JoueurPossedantJeton(i, 1) == c && grille.JoueurPossedantJeton(i, 2) == c)
            {
                return true;
            }
        }
        return false;
    }

    public bool verifColonnes(char c)
    {
        for (int j = 0; j < 3; j++)
        {
            if (grille.JoueurPossedantJeton(0, j) == c && grille.JoueurPossedantJeton(1, j) == c && grille.JoueurPossedantJeton(2, j) == c)
            {
                return true;
            }
        }
        return false;
    }

    public bool verifDiagonales(char c)
    {
        return (grille.JoueurPossedantJeton(0, 0) == c && grille.JoueurPossedantJeton(1, 1) == c && grille.JoueurPossedantJeton(2, 2) == c) ||
        (grille.JoueurPossedantJeton(0, 2) == c && grille.JoueurPossedantJeton(1, 1) == c && grille.JoueurPossedantJeton(2, 0) == c);
    }

    public bool verifEgalite()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (grille.JoueurPossedantJeton(i, j) != 'X' && grille.JoueurPossedantJeton(i, j) != 'O')
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void finPartie(string msg)
    {
        Sortie.Nettoyer();
        affichePlateau();
        Sortie.AfficherMessage(msg);
    }
}
