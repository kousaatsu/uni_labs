using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial class ParrotSpawnerSystem : SystemBase
{
	protected override void OnCreate()
	{
		RequireForUpdate<SpawnParams>();
	}

	protected override void OnUpdate()
	{
		this.Enabled = false;

		SpawnParams spawnParams = SystemAPI.GetSingleton<SpawnParams>();
		EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(WorldUpdateAllocator);
		NativeArray<Entity> spawnedEntities = new NativeArray<Entity>(spawnParams.Count, Allocator.Temp);
		entityCommandBuffer.Instantiate(spawnParams.Prefab, spawnedEntities);

		foreach (var entity in spawnedEntities)
		{
			entityCommandBuffer.SetComponent(entity, new LocalTransform
			{ Position = (Random.insideUnitSphere * spawnParams.Radius) + (Vector3)spawnParams.Origin, Rotation = Quaternion.identity, Scale = 1f });
		}
		entityCommandBuffer.Playback(EntityManager);
	}
}