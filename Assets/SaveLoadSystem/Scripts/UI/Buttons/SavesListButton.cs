using SaveLoadSystem.SaveLoad;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SaveLoadSystem.UI
{
    public class SavesListButton : MonoBehaviour
    {
        public void LoadSave()
        {
            SaveData.current.saveName = transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

            // Load save from save name
            SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/" + SaveData.current.saveName + ".save");
            SceneManager.LoadScene(SaveData.current.saveScene);
        }
    }
}