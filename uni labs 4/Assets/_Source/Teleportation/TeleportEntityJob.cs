using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
public partial struct TeleportEntityJob : IJobEntity
{
	private readonly float _teleportHeight;
	private readonly float3 _upperZone;
	private readonly float3 _lowerZone;

	public TeleportEntityJob(float teleportHeight, float3 lowerZone, float3 upperZone)
	{
		_teleportHeight = teleportHeight;
		_lowerZone = lowerZone;
		_upperZone = upperZone;
	}

	private void Execute(ref LocalTransform transform, ref ParrotTeleportation parrotTeleportation)
	{
		if (transform.Position.y > _teleportHeight && parrotTeleportation.ZoneID == 1)
		{
			transform.Position += _upperZone;
			parrotTeleportation.ZoneID = 0;
		}
		else if (transform.Position.y < _teleportHeight && parrotTeleportation.ZoneID == 0)
		{
			transform.Position += _lowerZone;
			parrotTeleportation.ZoneID = 1;
		}
	}
}