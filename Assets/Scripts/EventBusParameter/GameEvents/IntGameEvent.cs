using UnityEngine;

namespace EventBus.Events
{
    [CreateAssetMenu(fileName = "Assets/Resources/Game Events/New Int GameEvent", menuName = "eGoGamesTest/Game Events/New Int GameEvent", order = 0)]
    public class IntGameEvent : GameEvent<int>{}
}