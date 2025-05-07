using _Project.Scripts.ECS.Systems;
using Leopotam.EcsLite;
using UnityEngine;

namespace _Project.Scripts.ECS
{
    public class Loader : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _defaultSystems;
        private EcsSystems _physicsSystems;
        
        private void Start()
        {
            
            _world = new EcsWorld();
            _defaultSystems = new EcsSystems(_world);
            _physicsSystems = new EcsSystems(_world);

            _defaultSystems.Add(new PlayerInitSystem());
            _defaultSystems.Add(new PlayerInputSystem());
            _defaultSystems.Add(new MoveAnimationSystem());

            _physicsSystems.Add(new PlayerMovementSystem());
            
            _defaultSystems.Init();
            _physicsSystems.Init();
        }

        private void Update()
        {
            _defaultSystems?.Run();
        }

        private void FixedUpdate()
        {
            _physicsSystems?.Run();
        }
        
        private void OnDestroy()
        {
            _defaultSystems?.Destroy();
            
            _world?.Destroy();
        }
    }
}