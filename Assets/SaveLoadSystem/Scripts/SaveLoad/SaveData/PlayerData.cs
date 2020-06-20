using UnityEngine;

namespace SaveLoadSystem.SaveLoad
{
    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public int playerScore;
        public Vector2 playerPosition;

        public PlayerData(string _playerName, int _playerScore, Vector2 _playerPosition)
        {
            playerName = _playerName;
            playerScore = _playerScore;
            playerPosition = _playerPosition;
        }
    }
}
