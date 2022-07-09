using System;
using Mirror;
using UnityEngine;

namespace Player.Scripts
{
    public class NetworkRoomPlayerLobby : NetworkBehaviour
    {
        public string NetworkAddress { get; set;}

        public void StartHost()
        {
            throw new System.NotImplementedException();
        }

        public static event Action OnClientConnect;
        public static event Action OnClientDisconnected;

        private static void OnOnClientConnect()
        {
            OnClientConnect?.Invoke();
        }

        private static void OnOnClientDisconnected()
        {
            OnClientDisconnected?.Invoke();
        }
    }
}