using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Events
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent SourceEvent;

        [SerializeField] private UnityEvent Callback;

        private void OnEnable()
        {
            SourceEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            SourceEvent.UnregisterListener(this);
        }

        public void Listen()
        {
            Callback.Invoke();
        }
    }
}