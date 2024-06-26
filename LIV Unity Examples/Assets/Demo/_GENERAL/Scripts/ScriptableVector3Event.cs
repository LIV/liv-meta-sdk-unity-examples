using UnityEngine;
using UnityEngine.Events;

namespace LIV.Examples
{
    [CreateAssetMenu(fileName = "Scriptable Vector3 Event", menuName = "Create Scriptable Vector3 Event")]
    public class ScriptableVector3Event : ScriptableObject
    {
        [SerializeField] Vector3 _defaultValueToInvoke;
        
        UnityEvent<Vector3> _onEvent = new UnityEvent<Vector3>();

        public void Invoke(Vector3 value)
        {
            _onEvent.Invoke(value);
        }
        
        public void Subscribe(UnityAction<Vector3> action)
        {
            _onEvent.AddListener(action);
        }
        
        public void Unsubscribe(UnityAction<Vector3> action)
        {
            _onEvent.RemoveListener(action);
        }
        
        [ContextMenu("Invoke with default value")]
        void Invoke()
        {
            _onEvent.Invoke(_defaultValueToInvoke);
        }
    }
}
