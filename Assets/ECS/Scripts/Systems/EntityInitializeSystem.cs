using Leopotam.Ecs;
using UnityEngine;

sealed class EntityInitializeSystem : IEcsRunSystem
{
    private readonly EcsFilter<EntityInitializeRequestComponent> _initFilter = null;

    public void Run()
    {
        foreach (var i in _initFilter)
        {
            ref var entity = ref _initFilter.GetEntity(i);
            ref var request = ref _initFilter.Get1(i);

            request.entityReference.Entity = entity;
            entity.Del<EntityInitializeRequestComponent>();
        }
    }
}
