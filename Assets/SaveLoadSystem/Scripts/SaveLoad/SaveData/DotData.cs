using UnityEngine;

namespace SaveLoadSystem.SaveLoad
{
    [System.Serializable]
    public class DotData
    {
        public Vector2 dotPosition;

        public DotData(Vector2 _dotPosition)
        {
            dotPosition = _dotPosition;
        }
    }
}
