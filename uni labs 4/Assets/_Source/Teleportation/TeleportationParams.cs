using System;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct TeleportationParams : IBufferElementData
{
	public float3 TargetPosition;
	public float MinHeight;
	public float MaxHeight;
}