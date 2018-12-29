using System;
using Unity.Entities;
using Unity.Mathematics;

namespace HaxwareRTS
{
    [Serializable]
    public struct MoveSpeed : IComponentData
    {
        public float Value;
    }

    [UnityEngine.DisallowMultipleComponent]
    public class MoveSpeedComponent : ComponentDataWrapper<MoveSpeed>
    {
    }
}
