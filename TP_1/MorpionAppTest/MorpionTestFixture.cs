using MorpionApp;

namespace MorpionAppTest
{
    public class MorpionTestFixture
    {
        protected Morpion morpion;

        public MorpionTestFixture()
        {
            morpion = new Morpion();
        }

        protected void SetLigneVictorieuse(char joueur, int ligne)
        {
            for (int col = 0; col < 3; col++)
            {
                morpion.grille[ligne, col] = joueur;
            }
        }

        protected void SetDiagonaleVictorieuse(char joueur)
        {
            morpion.grille[0, 0] = joueur;
            morpion.grille[1, 1] = joueur;
            morpion.grille[2, 2] = joueur;
        }

        protected void SetColonneVictorieuse(char joueur, int colonne)
        {
            for (int ligne = 0; ligne < 3; ligne++)
            {
                morpion.grille[ligne, colonne] = joueur;
            }
        }
    }
}