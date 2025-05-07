using UnityEngine;

namespace _Project.Scripts.ECS.Components
{
    public struct PlayerDataComponent
    {
        public GameObject PlayerPrefab;
        public Animator PlayerAnimator;
        public float Speed;
        public float Decay;

        public PlayerDataComponent(GameObject playerPrefab, Animator playerAnimator, float speed, float decay)
        {
            PlayerPrefab = playerPrefab;
            PlayerAnimator = playerAnimator;
            Speed = speed;
            Decay = decay;
        }
    }
}