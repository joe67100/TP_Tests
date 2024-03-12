namespace MorpionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool quitter = false;
            while (!quitter)
            {
                Sortie.AfficherMessage("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");
                ConsoleKey key = Entree.LireTouche(true).Key;
                while (key != ConsoleKey.X && key != ConsoleKey.P)
                {
                    key = Entree.LireTouche(true).Key;
                }

                switch (key)
                {
                    case ConsoleKey.X:
                        Morpion morpion = new Morpion();
                        morpion.BoucleJeu();
                        break;
                    case ConsoleKey.P:
                        PuissanceQuatre puissanceQuatre = new PuissanceQuatre();
                        puissanceQuatre.BoucleJeu();
                        break;
                }

                Sortie.AfficherMessage("Jouer à un autre jeu ? Taper [R] pour changer de jeu. Taper [Echap] pour quitter.");
                key = Entree.LireTouche(true).Key;
                while (key != ConsoleKey.R && key != ConsoleKey.Escape)
                {
                    key = Entree.LireTouche(true).Key;
                }

                if (key == ConsoleKey.Escape)
                {
                    quitter = true;
                }
            }
        }
    }
}
