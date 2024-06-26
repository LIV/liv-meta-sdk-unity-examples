using UnityEngine;
using UnityEngine.Events;

namespace LIV.Examples
{
    [CreateAssetMenu(fileName = "Scriptable Void Event", menuName = "Create Scriptable Void Event")]
    public class ScriptableVoidEvent : ScriptableObject
    {
        UnityEvent _onEvent = new UnityEvent();
        
        public void Subscribe(UnityAction action)
        {
            _onEvent.AddListener(action);
        }
        
        public void Unsubscribe(UnityAction action)
        {
            _onEvent.RemoveListener(action);
        }
        
        [ContextMenu("Invoke")]
        public void Invoke()
        {
            _onEvent.Invoke();
        }
    }
}
