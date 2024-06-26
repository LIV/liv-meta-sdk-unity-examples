using UnityEngine;

namespace LIV.Examples
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] GameObject _ballPrefab;
        [SerializeField] float _spawnInterval = 1f;
        [SerializeField] float _ballSpeed = 2f;
        [SerializeField] bool _changeColorOnTrigger = true;
        
        bool _canSpawn = true;

        private Vector3 _headDirection;
        private Vector3 _headPosition;
        private Quaternion _headRotation;

        public void Spawn()
        {
            _canSpawn = false;
            GameObject go = Instantiate(_ballPrefab, _headPosition + _headDirection * 0.5f, Quaternion.identity);

            go.GetComponent<Ball>().SetChangeColorOnTrigger(_changeColorOnTrigger);
            Ray ray = new Ray(_headPosition, _headDirection);
            go.GetComponent<Rigidbody>().AddForce(ray.direction * _ballSpeed, ForceMode.Impulse);
            Invoke("AllowSpawn", _spawnInterval);
        }
        
        void AllowSpawn()
        {
            _canSpawn = true;
        }
        
        void Update()
        {
            _headDirection = Camera.main.transform.forward;
            _headPosition = Camera.main.transform.position;
            _headRotation = Camera.main.transform.rotation;
        }
    }
}
