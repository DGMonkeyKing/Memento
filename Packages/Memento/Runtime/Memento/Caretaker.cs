using System.Collections.Generic;

namespace DGMKCollections.Patterns.Memento
{
    public class Caretaker
    {
        private Stack<IMemento> _mementos;
        private IOriginator _originator;

        public Caretaker(IOriginator originator)
        {
            _originator = originator;

            _mementos = new Stack<IMemento>();
        }

        public void SaveMemento()
        {
            _mementos.Push(_originator.Save());
        }

        public void RestoreMemento()
        {
            if (_mementos.Count == 0)
            {
                return;
            }

            _originator.Restore(_mementos.Pop());
        }
    }
}