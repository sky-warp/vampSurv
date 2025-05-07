using UnityEngine;

namespace _Project.Scripts.ECS.Components
{
    public struct MovementComponent
    {
        public Transform PlayerTransform;
        public Rigidbody2D PlayerBody;
        public float Speed;
        public float MoveDecay;
        public bool IsMoving;
    }
}