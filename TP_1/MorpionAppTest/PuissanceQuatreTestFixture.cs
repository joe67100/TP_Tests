using MorpionApp;

namespace MorpionAppTest
{
    public class PuissanceQuatreTestFixture
    {
        protected PuissanceQuatre puissanceQuatre;

        public PuissanceQuatreTestFixture()
        {
            puissanceQuatre = new PuissanceQuatre();
        }

        protected void SetLigneVictorieuse(char joueur, int ligne)
        {
            for (int col = 0; col < 4; col++)
            {
                puissanceQuatre.grille.PlacerJeton(ligne, col, joueur);
            }
        }

        protected void SetColonneVictorieuse(char joueur, int colonne)
        {
            for (int ligne = 0; ligne < 4; ligne++)
            {
                puissanceQuatre.grille.PlacerJeton(ligne, colonne, joueur);
            }
        }

        protected void SetDiagonaleVictorieuse(char joueur)
        {
            for (int i = 0; i < 4; i++)
            {
                puissanceQuatre.grille.PlacerJeton(i, i, joueur);
            }
        }
    }
}
