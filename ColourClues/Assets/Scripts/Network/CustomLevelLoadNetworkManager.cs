using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Mirror;
using Unity.VisualScripting;
using UnityEngine;
using View;

namespace Network
{
    [RequireComponent(typeof(LoadMode))]
    [RequireComponent(typeof(PlayerNetworkMode))]
    [RequireComponent(typeof(NetworkIdentity))]
    public class CustomLevelLoadNetworkManager : NetworkManager
    {
        private LoadMode _mLoadMode;
        private CustomLevelLoadNetworkManager _mNetworkManager = null;
        private NetworkIdentity _mNetworkIdentity = null;
        [SerializeField] private LevelManager levelManager = null;
        
        
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

        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            // add player at correct spawn position
            Tuple<GameObject, Transform> playerTpl = levelManager.GetAvailablePlayer(conn);
            
            Transform start = playerTpl.Item2;
            playerPrefab = playerTpl.Item1;

            Debug.Log("created player");
            
            GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);
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
            base.OnClientConnect();
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
    }
}