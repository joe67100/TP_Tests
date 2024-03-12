namespace MorpionApp
{
    public class Sortie
    {
        public static void AfficherMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void AfficherLigne(string message)
        {
            Console.Write(message);
        }

        public static void Nettoyer()
        {
            Console.Clear();
        }
    }
}
