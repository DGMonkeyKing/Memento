using System.Collections;
using UnityEngine;
using DGMKCollections.Rankings;
using System.Collections.Generic;
using System;

namespace DGMKCollections.Memento.UI
{
    public class InitialPanel : UIPanel
    {
        private Ranking _ranking;

        [SerializeField]
        private List<UIRankingEntries> _uiRankingsEntries;
        
        void Awake()
        {
            _ranking = new Ranking(_uiRankingsEntries.Count);
            
            RetrieveDataIfPossible();

            for(int i = 0; i < _uiRankingsEntries.Count; i++)
            {
                _uiRankingsEntries[i].SetPosition(i+1);
                _uiRankingsEntries[i].ChangeInfo(
                    _ranking.GetPositionName(i),
                    _ranking.GetPositionScore(i)
                );
            }
            
            void RetrieveDataIfPossible()
            {
                RankingData data = SaveManager.Load();
                if(data != null)
                {
                    for(int i = 0; i < _uiRankingsEntries.Count; i++)
                    {
                        _ranking.PutNewEntryInRanking(data.name[i], data.score[i]);
                    }
                }
            }
        }

        public void ChangeRanking(string name, float milliseconds)
        {
            _ranking.PutNewEntryInRanking(name, milliseconds);
            RankingEntry re;

            for(int i = 0; i < _uiRankingsEntries.Count; i++)
            {
                re = _ranking.Entries[i];
                _uiRankingsEntries[i].ChangeInfo(re.EntryName, re.EntryScore);
            }
        }

        public int CheckPosition(float milliseconds)
        {
            return _ranking.CheckPositionInRanking(milliseconds);
        }
    }
}