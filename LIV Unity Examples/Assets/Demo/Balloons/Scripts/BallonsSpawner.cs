using System.Collections;
using UnityEngine;

namespace LIV.Examples
{
    public class BallonsSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _balloonPrefab;
        [SerializeField] private float _spawnInterval = 1f;
        
        private void Start()
        {
            StartCoroutine(StartSpawning());
        }
        
        private IEnumerator StartSpawning()
        {
            while (true)
            {
                Instantiate(_balloonPrefab, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(_spawnInterval);
            }
        }
    }
}
