using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        _score.text = _entry.EntryScore.ToString();
    }
}
