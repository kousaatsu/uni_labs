using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpawnParamsAuthoring : MonoBehaviour
{
	[SerializeField] private GameObject _prefab;
	[SerializeField] private Vector3 _origin;
	[SerializeField] private float _radius;
	[SerializeField] private int _count;

	private class EntityBaker : Baker<SpawnParamsAuthoring>
	{
		public override void Bake(SpawnParamsAuthoring authoring)
		{
			Entity entity = GetEntity(TransformUsageFlags.None);

			AddComponent(entity, new SpawnParams { Prefab = GetEntity(authoring._prefab, TransformUsageFlags.Dynamic), Origin = authoring._origin, Radius = authoring._radius, Count = authoring._count });
		}
	}
}
