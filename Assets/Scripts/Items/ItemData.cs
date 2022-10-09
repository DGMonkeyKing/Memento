using System.Collections;
using System.Collections.Generic;
using DGMKCollections.Memento.Components;
using UnityEngine;

namespace DGMKCollections.Memento.Items.Data
{
    public abstract class ItemData : ScriptableObject 
    {
        public abstract void MakeAction(Item item, Collector collector);    
    }
}
