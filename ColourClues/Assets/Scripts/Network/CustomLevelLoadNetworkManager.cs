using System;
using System.Net;
using System.Net.Sockets;
using Mirror;
using UnityEngine;
using View;

namespace Network
{
    /// <summary>
    /// Customized Network Manager for Levels (<see cref="NetworkManager"/>)
    ///
    /// Requires:
    ///  - <see cref="LoadMode" /> for Configuration Load
    ///  - <see cref="PlayerNetworkMode" /> for COnfiguration Load
    ///  - <see cref="NetworkIdentity" /> for Network Identification 
    /// </summary>
    [RequireComponent(typeof(LoadMode))]
    [RequireComponent(typeof(PlayerNetworkMode))]
    [RequireComponent(typeof(NetworkIdentity))]
    public class CustomLevelLoadNetworkManager : NetworkManager
    {
        private LoadMode _mLoadMode;
        private CustomLevelLoadNetworkManager _mNetworkManager = null;
        private NetworkIdentity _mNetworkIdentity = null;
        [SerializeField] private LevelManager levelManager = null;

        [SerializeField] private GameObject backupObject = null;

        public bool currentlyConnecting { get; private set; }
        public int currentlyConnected { get; private set; }

        [SerializeField] private bool serverMode = false;
        [SerializeField] private int minPlayers = 2;
        
        public static event Action ConnectingAsClient;
        public static event Action ConnectedToServer;
        public static event Action ConnectionUpdate;
        
        void Start()
        {
            currentlyConnecting = false;
            
            _mLoadMode = GetComponent<LoadMode>();
            _mNetworkManager = GetComponent<CustomLevelLoadNetworkManager>();
            _mNetworkIdentity = GetComponent<NetworkIdentity>();
            
            if (serverMode)
            {
                _mNetworkManager.StartHost();
                currentlyConnected++;
                Debug.Log($"Started host on {GetLocalIPAddress()}");
            }
            else
            {
                currentlyConnecting = true;
                var addressToConnectTo = "localhost";
                _mNetworkManager.networkAddress = addressToConnectTo;

                Debug.Log($"trying to connect to {_mNetworkManager.networkAddress}");

                _mNetworkManager.StartClient();
                ConnectingAsClient?.Invoke();
            }
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            
            NetworkServer.RegisterHandler<CreateColorOwnerGameObjectMessage>(OnCreateCharacter);
        }

        [Server]
        public override void OnServerReady(NetworkConnectionToClient conn)
        {
            if (numPlayers == minPlayers)
            {
                base.OnServerReady(conn);
            }
        }

        public override void OnServerConnect(NetworkConnectionToClient conn)
        {
            ConnectionUpdate?.Invoke();

            currentlyConnected++;
            base.OnServerConnect(conn);
        }

        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            ConnectionUpdate?.Invoke();

            currentlyConnected--;
            base.OnServerDisconnect(conn);
        }

        public override void OnClientConnect()
        {
            ConnectedToServer?.Invoke();
            Debug.Log("Connected To Server");
            // add player at correct spawn position

            base.OnClientConnect();

            bool isLocal = _mNetworkIdentity.netId == 0;
            
            var player = levelManager.GetAvailablePlayer(isLocal);
            playerPrefab = player;
            var playerGenerationMessage = new CreateColorOwnerGameObjectMessage(player);

            Debug.Log(playerGenerationMessage);
            
            NetworkClient.Send(playerGenerationMessage);
        }

        void OnCreateCharacter(NetworkConnectionToClient conn, CreateColorOwnerGameObjectMessage player)
        {
            var playerObject = player.PlayerObject;

            if (playerObject == null)
            {
                playerObject = backupObject;
            }
            
            Debug.Log("created player");
            
            //var playerCharacter = Instantiate(playerObject);
            //playerCharacter.transform.position = new Vector3(-1.52f, 0, 0);
            
            NetworkServer.AddPlayerForConnection(conn, playerObject);
        }
        
        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public int MinPlayers => minPlayers;

        public void SetMinPlayer(int nbr)
        {
            if (!serverMode || currentlyConnected > 0)
            {
                Debug.LogError("can't set min player if not server mode or after at least one person connected");
                return;
            }

            minPlayers = nbr;
        }

        public struct CreateColorOwnerGameObjectMessage: NetworkMessage
        {
            public GameObject PlayerObject;

            public CreateColorOwnerGameObjectMessage(GameObject playerObject)
            {
                PlayerObject = playerObject;
            }
        }
    }
}