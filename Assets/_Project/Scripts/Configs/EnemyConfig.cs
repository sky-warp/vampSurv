using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/ Enemy Config")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject EnemyPrefab {get; private set;}
        [field: SerializeField] public float EnemySpeed {get; private set;}
    }
}