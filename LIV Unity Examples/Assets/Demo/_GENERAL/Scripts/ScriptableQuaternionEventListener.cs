using UnityEngine;
using UnityEngine.Events;

namespace LIV.Examples
{
    public class ScriptableQuaternionEventListener : MonoBehaviour
    {
        [SerializeField] ScriptableQuaternionEvent _event;

        public UnityEvent<Quaternion> onEvent;
        
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
