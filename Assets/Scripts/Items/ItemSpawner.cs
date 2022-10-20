using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DGMKCollections.Score;
using DGMKCollections.Memento.Items;
using DGMKCollections.Memento.Items.Data;

public class ItemSpawner : MonoBehaviour
{
    private ObjectPool<Item> _itemPool;

    [SerializeField]
    private Item _itemPrefab;

    [SerializeField]
    private Score _score;

    [SerializeField]
    private List<Transform> _spawnPositions;

    private int _itemCount = 0;

    [SerializeField]
    private SO_MementoConfiguration _configuration;

    void Awake()
    {
        _itemPool = new ObjectPool<Item>(_itemPrefab, _score.GetMaxScore, gameObject);
        SpawnNewItem();
    }

    void SpawnNewItem()
    {
        Item item = _itemPool.GetObject();
        item.ItemPicked += ReturnItem;

        item.transform.localPosition = _spawnPositions[_configuration.ItemOrder[_itemCount%_configuration.NumberOfItems]-1].position + (Vector3.up*1.2f);
        _itemCount++;
    }

    void ReturnItem(Item item)
    {
        _itemPool.ReturnObject(item);
        SpawnNewItem();
        item.ItemPicked -= ReturnItem;
    }
}
