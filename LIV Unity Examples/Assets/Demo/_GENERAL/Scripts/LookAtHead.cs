using UnityEngine;

namespace LIV.Examples
{
    public class LookAtHead : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private float _rotationSpeed = 1.0f;
        [SerializeField] private bool _flipY = false;
        
        private Transform _headTransform;

        private void Awake()
        {
            _headTransform = Camera.main.transform;
        }

        private void Update()
        {
            Vector3 lookDirection = _headTransform.forward;
            lookDirection.y = 0;
            lookDirection.Normalize();
            Quaternion rotation = _flipY ?
                    Quaternion.LookRotation(lookDirection) :
                    Quaternion.LookRotation(lookDirection) * Quaternion.Euler(0, 180f, 0);
            
            _targetTransform.rotation = Quaternion.Slerp(_targetTransform.rotation, rotation, Time.deltaTime * _rotationSpeed);
        }
    }
}
