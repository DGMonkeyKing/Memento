using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_MementoConfiguration", menuName = "Memento/New Memento Configuration", order = 0)]
public class SO_MementoConfiguration : ScriptableObject
{
    [SerializeField]
    private List<int> _itemOrder;
    public List<int> ItemOrder => _itemOrder;

    public int NumberOfItems => _itemOrder.Count;
}
