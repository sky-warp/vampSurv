using UnityEngine;

namespace _Project.Scripts.ECS.Components
{
    public struct PlayerDataComponent
    {
        public GameObject PlayerPrefab;
        public Animator PlayerAnimator;
        public float Speed;

        public PlayerDataComponent(GameObject playerPrefab, Animator playerAnimator, float speed)
        {
            PlayerPrefab = playerPrefab;
            PlayerAnimator = playerAnimator;
            Speed = speed;
        }
    }
}