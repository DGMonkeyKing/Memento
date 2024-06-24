using UnityEngine;

namespace EventBus.Events
{
    [CreateAssetMenu(fileName = "Assets/Resources/Game Events/New String GameEvent", menuName = "eGoGamesTest/Game Events/New String GameEvent", order = 0)]
    public class StringGameEvent : GameEvent<string>{}
}