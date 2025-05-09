using UnityEngine;

namespace _Project.Scripts.ECS.Components
{
    public struct CameraFollowerComponent
    {
        public Transform Target;
        public Camera Camera;
    }
}