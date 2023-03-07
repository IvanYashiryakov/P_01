using System;
using UnityEngine;

[Serializable]
public struct OrePieceComponent
{
    [HideInInspector] public float Health;
    [HideInInspector] public int GoldAmount;
    [HideInInspector] public Ore Parent;
}
