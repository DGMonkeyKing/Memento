using System.Collections;
using System.Collections.Generic;
using DGMKCollections.Memento.Components;
using UnityEngine;

namespace DGMKCollections.Memento.Items.Data
{
    [CreateAssetMenu(fileName = "Collectable Item", menuName = "Memento/New Collectable Item", order = 0)]
    public class CollectableItem : ItemData
    {
        public override void MakeAction(Item item, Collector collector)
        {
            item.gameObject.SetActive(false);
        }
    }
}
