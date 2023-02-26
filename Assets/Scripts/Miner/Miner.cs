using UnityEngine;
using UnityEngine.Events;

public class Miner : MonoBehaviour
{
    [SerializeField] private Mine _mine;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private MinerData _minerData;

    private MinerData _nextLevelMinerData;
    private Miner _minerToMergeWith;

    public Mine Mine => _mine;
    public float Damage => _minerData.Damage;
    public int Level => _minerData.Level;
    public MinerData NextLevelMinerData => _nextLevelMinerData;
    public Miner MinerToMergeWith => _minerToMergeWith;

    [HideInInspector] public UnityAction Merge;
    [HideInInspector] public UnityAction<Miner> Destroyed;

    private void OnDestroy()
    {
        Destroyed?.Invoke(this);
    }

    public void Init(Mine mine, MinerData minerData)
    {
        _mine = mine;
        _minerData = minerData;
        _meshRenderer.material = _minerData.Material;
    }

    public void SetNextLevelMinerData()
    {
        _minerData = _nextLevelMinerData;
        _meshRenderer.material = _minerData.Material;
        _nextLevelMinerData = null;
    }

    public void StartMerge(Miner minerToMergeWith, MinerData minerData = null)
    {
        _nextLevelMinerData = minerData;
        _minerToMergeWith = minerToMergeWith;
        Merge?.Invoke();
    }
}
