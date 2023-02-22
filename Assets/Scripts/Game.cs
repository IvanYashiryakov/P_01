using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _minerPrefab;
    [SerializeField] private Mine _mine;

    public void OnButtonCreateMiner()
    {
        var miner =  Instantiate(_minerPrefab);
        miner.GetComponent<Miner>().SetMine(_mine);
    }
}
