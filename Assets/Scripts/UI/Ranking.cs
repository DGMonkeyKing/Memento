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

            if(e.EntryScore < milliseconds)
            {
                // Hemos encontrado posición
                return position;
            }

            position = i;
        }

        return position;
    }

    public Entry GetEntry(int position)
    {
        return _entries[position];
    }

    public void SetEntry(string name, float milliseconds)
    {
        Entry e = new Entry();
        e.EntryName = name;
        e.EntryScore = milliseconds;

        _entries[CheckPosition(milliseconds)].EntryName = name;
        _entries[CheckPosition(milliseconds)].EntryScore = milliseconds;
    }
}

public class Entry
{
    public string EntryName;
    public float EntryScore;

    public Entry()
    {
        EntryName = "---";
        EntryScore = float.MaxValue;
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