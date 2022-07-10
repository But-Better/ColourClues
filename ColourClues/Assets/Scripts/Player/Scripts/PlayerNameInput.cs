using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Scripts
{
    public class PlayerNameInput: MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TMP_InputField nameInputField = null;
        [SerializeField] private Button continueButton = null;

        public static string DisplayName { get; private set; }
        private const string PlayerPrefsNameKey = "PlayerName";

        private void Start() => SetUpInputField();

        private void SetUpInputField()
        {
            if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)) { return; }

            string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

            nameInputField.text = defaultName;

            ValidatePlayerName(defaultName);
        }

        public void ValidatePlayerName(string playerName)
        {
            // validate name
            Debug.Log(playerName);
            continueButton.interactable = !string.IsNullOrEmpty(playerName);
        }

        public void SavePlayerName()
        {
            DisplayName = nameInputField.text;
            
            PlayerPrefs.SetString(PlayerPrefsNameKey, DisplayName);
        }
    }
}