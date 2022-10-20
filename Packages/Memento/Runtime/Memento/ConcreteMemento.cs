using System;

namespace DGMKCollections.Patterns.Memento
{
    public abstract class ConcreteMemento : IMemento
    {
        private string _name = "default";
        private DateTime _date;

        public ConcreteMemento(string name)
        {
            _name = name;
            _date = DateTime.Now;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public string GetName()
        {
            return $"{_date}/{_name}";
        }
    }
}