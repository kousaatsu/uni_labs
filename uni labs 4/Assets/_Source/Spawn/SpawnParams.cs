using Unity.Entities;
using Unity.Mathematics;

public struct SpawnParams : IComponentData
{
	public Entity Prefab;
	public float3 Origin;
	public float Radius;
	public int Count;
}