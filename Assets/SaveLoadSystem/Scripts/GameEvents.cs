using System;
using System.Collections;
using UnityEngine;

namespace SaveLoadSystem
{
    public class GameEvents : MonoBehaviour
    {
        public static GameEvents current;

        private void Awake()
        {
            if (current == null)
            {
                current = this;
            }
        }

        public static event Action onSaveEvent;
        public void DispatchOnSaveEvent()
        {
            if (onSaveEvent != null)
            {
                onSaveEvent();
            }
        }

        public static event Action onLoadEvent;
        public void DispatchOnLoadEvent()
        {
            if (onLoadEvent != null)
            {
                onLoadEvent();
            }
        }
    }
}