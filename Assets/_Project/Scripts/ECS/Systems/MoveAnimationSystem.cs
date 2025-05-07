using _Project.Scripts.ECS.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace _Project.Scripts.ECS.Systems
{
    public class MoveAnimationSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter _moveAnimatedFilter;
        private EcsPool<PlayerMovementComponent> _playerMovementPool;
        private EcsPool<InputComponent> _playerInputPool;
        private EcsPool<AnimationComponent> _animationPool;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _moveAnimatedFilter = _world.Filter<PlayerMovementComponent>().Inc<InputComponent>().Inc<AnimationComponent>().End();

            _playerInputPool = _world.GetPool<InputComponent>();
            _playerMovementPool = _world.GetPool<PlayerMovementComponent>();
            _animationPool = _world.GetPool<AnimationComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _moveAnimatedFilter)
            {
                ref var inputEntity = ref _playerInputPool.Get(entity);
                ref var moveEntity = ref _playerMovementPool.Get(entity);
                ref var animationEntity = ref _animationPool.Get(entity);

                if(moveEntity.IsMoving)
                    animationEntity.PlayerAnimator.SetBool("IsMoving", true);
                else
                    animationEntity.PlayerAnimator.SetBool("IsMoving", false);
                
                if (inputEntity.Direction.X < 0)
                {
                    moveEntity.PlayerTransform.gameObject.transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    moveEntity.PlayerTransform.gameObject.transform.localScale = Vector3.one;
                }
            }
        }
    }
}