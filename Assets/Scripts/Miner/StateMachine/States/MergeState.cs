using UnityEngine;

[RequireComponent(typeof(Miner))]
public class MergeState : State
{
    [SerializeField] private float _speed = 1f;

    private Miner _miner;

    private void Start()
    {
        _miner = GetComponent<Miner>();
    }

    private void Update()
    {
        if (_miner.NextLevelMinerData != null)
            transform.position = Vector3.MoveTowards(transform.position, _miner.MinerToMergeWith.transform.position, _speed * Time.deltaTime);
    }
}
