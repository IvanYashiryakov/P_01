using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

sealed class OreSpawnSystem : IEcsRunSystem
{
    private readonly EcsFilter<MineComponent,ToSpawnOreTag> _mineFilter = null;
    private readonly EcsFilter<OreColoumnComponent> _oreColoumnFilter = null;

    public void Run()
    {
        foreach (var m in _mineFilter)
        {
            ref var mine = ref _mineFilter.Get1(m);

            foreach (var o in _oreColoumnFilter)
            {
                ref var oreColoumn = ref _oreColoumnFilter.Get1(o);
                oreColoumn.Ores = new List<GameObject>();

                for (int h = 0; h < mine.Height; h++)
                {
                    var ore = GameObject.Instantiate(mine.OrePrafab, oreColoumn.Transform);
                    ore.name = oreColoumn.Transform.name + "| Ore " + h;
                    ore.transform.position = new Vector3(h, 0.5f, oreColoumn.Transform.position.z);
                    oreColoumn.Ores.Add(ore);
                }

                ref var mineEntity = ref _mineFilter.GetEntity(m);
                mineEntity.Del<ToSpawnOreTag>();
            }
        }
    }
}
