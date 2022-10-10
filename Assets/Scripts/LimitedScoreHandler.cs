using UnityEngine;
using DGMKCollections.Memento.Items.Data;
using TMPro;

namespace DGMKCollections.Score
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LimitedScoreHandler : MonoBehaviour
    {
        private Score _score;
        private TextMeshProUGUI _tmp;

        private void Awake() 
        {
            _score = new Score();    
            _tmp = GetComponent<TextMeshProUGUI>();
        }
        
        private void OnEnable() 
        {
            ScoreItem.AddScore += ScoreModified;
        }

        private void OnDisable() 
        {
            ScoreItem.AddScore -= ScoreModified;   
        }

        void ScoreModified(int modifier)
        {
            _score.AddScore(modifier);
            _tmp.text = _score.GetScore.ToString();
        }
    }
}