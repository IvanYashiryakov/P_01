using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct MineComponent
{
    public int Width;
    public int Height;
    public GameObject OreColoumnPrafab;
    public GameObject OrePrafab;
    public Transform Transform;
    [HideInInspector] public List<GameObject> OreColoumns;
}
