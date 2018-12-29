using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using HaxwareRTS;

public class MovementSystem : JobComponentSystem
{
    [ComputeJobOptimization]
    struct MovementJob : IJobProcessComponentData <Position, MoveSpeed>
    {
        public float deltaTime;

        public void Execute(ref Position pos, [ReadOnly] ref MoveSpeed spd)
        {
            float3 val = pos.Value;

            val += deltaTime * spd.Value;

            pos.Value = val;
        }
    }

    // 
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        MovementJob mJob = new MovementJob
        {
            deltaTime = Time.deltaTime
        };

        return mJob.Schedule(this, 64, inputDeps);
    }
}