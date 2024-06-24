using System.Collections.Generic;
using UnityEngine;

namespace EventBus
{
    public class GameEvent<T> : ScriptableObject 
    {
        private readonly List<GameEventListener<T>> _eventListener = new List<GameEventListener<T>>();

        public void Raise(T parameter)
        {
            foreach(GameEventListener<T> gameEvent in _eventListener)
            {
                gameEvent.OnEventRaised(parameter);
            }
        }

        public void SubscribeListener(GameEventListener<T> listener)
        {
            if(!_eventListener.Contains(listener))
                _eventListener.Add(listener);
        }
        
        public void UnsubscribeListener(GameEventListener<T> listener)
        {
            if(_eventListener.Contains(listener))
                _eventListener.Remove(listener);
        }
    }
}
