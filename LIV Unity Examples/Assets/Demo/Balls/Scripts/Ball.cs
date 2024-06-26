using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LIV.Examples
{
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        private List<Color> _colors = new List<Color>();

        [SerializeField] private float _lifeTime;
        [SerializeField] private AnimationCurve _birthAnimationCurve;
        [SerializeField] private float _birthAnimationDuration;
        
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Vector2 _scaleRange;

        private bool _changeColorOnTrigger = true;

        private Color _currentColor;

        public Color GetColor()
        {
            return _currentColor;
        }

        public void SetChangeColorOnTrigger(bool b)
        {
            _changeColorOnTrigger = b;
        }
        
        private Color GetRandomColor()
        {
            return _colors[Random.Range(0, _colors.Count)];
        }

        private void Start()
        {
            SetRandomColor();
            transform.localScale = Vector3.one * Random.Range(_scaleRange.x, _scaleRange.y);
            Invoke(nameof(Die), _lifeTime);
        }
        
        private void Die()
        {
            StartCoroutine(AnimateBalloon(transform.localScale, Vector3.zero, () => Destroy(gameObject)));
        }

        void SetRandomColor()
        {
            _currentColor = GetRandomColor();
            _meshRenderer.material.color = _currentColor;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_changeColorOnTrigger)
            {
                SetRandomColor();
            }
                
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
    }
}
