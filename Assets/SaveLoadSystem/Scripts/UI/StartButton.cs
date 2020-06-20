using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SaveLoadSystem.UI
{
    public class StartButton : MonoBehaviour
    {
        [Header("References")]
        public TMP_InputField saveNameField;
        public Button button;

        private void Update()
        {
            button.interactable = (saveNameField.text != "");
        }
    }
}
