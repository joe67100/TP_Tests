namespace MorpionAppTest
{
    public class PuissanceQuatreTest : PuissanceQuatreTestFixture
    {
        [Theory]
        [InlineData('X', 0)]
        [InlineData('O', 1)]
        [InlineData('X', 2)]
        [InlineData('O', 3)]
        public void VerifVictoire_Horizontale_ToutesLignes(char joueur, int ligne)
        {
            SetLigneVictorieuse(joueur, ligne);
            bool victoire = puissanceQuatre.verifVictoire(joueur);
            Assert.True(victoire, $"Le joueur {joueur} devrait avoir gagné horizontalement (ligne {ligne + 1}).");
        }

        [Theory]
        [InlineData('X', 0)]
        [InlineData('O', 1)]
        [InlineData('X', 2)]
        [InlineData('O', 3)]
        public void VerifVictoire_Verticale_ToutesColonnes(char joueur, int colonne)
        {
            SetColonneVictorieuse(joueur, colonne);
            bool victoire = puissanceQuatre.verifVictoire(joueur);
            Assert.True(victoire, $"Le joueur {joueur} devrait avoir gagné verticalement (colonne {colonne + 1}).");
        }

        [Fact]
        public void VerifVictoire_Diagonale_Joueur1()
        {
            SetDiagonaleVictorieuse('X');
            bool victoire = puissanceQuatre.verifVictoire('X');
            Assert.True(victoire, "Le joueur 1 devrait avoir gagné en diagonale.");
        }

        [Fact]
        public void VerifVictoire_Diagonale_Joueur2()
        {
            SetDiagonaleVictorieuse('O');
            bool victoire = puissanceQuatre.verifVictoire('O');
            Assert.True(victoire, "Le joueur 2 devrait avoir gagné en diagonale.");
        }
    }
}


