using UnityEngine;
using UnityEngine.Events;

namespace LIV.Examples
{
    [CreateAssetMenu(fileName = "Scriptable Quaternion Event", menuName = "Scriptable Events/Create Scriptable Quaternion Event")]
    public class ScriptableQuaternionEvent : ScriptableObject
    {
        [SerializeField] Vector3 _defaultValueToInvoke;

        UnityEvent<Quaternion> _onEvent = new UnityEvent<Quaternion>();
        
        public void Invoke(Quaternion value)
        {
            _onEvent.Invoke(value);
        }
        
        public void Subscribe(UnityAction<Quaternion> action)
        {
            _onEvent.AddListener(action);
        }

        public void Unsubscribe(UnityAction<Quaternion> action)
        {
            _onEvent.RemoveListener(action);
        }

        [ContextMenu("Invoke Event")]
        void Invoke()
        {
            _onEvent.Invoke(Quaternion.Euler(_defaultValueToInvoke));
        }
    }
}

