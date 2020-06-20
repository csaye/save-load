using UnityEngine;

namespace SaveLoadSystem.SaveLoad
{
    [System.Serializable]
    public class SaveData
    {
        private static SaveData _current;
        public static SaveData current
        {
            get
            {
                if (_current == null)
                {
                    _current = new SaveData();
                }

                return _current;
            }
            set
            {
                if (value != null)
                {
                    _current = value;
                }
            }
        }

        // Data stored by save
        public string saveName;
        public string saveScene;
        public PlayerData playerData = new PlayerData("", 0, Vector2.zero);
        public DotData dotData = new DotData(Vector2.zero);
    }
}
