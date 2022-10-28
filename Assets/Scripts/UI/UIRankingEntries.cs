using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DGMKCollections.Timer;

public class UIRankingEntries : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _position;
    [SerializeField]
    private TextMeshProUGUI _name;
    [SerializeField]
    private TextMeshProUGUI _score;

    public void SetPosition(int position)
    {
        _position.text  = position.ToString();
    }

    public void ChangeInfo(string name, float score)
    {
        _name.text = name;
        if(score == float.MaxValue)
            _score.text = "99:99.999";
        else
            _score.text = Timer.MillisecondsToStringFormatted(score, @"mm\:ss\.fff");
    }
}
