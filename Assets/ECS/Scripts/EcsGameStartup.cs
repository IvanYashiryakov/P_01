using Leopotam.Ecs;
using Voody.UniLeo;
using UnityEngine;

public class EcsGameStartup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems.ConvertScene();

        AddInjections();
        //AddOneFrames();
        AddSystems();

        _systems.Init();
    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        if (_systems == null)
            return;

        _systems.Destroy();
        _systems = null;
        _world.Destroy();
        _world = null;
    }

    private void AddSystems()
    {
        _systems.
            Add(new EntityInitializeSystem()).
            Add(new OreColoumnSpawnSystem()).
            Add(new OreSpawnSystem())
            ;
    }

    private void AddInjections()
    {

    }

    private void AddOneFrames()
    {
        _systems.
            OneFrame<EntityInitializeRequestComponent>()
            ;
    }
}
