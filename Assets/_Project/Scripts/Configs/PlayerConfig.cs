using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject PlayerPrefab { get; private set; }
        [field: SerializeField] public float PlayerSpeed { get; private set; }
        [field: SerializeField, Range(0, 1)] public float MovementDecay { get; set; }
    }
}