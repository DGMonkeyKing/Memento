using DGMKCollections.Memento.Components;
using DGMKCollections.Score.Interfaces;
using UnityEngine;

namespace DGMKCollections.Memento.Items.Data
{
    [CreateAssetMenu(fileName = "Score Item", menuName = "Memento/New Score Item", order = 0)]
    public class ScoreItem : ItemData, IScoreModifier
    {
        [SerializeField]
        private int scoreModifier = 0;

        public static event IScoreModifier.ScoreModifier AddScore;

        public override void MakeAction(Item item, Collector collector)
        {
            AddScore?.Invoke(scoreModifier);    
        }
    }
}
