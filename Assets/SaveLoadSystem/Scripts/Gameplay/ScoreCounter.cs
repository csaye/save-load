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
    }
}
