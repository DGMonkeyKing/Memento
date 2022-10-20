using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    // Pools for objects
    private Queue<T> pool = new Queue<T>();
    private GameObject _parent;


    public ObjectPool(T prefab, int instances, GameObject parent)
    {
        _parent = parent;

        // Put information about our pools to Dictionary
        for(int i = 0; i < instances; i++)
        {
            T go = UnityEngine.Object.Instantiate<T>(prefab);
            go.transform.parent = parent.transform;
            go.gameObject.SetActive(false);
            pool.Enqueue(go);
        }
    }

    public int PoolSize()
    {
        return pool.Count;
    }

    public T GetObject()
    {
        if(pool.Count > 0)
        {
            T _e = pool.Dequeue();
            _e.gameObject.SetActive(true);
            return _e;
        }

        return null;
    }

    public void ReturnObject(T poolObject)
    {
        // Return object to pool
        poolObject.transform.parent = _parent.transform;
        poolObject.gameObject.SetActive(false);
        pool.Enqueue(poolObject);
    }
}