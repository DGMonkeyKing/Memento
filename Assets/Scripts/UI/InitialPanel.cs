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

        void OnEnable()
        {

        }

        void OnDisable()
        {
            
        }

        public int CheckPosition(float milliseconds)
        {
            return _ranking.CheckPosition(milliseconds);
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }
    }
}