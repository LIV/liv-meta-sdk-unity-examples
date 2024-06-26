using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LIV.Examples
{
    public class Balloon : MonoBehaviour
    {
        [Header("Colors")]
        
        [SerializeField] private List<Color> _colors = new List<Color>();
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private MeshRenderer _balBody;
        [SerializeField] private MeshRenderer _balString;

        [Space(10)]
        [Header("Elements")]
        
        [SerializeField] private MeshRenderer _balloonMeshRenderer;

        [Space(10)] 
        [Header("Settings")]

        [SerializeField] private float _scaleDeviation;

        [Tooltip("The height at which the balloon will be destroyed.")]
        [SerializeField] private float _deathDistance;

        [Tooltip("The time after which the balloon will be destroyed.")]
        [SerializeField] private float _deathTime;

        [SerializeField] private float _speedSoaring;
        [SerializeField] private float _speedSpinning;
        [SerializeField] private float _birthAnimationDuration;
        [SerializeField] private AnimationCurve _birthAnimationCurve;
        [SerializeField] private float _directionDeviation;

        private Vector3 _initialScale;
        private bool _hasStartedDying;
        private bool _blockMovement;
        private bool _dyingStarted;
        private float _deathTimer;
        private Vector3 _direction;
        private bool _dirBeenChanged = false;
        private Rigidbody _rb;

        #region MONOBEHAVIOUR_METHODS
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _balloonMeshRenderer.material.color = GetRandomColor();
            _initialScale = transform.localScale;
            _initialScale *= Random.Range(1 - _scaleDeviation, 1 + _scaleDeviation);
            transform.localScale = Vector3.zero;

            StartCoroutine(AnimateBalloon(transform.localScale, _initialScale, null));
            
            _direction = Vector3.up + GetRandomUpDirection();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            // if (_dirBeenChanged) return;
            // _dirBeenChanged = true;
            // _direction = Vector3.Reflect(_direction, other.transform.forward);
            // Invoke(nameof(ResetDir), 1f);
            
            if (other.CompareTag("Wall"))
            {
                _blockMovement = true; 
                _rb.useGravity = true;
                _rb.isKinematic = false;
            }
        }
        
        private void Update()
        {
            _deathTimer += Time.deltaTime;
            
            if (_deathTimer >= _deathTime && !_dyingStarted)
            {
                Die();
                // _particleSystem.
                // _particleSystem.Play();
                _dyingStarted = true;
            }
            
            if (_blockMovement) return;
            transform.Translate(_direction * (Time.deltaTime * _speedSoaring));
            transform.Rotate(_direction * (Time.deltaTime * _speedSpinning));
        }
        
        #endregion

        #region PUBLIC_METHODS

        public void SetBlockMovement(bool b)
        {
            _balloonMeshRenderer.material.color = GetRandomColor();
            _blockMovement = b;
        }

        #endregion

        #region PRIVATE_METHODS

        private void ResetDir()
        {
            _dirBeenChanged = false;
        }
        
        private Vector3 GetRandomUpDirection()
        {
            return new Vector3(Random.Range(-_directionDeviation, _directionDeviation), 1, Random.Range(-_directionDeviation, _directionDeviation));
        }
        
        private Color GetRandomColor()
        {
            return _colors[Random.Range(0, _colors.Count)];
        }
        
        private void Die()
        {
            StartCoroutine(AnimateBalloon(transform.localScale, Vector3.zero, () => Destroy(gameObject)));
        }
        
        private IEnumerator AnimateBalloon(Vector3 initScale, Vector3 targetScale, Action action)
        {
            float time = 0f;
            while (time <= _birthAnimationDuration)
            {
                float t = _birthAnimationCurve.Evaluate(time / _birthAnimationDuration);
                transform.localScale = Vector3.Lerp(initScale, targetScale, t);
                time += Time.deltaTime;
                yield return null;
            }
            action?.Invoke();
        }

        #endregion
    }
}
