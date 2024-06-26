using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LIV.Examples
{
    public class SpatialAnchorLoader : MonoBehaviour
    {
        [SerializeField] OVRSpatialAnchor _anchorPrefab;
        
        Action<bool, OVRSpatialAnchor.UnboundAnchor> _onAnchorLocalized;
        readonly List<OVRSpatialAnchor.UnboundAnchor> _unboundAnchors = new();

        public void LoadAnchorsByUuid()
        {
            var uuids = AnchorUuidStore.Uuids.ToArray();
            
            if (uuids.Length == 0)
            {
                LogWarning($"There are no anchors to load.");
                return;
            }

            Log($"Attempting to load {uuids.Length} anchors by UUID: " +
                $"{string.Join($", ", uuids.Select(uuid => uuid.ToString()))}");

            OVRSpatialAnchor.LoadUnboundAnchorsAsync(uuids, _unboundAnchors)
                .ContinueWith(result =>
                {
                    if (result.Success)
                    {
                        ProcessUnboundAnchors(result.Value);
                    }
                    else
                    {
                        LogError($"{nameof(OVRSpatialAnchor.LoadUnboundAnchorsAsync)} failed with error {result.Status}.");
                    }
                });
        }

        private void Awake()
        {
            _onAnchorLocalized = OnLocalized;
        }

        private void ProcessUnboundAnchors(IReadOnlyList<OVRSpatialAnchor.UnboundAnchor> unboundAnchors)
        {
            Log($"{nameof(OVRSpatialAnchor.LoadUnboundAnchorsAsync)} found {unboundAnchors.Count} unbound anchors: " +
                $"[{string.Join(", ", unboundAnchors.Select(a => a.Uuid.ToString()))}]");

            foreach (var anchor in unboundAnchors)
            {
                if (anchor.Localized)
                {
                    _onAnchorLocalized(true, anchor);
                }
                else if (!anchor.Localizing)
                {
                    anchor.LocalizeAsync().ContinueWith(_onAnchorLocalized, anchor);
                }
            }
        }

        private void OnLocalized(bool success, OVRSpatialAnchor.UnboundAnchor unboundAnchor)
        {
            if (!success)
            {
                LogError($"{unboundAnchor} Localization failed!");
                return;
            }

            var pose = unboundAnchor.Pose;
            var spatialAnchor = Instantiate(_anchorPrefab, pose.position, pose.rotation);
            unboundAnchor.BindTo(spatialAnchor);

            // if (spatialAnchor.TryGetComponent<LAnchor>(out var anchor))
            // {
            //
            // }
        }

        private static void Log(LogType logType, object message)
            => Debug.unityLogger.Log(logType, "[SpatialAnchorSample]", message);

        private static void Log(object message) => Log(LogType.Log, message);

        private static void LogWarning(object message) => Log(LogType.Warning, message);

        private static void LogError(object message) => Log(LogType.Error, message);
    }
    
}
