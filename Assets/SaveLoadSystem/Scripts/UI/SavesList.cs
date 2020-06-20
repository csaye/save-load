using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

namespace SaveLoadSystem.UI
{
    public class SavesList : MonoBehaviour
    {
        [Header("References")]
        public GameObject savesListButtonPrefab;
        public Transform content;

        private List<string> saveFiles = new List<string>();

        private void Start()
        {
            UpdateSavesList();
        }

        private void UpdateSavesList()
        {
            GetSaveFiles();

            // Create button for each save file
            for (int i = 0; i < saveFiles.Count; i++)
            {
                GameObject savesListButton = Instantiate(savesListButtonPrefab, content);
                string saveName = saveFiles[i].Substring(0, saveFiles[i].Length - 5);
                savesListButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = saveName;
            }
        }

        // Gets name of all save files in saves folder
        private void GetSaveFiles()
        {
            saveFiles.Clear();

            string dataPath = Application.persistentDataPath;

            // If saves folder does not exist, create one
            if (!Directory.Exists(dataPath + "/saves"))
            {
                Directory.CreateDirectory(dataPath + "/saves");
            }

            string path = dataPath + "/saves";

            // Get save files ordered by last modified
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] savesInfo = directoryInfo.GetFiles().OrderBy(file => file.LastWriteTime).ToArray();

            foreach (FileInfo saveInfo in savesInfo)
            {
                string saveName = saveInfo.Name;

                // Add file if it is a .save file
                if (saveName.EndsWith(".save"))
                {
                    saveFiles.Add(saveName);
                }
            }

            saveFiles.Reverse();
        }
    }
}
