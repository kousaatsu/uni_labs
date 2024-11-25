using Leopotam.EcsLite;
using UnityEngine;

namespace MovementSystem
{
    public class ZigzagMover : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _ecsWorld;
        private EcsFilter _entityFilter;
        private EcsPool<ZigzagMovement> _zigzagPool;
        private EcsPool<TransformComponent> _transformPool;

        public void Init(IEcsSystems systems)
        {
            _ecsWorld = systems.GetWorld();
            _entityFilter = _ecsWorld.Filter<ZigzagMovement>().Inc<TransformComponent>().End();
            _zigzagPool = _ecsWorld.GetPool<ZigzagMovement>();
            _transformPool = _ecsWorld.GetPool<TransformComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _entityFilter)
            {
                ref ZigzagMovement movement = ref _zigzagPool.Get(entity);
                ref TransformComponent transformComponent = ref _transformPool.Get(entity);
                transformComponent.Transform.position += movement.Direction * (movement.Speed * Time.deltaTime);
                if (transformComponent.Transform.position.x > movement.Range && movement.Direction.x > 0 ||
                    transformComponent.Transform.position.x < -movement.Range && movement.Direction.x < 0)
                {
                    movement.Direction = new Vector3(movement.Direction.x * -1, movement.Direction.y, movement.Direction.z);
                }
            }
        }
    }
}
