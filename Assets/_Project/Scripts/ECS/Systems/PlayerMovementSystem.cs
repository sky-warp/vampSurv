using _Project.Scripts.ECS.Components;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.ECS.Systems
{
    public class PlayerMovementSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter _movableEntitiesFilter;
        private EcsPool<InputComponent> _inputPool;
        private EcsPool<PlayerMovementComponent> _movablePool;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _movableEntitiesFilter = _world.Filter<PlayerMovementComponent>().Inc<InputComponent>().End();

            _inputPool = _world.GetPool<InputComponent>();
            _movablePool = _world.GetPool<PlayerMovementComponent>();
        }
        
        public void Run(IEcsSystems systems)
        {
            foreach (int entities in _movableEntitiesFilter)
            {
                ref var entityMove = ref _movablePool.Get(entities);
                ref var entityInput = ref _inputPool.Get(entities);

                Vector2 direction = new Vector2(entityInput.Direction.X, entityInput.Direction.Y);
                Vector2 newVelocity = entityMove.PlayerBody.linearVelocity + direction;
                newVelocity = Vector2.ClampMagnitude(newVelocity, entityMove.Speed);

                if (entityMove.IsMoving)
                    entityMove.PlayerBody.linearVelocity = newVelocity;
                else
                    entityMove.PlayerBody.linearVelocity *= entityMove.MoveDecay;
            }
        }
    }
}