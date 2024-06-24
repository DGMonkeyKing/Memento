using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;

namespace EventBus
{
    public class GameEventListener<T> : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The event to subscribe to.")]
        private GameEvent<T> _gameEvent;

        [SerializeField]
        [Tooltip("The event to subscribe to.")]
        private UnityEvent<T> _response;

#region UNITY_METHODS
        private void OnEnable() 
        {
            _gameEvent.SubscribeListener(this);
        }

        private void OnDisable() 
        {
            _gameEvent.UnsubscribeListener(this);
        }
#endregion

#region PUBLIC_API
        public void OnEventRaised(T parameter)
        {
            _response.Invoke(parameter);
        }
#endregion
    }
}