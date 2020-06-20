using SaveLoadSystem.SaveLoad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SaveLoadSystem.Gameplay
{
    public class ScoreCounter : MonoBehaviour
    {
        public static int score;

        [Header("References")]
        public TextMeshProUGUI textField;

        private int currentScore;

        private void Update()
        {
            CheckScoreUpdate();
        }

        private void CheckScoreUpdate()
        {
            if (currentScore != score)
            {
                textField.text = "Score: " + score;
                currentScore = score;
            }
        }

        private void OnEnable()
        {
            GameEvents.onSaveEvent += OnSave;
            GameEvents.onLoadEvent += OnLoad;
        }

        private void OnSave()
        {
            SaveData.current.playerData.playerScore = score;
        }

        private void OnLoad()
        {
            score = SaveData.current.playerData.playerScore;
        }

        private void OnDisable()
        {
            GameEvents.onSaveEvent -= OnSave;
            GameEvents.onLoadEvent -= OnLoad;
        }
    }
}
