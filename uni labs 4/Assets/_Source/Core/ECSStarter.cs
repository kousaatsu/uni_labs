using Leopotam.EcsLite;
using MovementSystem;
using UnityEngine;
using Voody.UniLeo.Lite;

namespace CoreSystem
{
    public class ECSStarter : MonoBehaviour
    {
        private EcsWorld _ecsWorld;
        private EcsSystems _ecsSystems;

        private void Start()
        {
            _ecsWorld = new EcsWorld();
            _ecsSystems = new EcsSystems(_ecsWorld);
            _ecsSystems.ConvertScene();
            _ecsSystems.Add(new CounterUpdater());
            _ecsSystems.Add(new ZigzagMover());
            _ecsSystems.Init();
        }

        private void Update()
        {
            _ecsSystems?.Run();
        }

        private void OnDestroy()
        {
            _ecsSystems?.Destroy();
            _ecsWorld?.Destroy();
            _ecsSystems = null;
            _ecsWorld = null;
        }
    }
}
