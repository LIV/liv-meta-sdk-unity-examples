using System.Collections;
using UnityEngine;

namespace LIV.Examples
{
    public class SceneInteractable : MonoBehaviour
    {
        Hashtable _hash = new Hashtable();
        
        [SerializeField] MeshRenderer _meshRenderer;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                if (_hash.ContainsKey(other.GetInstanceID()))
                {
                    return;
                }

                _hash.Add(other.GetInstanceID(), other);
                _meshRenderer.enabled = true;
                _meshRenderer.material.color = other.GetComponent<Ball>().GetColor();
            }
        }
    }
}
