using _Project.Scripts.ECS.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace _Project.Scripts.ECS.Systems
{
    public class MoveAnimationSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter _moveFilter;
        private EcsPool<PlayerMovementComponent> _playerMovementPool;
        private EcsPool<InputComponent> _playerInputPool;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _moveFilter = _world.Filter<PlayerMovementComponent>().Inc<InputComponent>().End();

            _playerInputPool = _world.GetPool<InputComponent>();
            _playerMovementPool = _world.GetPool<PlayerMovementComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _moveFilter)
            {
                ref var inputEntity = ref _playerInputPool.Get(entity);
                ref var moveEntity = ref _playerMovementPool.Get(entity);

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