using System;
using Player.Scripts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class JoinLobbyMenu : MonoBehaviour
    {
        [SerializeField] private NetworkRoomPlayerLobby networkManager = null;
        
        [Header("UI")]
        [SerializeField] private GameObject landingPagePanel = null;

        [SerializeField] private TMP_InputField ipAddressInputField = null;
        [SerializeField] private Button joinButton = null;

        private void OnEnable()
        {
            NetworkRoomPlayerLobby.OnClientConnect += HandleClientConnected;
            NetworkRoomPlayerLobby.OnClientDisconnected += HandleClientDisconnected;
        }

        private void OnDisable()
        {
            NetworkRoomPlayerLobby.OnClientConnect -= HandleClientConnected;
            NetworkRoomPlayerLobby.OnClientDisconnected -= HandleClientDisconnected;
        }

        public void JoinLobby()
        {
            string ipAddress = ipAddressInputField.text;

            networkManager.NetworkAddress = ipAddress;
            networkManager.OnStartClient();

            joinButton.interactable = false;
        }

        public void HandleClientConnected()  
        {
            joinButton.interactable = true;
            gameObject.SetActive(false);
            landingPagePanel.SetActive(false);
        }

        public void HandleClientDisconnected()
        {
            joinButton.interactable = true;
        }
    }
}