using Unity.Entities;
using UnityEngine;

public class ParrotRotationAuthoring : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private Vector3 _axis;

	private class EntityBaker : Baker<ParrotRotationAuthoring>
	{
		public override void Bake(ParrotRotationAuthoring rotationAuthoring)
		{
			Entity entity = GetEntity(TransformUsageFlags.Dynamic);
			AddComponent(entity, new ParrotRotation { Speed = rotationAuthoring._speed, Axis = rotationAuthoring._axis });
		}
	}
}