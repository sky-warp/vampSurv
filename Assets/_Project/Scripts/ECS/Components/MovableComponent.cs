using UnityEngine;

namespace _Project.Scripts.ECS.Components
{
    public struct MovableComponent
    {
        public Rigidbody2D PlayerBody;
        public float Speed;
        public float MoveDecay;
        public bool IsMoving;
    }
}