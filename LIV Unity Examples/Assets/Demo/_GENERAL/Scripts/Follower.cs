using UnityEngine;

namespace LIV.Examples
{
    public class Follower : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
    
        [SerializeField] private bool _followPosition = true;
        [SerializeField] private bool _followRotation = true;
    
        [Space(10)] [Header("Offset")]
    
        [SerializeField] private Vector3 _positionOffset;

        [Space(10)] [Header("Animation")] 
    
        [SerializeField] private float _positionSmoothness = 0.5f;
        [SerializeField] private float _rotationSmoothness = 0.5f;
    
        Vector3 _positionVelocity;
        Vector3 _rotationVelocity;
    
        private void Update()
        {
            if (_followPosition)
            {
                Vector3 targetPosition = _targetTransform.position + 
                                         _targetTransform.right * _positionOffset.x + 
                                         _targetTransform.up * _positionOffset.y + 
                                         _targetTransform.forward * _positionOffset.z;
            
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _positionVelocity, _positionSmoothness);
            }

            if (_followRotation)
            {
                transform.forward = Vector3.SmoothDamp(transform.forward, _targetTransform.forward, ref _rotationVelocity, _rotationSmoothness);
            }
        }
    }
}

