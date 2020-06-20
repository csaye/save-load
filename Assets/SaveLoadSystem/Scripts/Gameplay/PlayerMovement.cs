using SaveLoadSystem.SaveLoad;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SaveLoadSystem.Gameplay
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Attributes")]
        public float speed;

        [Header("References")]
        public Rigidbody2D rb;
        public Camera mainCamera;
        public TextMeshProUGUI playerPositionText;

        private void Update()
        {
            UpdateMovement();

            playerPositionText.text = ((Vector2)transform.position).ToString();
        }

        private void UpdateMovement()
        {
            Vector2 bounds = (Vector2)mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

            Vector2 pos = transform.position;

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // If position exceeds bounds, stop movement
            if (pos.x > bounds.x && horizontal > 0)
            {
                horizontal = 0;
            }
            if (pos.x < (bounds.x * -1) && horizontal < 0)
            {
                horizontal = 0;
            }
            if (pos.y > bounds.y && vertical > 0)
            {
                vertical = 0;
            }
            if (pos.y < (bounds.y * -1) && vertical < 0)
            {
                vertical = 0;
            }

            rb.velocity = new Vector2(horizontal, vertical).normalized * speed;
        }

        private void OnEnable()
        {
            GameEvents.onSaveEvent += OnSave;
            GameEvents.onLoadEvent += OnLoad;
        }

        private void OnSave()
        {
            SaveData.current.playerData.playerPosition = (Vector2)transform.position;
        }

        private void OnLoad()
        {
            transform.position = SaveData.current.playerData.playerPosition;
        }

        private void OnDisable()
        {
            GameEvents.onSaveEvent -= OnSave;
            GameEvents.onLoadEvent -= OnLoad;
        }
    }
}
