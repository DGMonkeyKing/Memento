using UnityEngine;
using TMPro;
using DGMKCollections.Memento.Items.Data;

namespace DGMKCollections.Score
{
    public class Score : MonoBehaviour
    {
        public delegate void ScoreEvents();
        public event ScoreEvents MaxScoreReached;

        private int _score = 0;

        [SerializeField]
        private int _maxScore = 0;
        public int GetScore => _score;
        public int GetMaxScore => _maxScore;


        [SerializeField]
        private TextMeshProUGUI _tmp;

        private void Awake() 
        {  
            _tmp = GetComponent<TextMeshProUGUI>();
            ModifyScoreText();
        }

        private void OnEnable() 
        {
            ScoreItem.AddScore += AddScore;    
        }

        private void OnDisable() 
        {    
            ScoreItem.AddScore -= AddScore;
        }

        public void AddScore(int modifier)
        {
            _score += modifier;
            ModifyScoreText();

            if(_score == _maxScore) MaxScoreReached?.Invoke();
        }

        public void ResetScore()
        {
            _score = 0;
            ModifyScoreText();
        }

        private void ModifyScoreText()
        {
            if(_tmp != null) 
            {
                _tmp.text = _score.ToString();
                if(_maxScore > 0) _tmp.text += " / " + _maxScore;
            }
        }
    }
}
