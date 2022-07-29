using TMPro;
using UnityEngine;

namespace Network
{
    [RequireComponent(typeof(CustomLevelLoadNetworkManager))]
    public class NetworkInformationField : MonoBehaviour
    {
        [SerializeField] private GameObject panelToActivate = null;
        [SerializeField] private TMP_Text infoText = null;
        
        private CustomLevelLoadNetworkManager _mCustomLevelLoadNetworkManager;

        void Start()
        {
            _mCustomLevelLoadNetworkManager = GetComponent<CustomLevelLoadNetworkManager>();
        }

        private void OnEnable()
        {
            CustomLevelLoadNetworkManager.ConnectingAsClient += showCurrentlyConnectingInfo;
            CustomLevelLoadNetworkManager.ConnectedToServer += hideCurrentlyConnectingInfo;
        }

        private void OnDisable()
        {
            CustomLevelLoadNetworkManager.ConnectingAsClient -= showCurrentlyConnectingInfo;
            CustomLevelLoadNetworkManager.ConnectedToServer -= hideCurrentlyConnectingInfo;
        }

        private void showCurrentlyConnectingInfo()
        {
            panelToActivate.SetActive(true);
            var ipConnectingTo = _mCustomLevelLoadNetworkManager.networkAddress;

            infoText.text = $"Currently Connecting to Server (Ip: {ipConnectingTo})";
        }

        private void hideCurrentlyConnectingInfo()
        {
            panelToActivate.SetActive(false);
        }
    }
}
