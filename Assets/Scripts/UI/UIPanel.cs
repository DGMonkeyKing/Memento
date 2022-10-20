using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DGMKCollections.Memento.UI
{
    public abstract class UIPanel : MonoBehaviour
    {
        public delegate void PanelFunction();
        public event PanelFunction OnEnterPressed;
        
        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        protected virtual void Update()
        {
            if(Input.GetButtonDown("Enter"))
            {
                OnEnterPressed?.Invoke();
            }
        }
    }
}