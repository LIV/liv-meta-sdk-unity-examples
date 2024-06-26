using UnityEngine;
using Random = UnityEngine.Random;

namespace LIV.Examples
{
    public class AudioTrigger : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip[] _audioClips;
        [SerializeField] private float _volume = 0.7f;
        [SerializeField] private float _pitch = 1f;

        protected virtual void Start()
        {
            if (_audioSource == null)
            {
                _audioSource = gameObject.GetComponent<AudioSource>();
            }
        }

        public void PlayAudio()
        {
            int randomClipIndex = Random.Range(0, _audioClips.Length);
            _audioSource.pitch = _pitch;
            _audioSource.PlayOneShot(_audioClips[randomClipIndex], _volume);
        }
    }
}
