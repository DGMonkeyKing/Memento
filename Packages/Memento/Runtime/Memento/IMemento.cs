using System;

namespace DGMKCollections.Patterns.Memento
{
    public interface IMemento
    {
        string GetName();
        DateTime GetDate(); 
    }
}