using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveLoadSystem.SaveLoad
{
    public class SerializationManager
    {
        // Serialize data to binary file
        public static void Save(string saveName, object saveData)
        {
            BinaryFormatter formatter = GetBinaryFormatter();

            string dataPath = Application.persistentDataPath;

            // If saves folder does not exist, create one
            if (!Directory.Exists(dataPath + "/saves"))
            {
                Directory.CreateDirectory(dataPath + "/saves");
            }

            string path = dataPath + "/saves/" + saveName + ".save";

            FileStream file = File.Create(path);

            formatter.Serialize(file, saveData);

            file.Close();
        }

        // Deserialize data from binary file
        public static object Load(string path)
        {
            if (!File.Exists(path))
            {
                Debug.LogError("No file exists at path " + path);
                return null;
            }

            BinaryFormatter formatter = GetBinaryFormatter();

            FileStream file = File.Open(path, FileMode.Open);

            try
            {
                object save = formatter.Deserialize(file);
                file.Close();
                return save;
            }
            catch
            {
                Debug.LogError("Failed to load file at " + path);
                file.Close();
                return null;
            }
        }

        // Returns binary formatter with surrogate for incompatible types
        private static BinaryFormatter GetBinaryFormatter()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            SurrogateSelector selector = new SurrogateSelector();

            Vector2Surrogate vector2Surrogate = new Vector2Surrogate();

            selector.AddSurrogate(typeof(Vector2), new StreamingContext(StreamingContextStates.All), vector2Surrogate);

            formatter.SurrogateSelector = selector;

            return formatter;
        }
    }
}
