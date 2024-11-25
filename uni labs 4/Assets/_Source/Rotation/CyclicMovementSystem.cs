using Unity.Burst;
using Unity.Entities;

public partial struct CyclicMovementSystem : ISystem
{
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ParrotRotation>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		CyclicMovementJob movementJob = new CyclicMovementJob()
		{
			DeltaTime = SystemAPI.Time.DeltaTime
		};
		movementJob.ScheduleParallel();
	}
}
