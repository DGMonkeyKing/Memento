using System;
using UnityEngine;
    
namespace DGMKCollections.Memento.Components
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class GroundChecker2D : MonoBehaviour 
    {
        private bool _isGrounded = false;
        public bool IsGrounded => _isGrounded;

        void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.tag == "Ground"){
                _isGrounded = true;
            }
        }
        
        void OnCollisionExit2D(Collision2D col)
        {
            if(col.gameObject.tag == "Ground"){
                _isGrounded = false;
            }
        }
    }
}