using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

sealed class OreColoumnSpawnSystem : IEcsRunSystem, IEcsInitSystem
{
    //private readonly EcsWorld _world = null;
    private readonly EcsFilter<MineComponent, ToSpawnTag> _mineFilter = null;

    public void Run()
    {
        foreach (var m in _mineFilter)
        {
            ref var mine = ref _mineFilter.Get1(m);
            mine.OreColoumns = new List<GameObject>();

            for (int w = 0; w < mine.Width; w++)
            {
                var oreColoumn = GameObject.Instantiate(mine.OreColoumnPrafab, mine.Transform);
                oreColoumn.name = "OC " + w;
                oreColoumn.transform.position = new Vector3(0, 0.5f, -w);

                mine.OreColoumns.Add(oreColoumn);

                /*
                //var entity = _world.NewEntity();
                //entity.Replace(oreColoumn.GetComponent<EntityReference>().Entity);

                ref var oreColoumnComponent = ref oreColoumn.GetComponent<EntityReference>().Entity.Get<OreColoumnComponent>();

                for (int h = 0; h < mine.Height; h++)
                {
                    var ore = GameObject.Instantiate(mine.OrePrafab, oreColoumnComponent.Transform);
                    ore.name = oreColoumnComponent.Transform.name + "| Ore " + h;
                    ore.transform.position = new Vector3(h, 0.5f, oreColoumnComponent.Transform.position.z);
                    oreColoumnComponent.Ores.Add(ore);
                }
                */
            }

            ref var mineEntity = ref _mineFilter.GetEntity(m);
            mineEntity.Del<ToSpawnTag>();
        }
    }

    public void Init()
    {
        
    }
}
