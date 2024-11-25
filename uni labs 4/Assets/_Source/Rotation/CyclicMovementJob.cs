using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct CyclicMovementJob : IJobEntity
{
    public float DeltaTime;

    public void Execute(ref LocalTransform transform, in ParrotRotation parrotRotation)
    {
        transform.Position = Quaternion.AngleAxis(DeltaTime * parrotRotation.Speed, parrotRotation.Axis) * transform.Position;
    }
}