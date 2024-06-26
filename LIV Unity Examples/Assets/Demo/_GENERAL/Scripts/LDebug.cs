using Unity.VisualScripting;
using UnityEngine;

namespace LIV.Examples
{
    public class LDebug : MonoBehaviour
    {
        public static void Log(string message, Color color)
        {
            Debug.Log($"<color=#{color.ToHexString()}>{message}</color>");
        }
    }
}

