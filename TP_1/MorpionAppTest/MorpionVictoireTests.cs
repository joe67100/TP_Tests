namespace MorpionAppTest
{
    public class MorpionVictoireTests : MorpionTestFixture
    {
        [Theory]
        [InlineData('X', 0)]
        [InlineData('O', 1)]
        [InlineData('X', 2)]
        public void VerifVictoire_Horizontale_ToutesLignes(char joueur, int ligne)
        {
            SetLigneVictorieuse(joueur, ligne);
            bool victoire = morpion.verifVictoire(joueur);
            Assert.True(victoire, $"Le joueur {joueur} devrait avoir gagné horizontalement (ligne {ligne + 1}).");
        }

        [Theory]
        [InlineData('X', 0)]
        [InlineData('O', 1)]
        [InlineData('X', 2)]
        public void VerifVictoire_Verticale_ToutesColonnes(char joueur, int colonne)
        {
            SetColonneVictorieuse(joueur, colonne);
            bool victoire = morpion.verifVictoire(joueur);
            Assert.True(victoire, $"Le joueur {joueur} devrait avoir gagné verticalement (colonne {colonne + 1}).");
        }

        [Fact]
        public void VerifVictoire_Diagonale_Joueur1()
        {
            SetDiagonaleVictorieuse('X');
            bool victoire = morpion.verifVictoire('X');
            Assert.True(victoire, "Le joueur 1 devrait avoir gagné en diagonale.");
        }

        [Fact]
        public void VerifVictoire_Diagonale_Joueur2()
        {
            SetDiagonaleVictorieuse('O');
            bool victoire = morpion.verifVictoire('O');
            Assert.True(victoire, "Le joueur 2 devrait avoir gagné en diagonale.");
        }

        [Fact]
        public void VerifVictoire_PasDeVictoire()
        {
            // Grille vide
            bool victoire = morpion.verifVictoire('X');
            Assert.False(victoire, "Il ne devrait pas y avoir de victoire avec une grille vide.");
        }
    }
}
