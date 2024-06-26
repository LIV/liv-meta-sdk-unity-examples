using UnityEngine;
using UnityEngine.Events;

namespace LIV.Examples
{
    public class ScriptableVoidEventListener : MonoBehaviour
    {
        [SerializeField] ScriptableVoidEvent _event;

        public UnityEvent onEvent;
        
        void OnEnable()
        {
            _event.Subscribe(onEvent.Invoke);
        }
        
        void OnDisable()
        {
            _event.Unsubscribe(onEvent.Invoke);
        }
    }
}
