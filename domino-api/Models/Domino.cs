namespace domino_api.Models
{
    public class Domino
    {
        public int Left { get; set; }
        public int Right { get; set; }

        public Domino(int left, int right)
        {
            Left = left;
            Right = right;
        }

        public Domino() { }
    }
}
