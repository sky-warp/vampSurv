using _Project.Scripts.ECS.Systems;
using Leopotam.EcsLite;
using UnityEngine;

namespace _Project.Scripts.ECS
{
    public class Loader : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        
        private void Start()
        {
            
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.Add(new PlayerInitSystem());
            _systems.Add(new PlayerMovementSystem());
            
            _systems.Init();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            _systems.Destroy();
            
            _world.Destroy();
        }
    }
}