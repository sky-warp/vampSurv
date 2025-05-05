using _Project.Scripts.ECS.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace _Project.Scripts.ECS.Systems
{
    public class PlayerInputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter _inputFilter;
        private EcsPool<InputComponent> _inputPool;
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _inputFilter = _world.Filter<InputComponent>().End();
            
            _inputPool = _world.GetPool<InputComponent>();
        }
        
        public void Run(IEcsSystems systems)
        {
            float x  = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            if (x != 0 || y != 0)
            {
                foreach (int entities in _inputFilter)
                {
                    ref var entity = ref _inputPool.Get(entities);
                    entity.Direction.X = x;
                    entity.Direction.Y = y;
                }
            }
        }
    }
}