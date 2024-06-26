using UnityEngine;

namespace LIV.Examples
{
    [CreateAssetMenu(fileName = "DebugMessage", menuName = "Debug/DebugMessage")]
    public class DebugMessage : ScriptableObject
    {
        public static void Log(string m)
        {
            Debug.Log(m);
        }
        
        public static void Log(float m)
        {
            Debug.Log(m);
        }

        public static void Log(Vector3 m)
        {
            Debug.Log(m);
        }

        public static void Log(Quaternion q)
        {
            Debug.Log(q);
        }
    }
}

