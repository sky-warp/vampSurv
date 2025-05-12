using _Project.Scripts.ECS.Systems;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.ECS
{
    public class Loader : MonoBehaviour
    {
        private EcsWorld _world;
        
        private EcsSystems _defaultSystems;
        private EcsSystems _physicsSystems;
        private EcsSystems _cameraSystems;
        
        private DiContainer _container;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }
        
        private void Start()
        {
            _world = new EcsWorld();
            _defaultSystems = new EcsSystems(_world);
            _physicsSystems = new EcsSystems(_world);
            _cameraSystems = new EcsSystems(_world);

            _defaultSystems.Add(new InitSystem(_container));
            _defaultSystems.Add(new EnemyInitSystem(_container));
            _defaultSystems.Add(new InputSystem());
            _defaultSystems.Add(new MoveAnimationSystem());
            //_defaultSystems.Add(new EnemySpawnSystem());

            _physicsSystems.Add(new MovementSystem());

            _cameraSystems.Add(new CameraFollowSystem());
            
            _defaultSystems.Init();
            _physicsSystems.Init();
            _cameraSystems.Init();
        }

        private void Update()
        {
            _defaultSystems?.Run();
        }

        private void LateUpdate()
        {
            _cameraSystems?.Run();
        }
        
        private void FixedUpdate()
        {
            _physicsSystems?.Run();
        }
        
        private void OnDestroy()
        {
            _defaultSystems?.Destroy();
            _physicsSystems?.Destroy();
            _cameraSystems?.Destroy();
            
            _world?.Destroy();
        }
    }
}