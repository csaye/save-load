using SaveLoadSystem.SaveLoad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem.Gameplay
{
    public class Dot : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                DotSpawner.instance.CreateNewDot();
                ScoreCounter.score++;
                Destroy(gameObject);
            }
        }
    }
}
