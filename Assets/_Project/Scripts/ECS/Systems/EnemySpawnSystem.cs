using System;
using System.Threading;
using _Project.Scripts.ECS.Components;
using Cysharp.Threading.Tasks;
using Leopotam.EcsLite;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.ECS.Systems
{
    public class EnemySpawnSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private EcsWorld _world;
        private EcsPool<DefaultEnemyComponent> _enemyPool;
        private EcsFilter _enemyFilter;

        private GameObject _enemy;

        private CancellationTokenSource _cts = new();
        
        private float _spawnDelay = 2.0f;
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _enemyFilter = _world.Filter<DefaultEnemyComponent>().End();

            _enemyPool = _world.GetPool<DefaultEnemyComponent>();
            
            foreach (int enemies in _enemyFilter)
            {
                ref var enemy = ref _enemyPool.Get(enemies);
                _enemy = enemy.EnemyPrefab;
            }
            
            StartSpawn(_cts.Token);
        }

        public void Destroy(IEcsSystems systems)
        {
            _cts?.Cancel();
            _cts?.Dispose();
        }

        private async UniTaskVoid StartSpawn(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                SpawnEnemy();
                
                await UniTask.Delay(TimeSpan.FromSeconds(_spawnDelay), cancellationToken: token);
            }
        }

        private void SpawnEnemy()
        {
            var go = GameObject.Instantiate(_enemy);
            go.transform.position = Random.insideUnitCircle;
        }
    }
}