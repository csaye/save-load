using UnityEngine;

namespace SaveLoadSystem.SaveLoad
{
    public class PlayerData
    {
        public string playerName;
        public int playerPoints;
        public Vector2 playerPosition;

        public PlayerData(string _playerName, int _playerPoints, Vector2 _playerPosition)
        {
            playerName = _playerName;
            playerPoints = _playerPoints;
            playerPosition = _playerPosition;
        }
    }
}
