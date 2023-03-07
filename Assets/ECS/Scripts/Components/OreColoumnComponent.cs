using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct OreColoumnComponent
{
    public Transform Transform;
    [HideInInspector] public List<GameObject> Ores;
}