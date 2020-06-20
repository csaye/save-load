using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem.SaveLoad
{
    public class SaveLoadManager : MonoBehaviour
    {
        public void Save()
        {
            SerializationManager.Save(SaveData.current.saveName, SaveData.current);
        }

        public void Load()
        {
            SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/" + SaveData.current.saveName + ".save");
        }
    }
}
