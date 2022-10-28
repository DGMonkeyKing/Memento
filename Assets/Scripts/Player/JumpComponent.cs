using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DGMKCollections.Memento.Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class JumpComponent : MonoBehaviour
    {
        [SerializeField]
        private float _force = 2f;

        private Rigidbody2D _rigidbody;

        void Start() 
        {  
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Jump()
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector3.up * _force);
        }
    }
}