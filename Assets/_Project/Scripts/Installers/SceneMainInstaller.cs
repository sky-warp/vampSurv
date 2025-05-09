using _Project.Scripts.Configs;
using _Project.Scripts.ECS;
using _Project.Scripts.ECS.Components;
using _Project.Scripts.ECS.Systems;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
    public class SceneMainInstaller : MonoInstaller
    {
        [SerializeField] private Loader _loaderPrefab;
        [SerializeField] private PlayerConfig _config;
        
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
                .Bind<PlayerDataComponent>()
                .AsSingle()
                .WithArguments(_config.PlayerPrefab, _config.PlayerSpeed, _config.MovementDecay);
        }
    }
}