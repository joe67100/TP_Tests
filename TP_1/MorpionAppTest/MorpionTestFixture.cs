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
                morpion.grille.PlacerJeton(ligne, col, joueur);
            }
        }

        protected void SetDiagonaleVictorieuse(char joueur)
        {
            morpion.grille.PlacerJeton(0, 0, joueur);
            morpion.grille.PlacerJeton(1, 1, joueur);
            morpion.grille.PlacerJeton(2, 2, joueur);
        }

        protected void SetColonneVictorieuse(char joueur, int colonne)
        {
            for (int ligne = 0; ligne < 3; ligne++)
            {
                morpion.grille.PlacerJeton(ligne, colonne, joueur);
            }
        }

        protected void SetGrillePleine()
        {
            char joueur = 'X';
            for (int ligne = 0; ligne < 3; ligne++)
            {
                for (int col = 0; col < 3; col++)
                {
                    morpion.grille.PlacerJeton(ligne, col, joueur);
                    joueur = joueur == 'X' ? 'O' : 'X';
                }
            }
        }
    }
}
