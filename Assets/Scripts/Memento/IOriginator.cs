namespace DGMKCollections.Patterns.Memento
{
    public interface IOriginator
    {
        // Saves the current state inside a memento.
        public IMemento Save();

        // Restores the Originator's state from a memento object.
        public void Restore(IMemento memento);
    }
}