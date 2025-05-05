using UnityEngine;

namespace _Project.Scripts.ECS.Components
{
    public struct MovableComponent
    {
        public Transform Transform;
        public float Speed;
        public bool IsMoving;
    }
}