using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts.ECS.Components
{
    public struct DefaultEnemyComponent
    {
        public GameObject EnemyPrefab;
        public float Speed;

        public DefaultEnemyComponent(EnemyConfig config)
        {
            EnemyPrefab = config.EnemyPrefab;
            Speed = config.EnemySpeed;
        }
    }
}