using System.Collections;
using UnityEngine;
using TMPro;

namespace LIV.Examples
{
    public class LAnchor : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _anchorIdName;
        [SerializeField] private OVRSpatialAnchor _spatialAnchor;

        private IEnumerator Start()
        {
            while (_spatialAnchor && _spatialAnchor.PendingCreation)
            {
                yield return null;
            }

            if (_spatialAnchor)
            {
                _anchorIdName.text = _spatialAnchor.Created
                    ? _spatialAnchor.Uuid.ToString()
                    : "Anchor creation failed";
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Save()
        {
            if (!_spatialAnchor) return;

            _spatialAnchor.SaveAnchorAsync().ContinueWith((result, anchor) =>
            {
                if (result.Success)
                {
                    anchor.OnSave();
                }
                else
                {
                    Debug.LogError($"Failed to save anchor {anchor._spatialAnchor.Uuid} with error {result.Status}.");
                }
            }, this);
            
            Log("Been saved");
        }
        
        public void Delete()
        {
            Log("Been deleted");
            Destroy(gameObject);
        }
        
        public void Erase()
        {
            if (!_spatialAnchor) return;
            
            Log("Been erased");
            
            _anchorIdName.text = _spatialAnchor.Created
                ? _spatialAnchor.Uuid.ToString()
                : "Anchor creation failed";
            
            EraseAnchor();
        }

        void OnSave()
        {
            AnchorUuidStore.Add(_spatialAnchor.Uuid);
        }

        void EraseAnchor()
        {
            _spatialAnchor.EraseAnchorAsync().ContinueWith((result, anchor) =>
            {
                if (result.Success)
                {
                    anchor.OnErase();
                }
                else
                {
                    Debug.LogError($"Failed to erase anchor {anchor._spatialAnchor.Uuid} with result {result.Status}");
                }
            }, this);
        }

        void OnErase()
        {
            AnchorUuidStore.Remove(_spatialAnchor.Uuid);
        }

        void Log(string message)
        {
            Debug.Log($"<color=#724FFF>{message}</color>");
        }
    }
}
