using System.Collections;
using UnityEngine;

namespace DGMKCollections.Memento.UI
{
    public class InitialPanel : UIPanel
    {
        private Ranking _ranking;

        [SerializeField]
        private UIRankingEntries[] _uiRankingsEntries;
        
        void Awake()
        {
            _ranking = new Ranking(_uiRankingsEntries.Length);

            for(int i = 0; i < _uiRankingsEntries.Length; i++)
            {
                _uiRankingsEntries[i].SetPosition(i+1);
                _uiRankingsEntries[i].ChangeInfo(_ranking.GetEntry(i));
            }
        }

        public void ChangeRanking(string name, float milliseconds)
        {
            _ranking.SetEntry(name, milliseconds);
            int position = CheckPosition(milliseconds);
            _uiRankingsEntries[position].ChangeInfo(_ranking.GetEntry(position));
        }

        public int CheckPosition(float milliseconds)
        {
            return _ranking.CheckPosition(milliseconds);
        }
    }
}