using UnityEngine;

namespace _Project.Scripts.ECS.Components
{
    public struct PlayerDataComponent
    {
        public GameObject PlayerPrefab;
        public float Speed;
        public float Decay;

        public PlayerDataComponent(GameObject playerPrefab, float speed, float decay)
        {
            PlayerPrefab = playerPrefab;
            Speed = speed;
            Decay = decay;
        }
    }
}