using System;
using _Project.Scripts.ECS.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace _Project.Scripts.ECS.Systems
{
    public class InputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter _inputFilter;
        private EcsFilter _movableFilter;
        private EcsPool<InputComponent> _inputPool;
        private EcsPool<MovementComponent> _movablePool;
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _inputFilter = _world.Filter<InputComponent>().End();
            _movableFilter = _world.Filter<MovementComponent>().End();
            
            _inputPool = _world.GetPool<InputComponent>();
            _movablePool = _world.GetPool<MovementComponent>();
        }
        
        public void Run(IEcsSystems systems)
        {
            float x  = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            if (Math.Abs(x) > 0 || Math.Abs(y) > 0)
            {
                foreach (int entities in _inputFilter)
                {
                    foreach (int moveEntities in _movableFilter)
                    {
                        ref var moveEntity = ref _movablePool.Get(moveEntities);
                        moveEntity.IsMoving = true;
                    }
                    ref var entity = ref _inputPool.Get(entities);
                    entity.Direction.X = x;
                    entity.Direction.Y = y;
                }
            }
            else
            {
                foreach (int moveEntities in _movableFilter)
                {
                    ref var moveEntity = ref _movablePool.Get(moveEntities);
                    moveEntity.IsMoving = false;
                }
            }
        }
    }
}