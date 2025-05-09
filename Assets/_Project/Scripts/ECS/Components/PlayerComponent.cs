using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts.ECS.Components
{
    public struct PlayerComponent
    {
        public GameObject PlayerPrefab;
        public float Speed;
        public float Decay;

        public PlayerComponent(PlayerConfig config)
        {
            PlayerPrefab = config.PlayerPrefab;
            Speed = config.PlayerSpeed;
            Decay = config.MovementDecay;
        }
    }
}