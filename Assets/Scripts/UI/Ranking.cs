using System;
using System.Collections.Generic;
using UnityEngine;

namespace DGMKCollections.Rankings
{
    public class Ranking
    {
        List<RankingEntry> _entries;
        public List<RankingEntry> Entries => _entries;

        public Ranking(int _numberOfEntries)
        {
            _entries = new List<RankingEntry>();

            for(int i = 0; i < _numberOfEntries; i++)
            {
                _entries.Add(new RankingEntry());
            }
        }

#region PUBLIC_API
        public void PutNewEntryInRanking(string name, float score)
        {
            RankingEntry re = new RankingEntry(name, score);

            int position = CheckPositionInRanking(score);
            if(position >= 0) // Hemos encontrado una posicion
            {
                PutNewEntryInPosition(re, position);

                SaveStateOfRankingInFile();
            }
        }

        private void SaveStateOfRankingInFile()
        {
            SaveManager.Save(this);
        }

        public string GetPositionName(int position)
        {
            return _entries[position].EntryName;
        }

        public float GetPositionScore(int position)
        {
            return _entries[position].EntryScore;
        }

        // TODO: Reimplement using Divide y Vencerás.
        public int CheckPositionInRanking(float score)
        {
            int position = -1;

            if(_entries[_entries.Count - 1].EntryScore < score)
                return position;

            for(position = _entries.Count - 1; position > 0; position--)
            {
                RankingEntry e = _entries[position-1];

                if(e.EntryScore < score)
                {
                    // Hemos encontrado posición
                    return position;
                }
            }

            return position;
        }
#endregion

#region PRIVATE_METHODS
        private void PutNewEntryInPosition(RankingEntry re, int position)
        {
            _entries.Insert(position, re);
        }
#endregion
    }

    public class RankingEntry
    {
        public string EntryName;
        public float EntryScore;

        public RankingEntry()
        {
            EntryName = "---";
            EntryScore = float.MaxValue;
        }

        public RankingEntry(string name, float score)
        {
            EntryName = name;
            EntryScore = score;
        }

        // -1 : Entry is Lower
        // 0 : Entry is Equal
        // 1 : Entry is Bigger
        public int CompareToScore(float score)
        {
            int result = (int)(EntryScore - score);

            if(result != 0) result /= Math.Abs(result);

            return result;
        }

    }

    [Serializable]
    public class RankingData
    {
        public string[] name = new string[6];
        public float[] score = new float[6];

        public RankingData(Ranking ranking)
        {
            for(int i = 0; i < 6; i++)
            {
                name[i] = ranking.Entries[i].EntryName;
                score[i] = ranking.Entries[i].EntryScore;
            }
        }
    }
}