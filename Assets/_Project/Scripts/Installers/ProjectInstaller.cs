using _Project.Scripts.Configs;
using _Project.Scripts.ECS;
using _Project.Scripts.ECS.Systems;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
    [CreateAssetMenu(fileName = "ProjectInstaller", menuName = "Installers/ProjectInstaller")]
    public class ProjectInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Loader _loaderPrefab;
        [SerializeField] private PlayerConfig _config;
        
        public override void InstallBindings()
        {
            Container
                .Bind<Loader>()
                .FromComponentInNewPrefab(_loaderPrefab)
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<PlayerDataComponent>()
                .AsCached()
                .WithArguments(_config.PlayerPrefab, _config.PlayerAnimator, _config.PlayerSpeed);
        }
    }
}