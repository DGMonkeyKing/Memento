using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DGMKCollections.Patterns.Memento;

public class MementerMemento : AbstractMemento
{
    private Vector3 _position;
    public Vector3 Position => _position;

    public MementerMemento(Vector3 position) : base()
    {
        _position = position;
    }

    public override string GetName()
    {
        return base.GetName() + "/" + _position;
    }
}
