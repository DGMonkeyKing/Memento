using System.Collections;
using System.Collections.Generic;
using DGMKCollections.Memento.Components;
using DGMKCollections.Memento.Items.Data;
using UnityEngine;

namespace DGMKCollections.Memento.Items
{
    [RequireComponent(typeof(Collider2D))]
    public class Item : MonoBehaviour
    {
        public delegate void ItemActions(Item item);
        public event ItemActions ItemPicked;

        [SerializeField]
        private ItemData[] _itemData;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            Collector collector = other.gameObject.GetComponent<Collector>();
            foreach(ItemData i in _itemData)
            {
                i.MakeAction(this, collector);
                ItemPicked?.Invoke(this);
            }
        }
    }
}
