using _Project.Scripts.ECS.Components;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.ECS.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            int player = world.NewEntity();
            
            var container = ProjectContext.Instance.Container;
            
            EcsPool<PlayerDataComponent> playerDataPool = world.GetPool<PlayerDataComponent>();
            ref var playerData = ref playerDataPool.Add(player);
            playerData = container.Resolve<PlayerDataComponent>();

            var go = GameObject.Instantiate(playerData.PlayerPrefab);
            
            EcsPool<PlayerMovementComponent> movablePool = world.GetPool<PlayerMovementComponent>();
            ref var playerMovement = ref movablePool.Add(player);
            playerMovement.Speed = playerData.Speed;
            playerMovement.MoveDecay = playerData.Decay;
            playerMovement.PlayerBody = go.GetComponent<Rigidbody2D>();
            playerMovement.PlayerTransform = go.GetComponent<Transform>();
            
            EcsPool<AnimatorComponent> animatorPool = world.GetPool<AnimatorComponent>();
            ref var playerAnimator = ref animatorPool.Add(player);
            playerAnimator.PlayerAnimator = go.GetComponent<Animator>();

            EcsPool<InputComponent> inputPool = world.GetPool<InputComponent>();
            inputPool.Add(player);
        }
    }
}