using UnityEngine;

namespace EventBus.Events
{
    [CreateAssetMenu(fileName = "Assets/Resources/Game Events/New BooleanGameEvent", menuName = "eGoGamesTest/Game Events/New BooleanGameEvent", order = 0)]
    public class BooleanGameEvent : GameEvent<bool>{}
}