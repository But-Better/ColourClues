using Player.Scripts;
using UnityEngine;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private CustomRoomNetworkManager networkManagerLobby = null;

        [Header("UI")] [SerializeField] private GameObject landingPagePanel = null;

        public void HostLobby()
        {
            networkManagerLobby.StartHost();

            landingPagePanel.SetActive(false);
        }
    }
}