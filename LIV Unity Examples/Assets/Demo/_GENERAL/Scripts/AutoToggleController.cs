using UnityEngine;
using UnityEngine.Events;

namespace LIV.Examples  
{
    public class AutoToggleController : MonoBehaviour
    {
        [SerializeField] UnityEvent _onToggleOn;
        [SerializeField] UnityEvent _onToggleOff;
        [SerializeField] private OVRSpatialAnchor _spatialAnchor;
        
        [SerializeField] private bool _isToggledOn = false;
        [SerializeField] private bool _invokeOnAwake = false;

        private void Awake()
        {
            if (_invokeOnAwake)
            {
                Invoke();
            }
        }

        private void Start()
        {
            if (AnchorUuidStore.Uuids.Contains(_spatialAnchor.Uuid))
            {
                SetToggleState(true);
                Invoke();
            };
        }

        public void SetToggleState(bool b) => _isToggledOn = b;

        public void Toggle()
        {
            _isToggledOn = !_isToggledOn;
            
            if (_isToggledOn)
            {
                _onToggleOn.Invoke();
            }
            else
            {
                _onToggleOff.Invoke();
            }
        }

        public void Invoke()
        {
            if (_isToggledOn)
            {
                _onToggleOn.Invoke();
            }
            else
            {
                _onToggleOff.Invoke();
            }
        }
}
}
