namespace DGMKCollections.Score
{
    public class Score
    {
        private int _score = 0;
        public int GetScore => _score;

        public void AddScore(int modifier) => _score += modifier;
        public void ResetScore() => _score = 0;
    }
}
