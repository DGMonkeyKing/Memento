using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DGMKCollections.Score.Interfaces
{
    public interface IScoreModifier
    {
        delegate void ScoreModifier(int score = 0);
        static event ScoreModifier AddScore;
    }
}