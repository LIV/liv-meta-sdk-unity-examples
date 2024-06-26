using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LIV.Examples
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleController : MonoBehaviour
    {
        [Header("Events")] 
        [SerializeField] private UnityEvent toggleOn;
        [SerializeField] private UnityEvent toggleOff;
        [SerializeField] private ToggleValueUpdated toggleValueChanged;
        
        private Toggle _toggle;

        private void Start()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(ProcessToggle);
        }

        private void OnEnable()
        {
            if (_toggle)
            {
                _toggle.onValueChanged.AddListener(ProcessToggle);
            }
            
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(ProcessToggle);
        }

        private void ProcessToggle(bool b)
        {
            if (b)
            {
                toggleOn.Invoke();
            }
            else
            {
                toggleOff.Invoke();
            }
            
            toggleValueChanged.Invoke(b);
        }
    }
    
    [Serializable] public class ToggleValueUpdated : UnityEvent<bool> {}
}
