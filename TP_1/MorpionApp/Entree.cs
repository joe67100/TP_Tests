namespace MorpionApp
{
    public class Entree
    {
        public static ConsoleKeyInfo LireTouche(bool intercept)
        {
            return Console.ReadKey(intercept);
        }

        public static string LireLigne()
        {
            return Console.ReadLine();
        }

        public static void DefinirPositionCurseur(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
    }
}
