using MorpionApp.interfaces;

public class Grille : IGrille
{
    protected char[,] grille;

    public Grille(int rows, int columns, char defaultValue = ' ')
    {
        grille = new char[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                grille[i, j] = defaultValue;
            }
        }
    }

    public void PlacerJeton(int i, int j, char joueur)
    {
        grille[i, j] = joueur;
    }

    public char JoueurPossedantJeton(int i, int j)
    {
        return grille[i, j];
    }

    public char[,] GetGrille()
    {
        return grille;
    }

    public void InitGrille(char defaultValue = ' ')
    {
        for (int i = 0; i < grille.GetLength(0); i++)
        {
            for (int j = 0; j < grille.GetLength(1); j++)
            {
                grille[i, j] = defaultValue;
            }
        }
    }
}
