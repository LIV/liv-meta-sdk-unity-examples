using UnityEngine;
using UnityEngine.Events;

namespace LIV.Examples
{
    public class PinchDetector : MonoBehaviour
    {
        [Header("Pinches")]
        
        [SerializeField] private UnityEvent _onLeftIndexPinchPressed;
        [SerializeField] private UnityEvent _onRightIndexPinchPressed;
        [SerializeField] private UnityEvent _onLeftIndexPinchReleased;
        [SerializeField] private UnityEvent _onRightIndexPinchReleased;
        
        [Space(10)]
        [Header("Transforms")]
        
        [SerializeField] private UnityEvent<Vector3> _onLeftHandPositionChanged;
        [SerializeField] private UnityEvent<Vector3> _onRightHandPositionChanged;
        
        [SerializeField] private UnityEvent<Quaternion> _onLeftHandRotationChanged;
        [SerializeField] private UnityEvent<Quaternion> _onRightHandRotationChanged;

        [SerializeField] private OVRHand _leftHand;
        [SerializeField] private OVRHand _rightHand;
        
        private bool _isLeftIndexPinching;
        private bool _isRightIndexPinching;

        void Update()
        {
            if (_leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
            {
                if (!_isLeftIndexPinching)
                {
                    _onLeftIndexPinchPressed.Invoke();
                    _isLeftIndexPinching = true;
                }
            }
            else
            {
                if (_isLeftIndexPinching)
                {
                    _onLeftIndexPinchReleased.Invoke();
                    _isLeftIndexPinching = false;
                }
                
            }
            
            if (_rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
            {
                if (!_isRightIndexPinching)
                {
                    _onRightIndexPinchPressed.Invoke();
                    _isRightIndexPinching = true;
                }
                
            }
            else
            {
                if (_isRightIndexPinching)
                {
                    _onRightIndexPinchReleased.Invoke();
                    _isRightIndexPinching = false;
                }
            }
            
            _onLeftHandPositionChanged.Invoke(_leftHand.transform.position);
            _onRightHandPositionChanged.Invoke(_rightHand.transform.position);
            _onLeftHandRotationChanged.Invoke(_leftHand.transform.rotation);
            _onRightHandRotationChanged.Invoke(_rightHand.transform.rotation);
        }
    }
}
