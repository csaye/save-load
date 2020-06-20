using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem.Gameplay
{
    public class DotSpawner : MonoBehaviour
    {
        public static DotSpawner instance;

        [Header("References")]
        public GameObject dotPrefab;
        public Transform dynamicObjects;
        public Camera mainCamera;

        private void Start()
        {
            if (instance == null)
            {
                instance = this;
            }

            CreateNewDot();
        }

        // Create a new dot at a random position on the screen
        public void CreateNewDot()
        {
            Vector2 bounds = (Vector2)mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

            Vector2 randomPos = new Vector2(Random.Range(bounds.x * -1, bounds.x), Random.Range(bounds.y * -1, bounds.y));

            Instantiate(dotPrefab, randomPos, Quaternion.identity, dynamicObjects);
        }
    }
}
