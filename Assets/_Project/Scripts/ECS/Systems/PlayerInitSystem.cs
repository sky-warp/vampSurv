using _Project.Scripts.ECS.Components;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.ECS.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            int player = world.NewEntity();

            EcsPool<InputComponent> inputPool = world.GetPool<InputComponent>();
            inputPool.Add(player);

            EcsPool<MovableComponent> movablePool = world.GetPool<MovableComponent>();
            movablePool.Add(player);

            var container = ProjectContext.Instance.Container;
            
            EcsPool<PlayerDataComponent> playerDataPool = world.GetPool<PlayerDataComponent>();
            playerDataPool.Add(player) = container.Resolve<PlayerDataComponent>();

            EcsFilter playerFilter = world.Filter<PlayerDataComponent>().End();
            EcsFilter movableFilter = world.Filter<MovableComponent>().End();

            foreach (int dataEntities in playerFilter)
            {
                ref var playerData = ref playerDataPool.Get(dataEntities);

                foreach (int movingEntities in movableFilter)
                {
                    ref var movingPlayerData = ref movablePool.Get(movingEntities);
                    movingPlayerData.Speed = playerData.Speed;
                }
                
                GameObject.Instantiate(playerData.PlayerPrefab);
            }
        }
    }

    public struct PlayerDataComponent
    {
        public GameObject PlayerPrefab;
        public Animator PlayerAnimator;
        public float Speed;

        public PlayerDataComponent(GameObject playerPrefab, Animator playerAnimator, float speed)
        {
            PlayerPrefab = playerPrefab;
            PlayerAnimator = playerAnimator;
            Speed = speed;
        }
    }
}