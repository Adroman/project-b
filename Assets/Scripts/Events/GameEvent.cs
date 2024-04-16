using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Custom/Game event", order = 0)]
    public class GameEvent : ScriptableObject
    {
        private readonly List<GameEventListener> m_Listeners = new();

        public void RegisterListener(GameEventListener listener)
        {
            m_Listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            m_Listeners.Remove(listener);
        }

        [PublicAPI]
        public void RaiseEvent()
        {
            for (int i = m_Listeners.Count - 1; i >= 0; i--)
            {
                m_Listeners[i].Listen();
            }
        }
    }
}