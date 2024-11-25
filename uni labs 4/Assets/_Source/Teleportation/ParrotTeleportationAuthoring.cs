using Unity.Entities;
using UnityEngine;

public class ParrotTeleportationAuthoring : MonoBehaviour
{
    private class Baker : Baker<ParrotTeleportationAuthoring>
    {
        public override void Bake(ParrotTeleportationAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent(entity, new ParrotTeleportation());
        }
    }
}
