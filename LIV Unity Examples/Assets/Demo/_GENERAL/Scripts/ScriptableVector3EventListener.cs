using UnityEngine;
using UnityEngine.Events;

namespace LIV.Examples
{
    public class ScriptableVector3EventListener : MonoBehaviour
    {
        [SerializeField] ScriptableVector3Event _event;

        public UnityEvent<Vector3> onEvent;
        
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
