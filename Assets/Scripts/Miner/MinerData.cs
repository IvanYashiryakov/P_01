using UnityEngine;

[CreateAssetMenu]
public class MinerData : ScriptableObject
{
    public int Level;
    public Material Material;
    public Miner Miner;
    public float Damage;
    public float FuelUsage;
}
