using _Project.Scripts.Configs;
using _Project.Scripts.ECS;
using _Project.Scripts.ECS.Components;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
    public class SceneMainInstaller : MonoInstaller
    {
        [SerializeField] private Loader _loaderPrefab;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private EnemyConfig _enemyConfig;
        
        public override void InstallBindings()
        {
            Container
                .Bind<Camera>()
                .FromInstance(Camera.main)
                .AsSingle();
            
            Container
                .Bind<Loader>()
                .FromComponentInNewPrefab(_loaderPrefab)
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<PlayerComponent>()
                .AsSingle()
                .WithArguments(_playerConfig);
            
            Container
                .Bind<DefaultEnemyComponent>()
                .AsSingle()
                .WithArguments(_enemyConfig);
        }
    }
}