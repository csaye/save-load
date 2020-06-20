using UnityEngine;
using UnityEngine.SceneManagement;

namespace SaveLoadSystem.UI
{
    public class MenuButton : MonoBehaviour
    {
        public void SwitchScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
