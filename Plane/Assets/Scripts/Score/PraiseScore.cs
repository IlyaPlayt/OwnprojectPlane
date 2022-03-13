using UnityEngine;

namespace Sample
{
    public class PraiseScore: IScoreInformation

    {
        private IScoreInformation _scoreInformation;
        public PraiseScore(IScoreInformation score)
        {
            _scoreInformation = score;
        }

        public void ShowScore()
        {
            _scoreInformation.ShowScore();
            Debug.Log("You have the best score");
        }
    }
}