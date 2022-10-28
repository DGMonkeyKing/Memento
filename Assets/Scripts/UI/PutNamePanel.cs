using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DGMKCollections.Memento.UI
{
    public class PutNamePanel : UIPanel
    {
        public delegate void NameAction(string _name);
        public event NameAction NameInput;

        [SerializeField]
        private InputName _inputName;

        void OnEnable()
        {
            _inputName.Reset();
        }

        void OnDisable()
        {
            NameInput(_inputName.RetrieveName());
            _inputName.Reset();    
        }
    }
}