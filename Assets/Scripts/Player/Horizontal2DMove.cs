using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DGMKCollections.Memento.Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Horizontal2DMove : MonoBehaviour
    {
        [SerializeField]
        private float _velocity = 2f;
        [SerializeField]
        private float _acceleration = 1f;
        [SerializeField]
        private float _decceleration = 1f;

        private Rigidbody2D _rigidBody;

        void Start() 
        {
            _rigidBody = GetComponent<Rigidbody2D>();    
        }

        public void Move(float horizontalInput)
        {
            _rigidBody.velocity = new Vector2(horizontalInput * _velocity, _rigidBody.velocity.y);
        }
    }
}