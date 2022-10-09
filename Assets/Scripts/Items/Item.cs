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
        [SerializeField]
        private ItemData _itemData;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            Collector collector = other.gameObject.GetComponent<Collector>();
            _itemData.MakeAction(this, collector);
        }
    }
}
