using UnityEngine;

namespace LIV.Examples
{
    public class LoadScene : MonoBehaviour
    {
        [SerializeField] private string _sceneName;
        
        public void Load()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName);
        }
    }
}
