namespace MorpionApp.interfaces
{
    public interface IGrille
    {
        char[,] GetGrille();
        void InitGrille(char defaultValue);
        void PlacerJeton(int i, int j, char joueur);
        char JoueurPossedantJeton(int i, int j);
    }

}
