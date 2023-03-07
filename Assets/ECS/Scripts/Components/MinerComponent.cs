using System;
using UnityEngine;

[Serializable]
public struct MinerComponent
{
    public MeshRenderer MeshRenderer;
    public Rigidbody Rigidbody;
    public MinerData MinerData;
    public MinerData NextLevelMinerData;
    public Miner MinerToMergeWith;
    public float Speed;
    public ParticleSystem Effect;
}
