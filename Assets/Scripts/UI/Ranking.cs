using System;
using System.Collections.Generic;

public class Ranking
{
    List<Entry> _entries;

    public Ranking(int _numberOfEntries)
    {
        _entries = new List<Entry>();

        for(int i = 0; i < _numberOfEntries; i++)
        {
            _entries.Add(new Entry());
        }
    }

    public int CheckPosition(float milliseconds)
    {
        int position = -1;

        for(int i = _entries.Count-1; i >= 0; i--)
        {
            Entry e = _entries[i];

            if(e.CompareToScore(milliseconds) <= 0)
            {
                // Hemos encontrado posición
                position = i+1;
            }
        }

        return position;
    }

    public Entry GetEntry(int position)
    {
        return _entries[position];
    }
}

public class Entry
{
    public string EntryName;
    public float EntryScore;

    public Entry()
    {
        EntryName = "---";
        EntryScore = 999999f;
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