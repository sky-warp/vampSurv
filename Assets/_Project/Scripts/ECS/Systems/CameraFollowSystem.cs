using _Project.Scripts.ECS.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace _Project.Scripts.ECS.Systems
{
    public class CameraFollowSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter _cameraFilter;
        private EcsPool<CameraFollowerComponent> _cameraPool;
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _cameraPool = _world.GetPool<CameraFollowerComponent>();
            
            _cameraFilter = _world.Filter<CameraFollowerComponent>().End();
        }
        
        public void Run(IEcsSystems systems)
        {
            foreach (int entities in _cameraFilter)
            {
                ref var camera = ref _cameraPool.Get(entities);
                camera.Camera.transform.position = camera.Target.transform.position + new Vector3(0, 0, -10);
            }
        }
    }
}