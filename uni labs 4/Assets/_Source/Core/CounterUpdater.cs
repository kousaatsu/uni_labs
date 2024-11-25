using Leopotam.EcsLite;
using UnityEngine;

namespace CoreSystem
{
    public class CounterUpdater : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _ecsWorld;
        private EcsFilter _entityFilter;
        private EcsPool<CounterData> _counterPool;

        public void Init(IEcsSystems systems)
        {
            _ecsWorld = systems.GetWorld();
            _entityFilter = _ecsWorld.Filter<CounterData>().End();
            _counterPool = _ecsWorld.GetPool<CounterData>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _entityFilter)
            {
                ref CounterData counter = ref _counterPool.Get(entity);
                counter.Value++;
            }
        }
    }
}
