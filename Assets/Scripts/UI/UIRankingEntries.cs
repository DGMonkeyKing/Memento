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

    public void ChangeInfo(Entry _entry)
    {
        _name.text = _entry.EntryName;
        if(_entry.EntryScore == float.MaxValue)
            _score.text = "99:99.999";
        else
            _score.text = Timer.MillisecondsToStringFormatted(_entry.EntryScore, @"mm\:ss\.fff");
    }
}
