using UnityEngine;

namespace LIV.Examples
{
    public class DebugTransform : MonoBehaviour
    {
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward);
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.up);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, transform.right);
        }
    }
}
