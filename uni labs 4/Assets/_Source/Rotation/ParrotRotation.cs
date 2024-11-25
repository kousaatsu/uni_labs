using Unity.Entities;
using Unity.Mathematics;

public struct ParrotRotation : IComponentData
{
	public float Speed;
	public float3 Axis;
}