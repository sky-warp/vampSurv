using System;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEngine;

namespace _Project.Scripts
{
    public sealed class NetworkedPlayerSpawner : SimulationBehaviour, IPlayerJoined, IPlayerLeft
    {
        [SerializeField] private NetworkPrefabRef _playerPrefab;
        
        private readonly Dictionary<PlayerRef, NetworkObject> _players = new();
        
        void IPlayerJoined.PlayerJoined(PlayerRef player)
        {
            if (Runner.IsServer)
            {
                NetworkObject obj = Runner.Spawn(_playerPrefab, Vector3.zero, Quaternion.identity, player);
                _players.Add(player, obj);
            }
        }

        void IPlayerLeft.PlayerLeft(PlayerRef player)
        {
            if (_players.TryGetValue(player, out var obj))
            {
                Runner.Despawn(obj);
                _players.Remove(player);
            }
        }
    }

    public sealed class CallbacksReceiver : INetworkRunnerCallbacks
    {
        public event Action<NetworkRunner, NetworkInput> OnPlayerInput;
        
        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
            OnPlayerInput?.Invoke(runner, input);
        }
        
        public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
            throw new NotImplementedException();
        }

        public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
            throw new NotImplementedException();
        }

        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            throw new NotImplementedException();
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
            throw new NotImplementedException();
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
            throw new NotImplementedException();
        }

        public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
        {
            throw new NotImplementedException();
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
            throw new NotImplementedException();
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
            throw new NotImplementedException();
        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
            throw new NotImplementedException();
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
        {
            throw new NotImplementedException();
        }

        public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
        {
            throw new NotImplementedException();
        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
            throw new NotImplementedException();
        }

        public void OnConnectedToServer(NetworkRunner runner)
        {
            throw new NotImplementedException();
        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
            throw new NotImplementedException();
        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
            throw new NotImplementedException();
        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
            throw new NotImplementedException();
        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {
            throw new NotImplementedException();
        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {
            throw new NotImplementedException();
        }

        public class Test : NetworkBehaviour
        {
            public override void FixedUpdateNetwork()
            {
                throw new NotImplementedException();
            }
        }
    }
}