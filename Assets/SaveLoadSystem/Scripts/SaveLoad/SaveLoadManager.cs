using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SaveLoadSystem.SaveLoad
{
    public class SaveLoadManager : MonoBehaviour
    {
        [Header("Attributes")]
        public bool loadOnStart;

        private void Start()
        {
            if (loadOnStart)
            {
                Load();
            }
        }

        // Collect save data and send to serialization manager
        public void Save()
        {
            GameEvents.current.DispatchOnSaveEvent();

            if (loadOnStart)
            {
                SaveData.current.saveScene = SceneManager.GetActiveScene().name;
            }

            SerializationManager.Save(SaveData.current.saveName, SaveData.current);
        }

        // Load data from file and distribute
        public void Load()
        {
            if (SaveData.current.saveName != null && File.Exists(Application.persistentDataPath + "/saves/" + SaveData.current.saveName + ".save"))
            {
                SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/" + SaveData.current.saveName + ".save");
                GameEvents.current.DispatchOnLoadEvent();
            }
        }

        public void CreateNewSave()
        {
            try
            {
                TMP_InputField saveNameField = (TMP_InputField)FindObjectOfType(typeof(TMP_InputField));
                
                // Initialize new save
                SaveData.current.saveName = getSaveName(saveNameField.text);
                SaveData.current.playerData = new PlayerData(saveNameField.text, 0, Vector2.zero);
                SaveData.current.dotData = new DotData(Vector2.zero);

                Save();
            }
            catch
            {
                Debug.LogError("Could not create new save.");
            }
        }

        // Returns a unique save name
        private string getSaveName(string saveNameInput)
        {
            string dataPath = Application.persistentDataPath;

            // If saves folder does not exist, create one
            if (!Directory.Exists(dataPath + "/saves"))
            {
                Directory.CreateDirectory(dataPath + "/saves");
            }

            string path = dataPath + "/saves";

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] savesInfo = directoryInfo.GetFiles().ToArray();

            List<string> saveFiles = new List<string>();

            // Get list of save file names
            foreach (FileInfo save in savesInfo)
            {
                string saveName = save.Name;

                // Only add file if it is a .save file
                if (saveName.EndsWith(".save"))
                {
                    saveFiles.Add(saveName);
                }
            }

            // If new name not contained in saves folder
            if (!saveFiles.Contains(saveNameInput + ".save"))
            {
                return saveNameInput;
            }
            else
            {
                int copyNumber = 2;
                string saveNameCopy = saveNameInput + "#" + copyNumber;

                // Increment copy number while saves contains new name
                while (saveFiles.Contains(saveNameCopy + ".save"))
                {
                    copyNumber++;
                    saveNameCopy = saveNameInput + "#" + copyNumber;
                }

                return saveNameCopy;
            }
        }
    }
}
