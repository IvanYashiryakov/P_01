using UnityEngine;
using UnityEngine.Events;

public class Miner : MonoBehaviour
{
    [SerializeField] private Transform _drill;
    [SerializeField] private float _drillSpeed = 5f;
    [SerializeField] private Mine _mine;
    [SerializeField] private MinerData _minerData;

    private MinerData _nextLevelMinerData;
    private Miner _minerToMergeWith;

    public Mine Mine => _mine;
    public float Damage => _minerData.Damage;
    public int Level => _minerData.Level;
    public float FuelUsage => _minerData.FuelUsage;
    public MinerData NextLevelMinerData => _nextLevelMinerData;
    public Miner MinerToMergeWith => _minerToMergeWith;

    [HideInInspector] public UnityAction MergeStarted;
    [HideInInspector] public UnityAction<Miner, MinerData> Destroyed;
    [HideInInspector] public UnityAction MergeDone;

    private void OnDestroy()
    {
        Destroyed?.Invoke(this, _nextLevelMinerData);
    }

    public void Init(Mine mine, MinerData minerData)
    {
        _mine = mine;
        _minerData = minerData;
    }

    public void SetNextLevelMinerData()
    {
        //_minerData = _nextLevelMinerData;
        //_meshRenderer.material = _minerData.Material;
        //_nextLevelMinerData = null;
        //_minerToMergeWith = null;
        //gameObject.name = "Miner " + _minerData.Level;
        //MergeDone?.Invoke();
        Destroy(gameObject);
    }

    public void StartMerge(Miner minerToMergeWith, MinerData minerData = null)
    {
        _nextLevelMinerData = minerData;
        _minerToMergeWith = minerToMergeWith;
        MergeStarted?.Invoke();
    }

    public void RotateDrill(float deltaTime)
    {
        if (_drill == null)
            return;

        float currentRotationZ = _drill.transform.eulerAngles.z;
        float newRotationZ = currentRotationZ + _drillSpeed * deltaTime;
        _drill.transform.eulerAngles = new Vector3(_drill.transform.eulerAngles.x, _drill.transform.eulerAngles.y, newRotationZ);
    }
}
