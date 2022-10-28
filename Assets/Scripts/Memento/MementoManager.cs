using System.Collections.Generic;
using UnityEngine;

namespace DGMKCollections.Patterns.Memento
{
    public class MementoManager : MonoBehaviour
    {
        private Stack<GameObject> _mementoPrefabs;
        private Caretaker _caretaker;
        [SerializeField]
        private Originator _originator;

        // Start is called before the first frame update
        void Awake()
        {
            _caretaker = new Caretaker(_originator);
            _mementoPrefabs = new Stack<GameObject>();

            _originator.CreateMemento += OnCreateMemento;
            _originator.ConsumeMemento += OnConsumeMemento;
        }

        public void Reset()
        {
            _caretaker = new Caretaker(_originator);
            
            foreach(GameObject go in _mementoPrefabs)
            {
                Destroy(go);
            }
            _mementoPrefabs = new Stack<GameObject>();
        }

        private void OnCreateMemento(GameObject mementoPrefab)
        {
            _mementoPrefabs.Push(mementoPrefab);
            _caretaker.SaveMemento();
        }

        private void OnConsumeMemento()
        {
            if(_mementoPrefabs.Count > 0) Destroy(_mementoPrefabs.Pop());
            _caretaker.RestoreMemento();
        }
    }
}