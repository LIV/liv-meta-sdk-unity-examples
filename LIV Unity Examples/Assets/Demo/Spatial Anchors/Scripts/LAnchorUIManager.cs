using UnityEngine;

namespace LIV.Examples
{
    [RequireComponent(typeof(SpatialAnchorLoader))]
    public class LAnchorUIManager : MonoBehaviour
    {
        [SerializeField]
        private LAnchor _anchorPrefab;

        [SerializeField]
        private Transform _anchorPlacementTransform;

        private bool _isFocused = true;
        
        public void LoadAnchors()
        {
            GetComponent<SpatialAnchorLoader>().LoadAnchorsByUuid();
        }
        
        public void ClearAnchors()
        {
            foreach (LAnchor lAnchor in FindObjectsOfType<LAnchor>())
            {
                lAnchor.Erase();
                lAnchor.Delete();
            }
        }

        public void ClearScene()
        {
            foreach (LAnchor lAnchor in FindObjectsOfType<LAnchor>())
            {
                lAnchor.Delete();
            }
        }

        public void PlaceAnchor()
        {
            Instantiate(_anchorPrefab, _anchorPlacementTransform.position, _anchorPlacementTransform.rotation);
        }
    }
}

