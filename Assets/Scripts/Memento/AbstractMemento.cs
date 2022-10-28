using System;

namespace DGMKCollections.Patterns.Memento
{
    public abstract class AbstractMemento : IMemento
    {
        private DateTime _date;

        public AbstractMemento()
        {
            _date = DateTime.Now;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public virtual string GetName()
        {
            return $"{_date}";
        }
    }
}