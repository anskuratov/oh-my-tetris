using UnityEngine;

namespace Assets.Gameplay
{
    public class GameModel
    {
        private const float _tickRateLevelDecrementor = 0.05f;
        private const int _scoreIncrementor = 20;

        public float SecondsBetweenTicks { get; private set; }
        public int PlayingFieldWidth { get; private set; }
        public int PlayingFieldHeight { get; private set; }
        public int FigureSize { get; private set; }

        private int _score;
        public int Score
        {
            get
            {
                return _score;
            }
            private set
            {
                _score = value;

                if (_score % 100 == 0)
                    DecrementGameTickTime();
            }
        }

        public GameModel()
        {
            SecondsBetweenTicks = 1f;
            Score = 0;

            PlayingFieldWidth = PlayerPrefs.GetInt("GameFieldWidth");
            PlayingFieldHeight = PlayerPrefs.GetInt("GameFieldHeight");
            FigureSize = PlayerPrefs.GetInt("FigureCellsNumber");
        }

        private void DecrementGameTickTime()
            => SecondsBetweenTicks -= _tickRateLevelDecrementor;

        public void IncrementScore()
            => Score += _scoreIncrementor;
    }
}
