using _Project.Scripts.ECS.Components;
using Leopotam.EcsLite;
using Zenject;

namespace _Project.Scripts.ECS.Systems
{
    public class EnemyInitSystem : IEcsInitSystem
    {
        private DiContainer _container;

        public EnemyInitSystem(DiContainer container)
        {
            _container = container;
        }
        
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            int defaultEnemy = world.NewEntity();
            
            EcsPool<DefaultEnemyComponent> enemyPool = world.GetPool<DefaultEnemyComponent>();
            ref var enemyComponent = ref enemyPool.Add(defaultEnemy);
            enemyComponent = _container.Resolve<DefaultEnemyComponent>();
        }
    }
}