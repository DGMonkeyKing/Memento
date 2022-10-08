using System.Collections;
using System.Collections.Generic;
using DGMKCollections.Memento.Interfaces;
using UnityEngine;

namespace DGMKCollections.Memento.Items.Data
{
    [CreateAssetMenu]
    public abstract class ItemData : ScriptableObject 
    {
        public abstract void MakeAction(ICollector collector);    
    }
}
