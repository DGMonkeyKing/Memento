using System;
using UnityEngine;

namespace DGMKCollections.Patterns.Memento
{
    public class Originator : MonoBehaviour, IOriginator
    {
        [SerializeField]
        private GameObject _mementoPrefab;

        public delegate void MementoAction();
        public delegate void MementoActionPrefab(GameObject mementoPrefab);
        public event MementoActionPrefab CreateMemento;
        public event MementoAction ConsumeMemento;

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                ConsumeMemento?.Invoke();
            }

            if(Input.GetKeyDown(KeyCode.O))
            {
                GameObject go = Instantiate(_mementoPrefab, transform.position, transform.rotation);
                CreateMemento?.Invoke(go);
            }
        }

        public void Restore(IMemento memento)
        {
            if (!(memento is MementerMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }

            transform.position = ((MementerMemento) memento).Position;
        }

        public IMemento Save()
        {
            return new MementerMemento(transform.position);
        }
    }
}