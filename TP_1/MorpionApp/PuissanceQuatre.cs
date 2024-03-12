using MorpionApp.interfaces;

namespace MorpionApp
{
    public class PuissanceQuatre
    {
        public bool quiterJeu = false;
        public bool tourDuJoueur = true;
        public IGrille grille;

        public PuissanceQuatre()
        {
            this.grille = new Grille(4, 7);
        }

        public void BoucleJeu()
        {
            while (!quiterJeu)
            {
                grille.InitGrille(' ');
                while (!quiterJeu)
                {
                    char joueur = tourDuJoueur ? 'X' : 'O';
                    TourJoueur(joueur);
                    if (verifVictoire(joueur))
                    {
                        finPartie($"Le joueur {(tourDuJoueur ? 1 : 2)} à gagné !");
                        break;
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
            var (row, column) = (0, 0);
            bool moved = false;

            while (!quiterJeu && !moved)
            {
                Sortie.Nettoyer();
                affichePlateau();
                Sortie.AfficherMessage("Choisir une case valide est appuyer sur [Entrer]");
                Entree.DefinirPositionCurseur(column * 4 + 2, 0);

                switch (Entree.LireTouche(true).Key)
                {
                    case ConsoleKey.Escape:
                        quiterJeu = true;
                        Sortie.Nettoyer();
                        break;

                    case ConsoleKey.RightArrow:
                        column = (column + 1) % 7;
                        break;

                    case ConsoleKey.LeftArrow:
                        column = (column + 6) % 7;
                        break;

                    case ConsoleKey.Enter:
                        row = FindEmptyRow(column);
                        if (row != -1)
                        {
                            grille.PlacerJeton(row, column, joueur);
                            moved = true;
                        }
                        break;
                }
            }
        }

        private int FindEmptyRow(int column)
        {
            for (int i = 3; i >= 0; i--)
            {
                if (grille.JoueurPossedantJeton(i, column) == ' ')
                {
                    return i;
                }
            }
            return -1;
        }

        public void affichePlateau()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Sortie.AfficherLigne($" {grille.JoueurPossedantJeton(i, j)} ");
                    if (j < 6)
                    {
                        Sortie.AfficherLigne("|");
                    }
                }
                Sortie.AfficherMessage("\n");
                if (i < 3)
                {
                    Sortie.AfficherMessage("-----------------------------");
                }
            }
        }

        public bool verifVictoire(char c) =>
            CheckRows(c) || CheckColumns(c) || CheckDiagonals(c);

        private bool CheckRows(char c)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (grille.JoueurPossedantJeton(i, j) == c && grille.JoueurPossedantJeton(i, j + 1) == c && grille.JoueurPossedantJeton(i, j + 2) == c && grille.JoueurPossedantJeton(i, j + 3) == c)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckColumns(char c)
        {
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 1; i++)
                {
                    if (grille.JoueurPossedantJeton(i, j) == c && grille.JoueurPossedantJeton(i + 1, j) == c && grille.JoueurPossedantJeton(i + 2, j) == c && grille.JoueurPossedantJeton(i + 3, j) == c)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckDiagonals(char c)
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (grille.JoueurPossedantJeton(i, j) == c && grille.JoueurPossedantJeton(i + 1, j + 1) == c && grille.JoueurPossedantJeton(i + 2, j + 2) == c && grille.JoueurPossedantJeton(i + 3, j + 3) == c)
                    {
                        return true;
                    }
                }
            }
            for (int i = 3; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (grille.JoueurPossedantJeton(i, j) == c && grille.JoueurPossedantJeton(i - 1, j + 1) == c && grille.JoueurPossedantJeton(i - 2, j + 2) == c && grille.JoueurPossedantJeton(i - 3, j + 3) == c)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool verifEgalite()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (grille.JoueurPossedantJeton(i, j) == ' ')
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
}
