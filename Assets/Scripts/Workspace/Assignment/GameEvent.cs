using UnityEngine;

namespace Assignment
{
    public class GameEvent
    {
        public string EventType { get; set; }
        public string Name { get; set; }

        public GameEvent(string eventType, string description, int priority = 1)
        {
            EventType = eventType;
            Name = description;
        }
    }
}