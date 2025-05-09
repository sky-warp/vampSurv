using _Project.Scripts.ECS.Components;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.ECS.Systems
{
    public class InitSystem : IEcsInitSystem
    {
        private DiContainer _container;

        public InitSystem(DiContainer container)
        {
            _container = container;
        }
        
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            int player = world.NewEntity();
            int cameraFollower = world.NewEntity();
            
            EcsPool<PlayerComponent> playerDataPool = world.GetPool<PlayerComponent>();
            ref var playerData = ref playerDataPool.Add(player);
            playerData = _container.Resolve<PlayerComponent>();

            var go = GameObject.Instantiate(playerData.PlayerPrefab);
            
            EcsPool<MovementComponent> movablePool = world.GetPool<MovementComponent>();
            ref var playerMovement = ref movablePool.Add(player);
            playerMovement.Speed = playerData.Speed;
            playerMovement.MoveDecay = playerData.Decay;
            playerMovement.PlayerBody = go.GetComponent<Rigidbody2D>();
            playerMovement.PlayerTransform = go.GetComponent<Transform>();
            
            EcsPool<AnimationComponent> animatorPool = world.GetPool<AnimationComponent>();
            ref var playerAnimator = ref animatorPool.Add(player);
            playerAnimator.PlayerAnimator = go.GetComponent<Animator>();

            EcsPool<InputComponent> inputPool = world.GetPool<InputComponent>();
            inputPool.Add(player);
            
            EcsPool<CameraFollowerComponent> cameraPool = world.GetPool<CameraFollowerComponent>();
            ref var attachedCamera = ref cameraPool.Add(cameraFollower);
            attachedCamera.Camera = _container.Resolve<Camera>();
            attachedCamera.Target = go.transform;
        }
    }
}