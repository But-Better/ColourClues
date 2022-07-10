using System;
using Mirror;
using UnityEngine;

namespace Player.Scripts
{
    public class NetworkRoomPlayerLobby : NetworkBehaviour
    {
        public static event Action OnClientConnect;
        public static event Action OnClientDisconnected;

        public void StartHost()
        {
            throw new System.NotImplementedException();
        }

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