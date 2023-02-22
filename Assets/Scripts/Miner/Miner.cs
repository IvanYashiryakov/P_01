using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    [SerializeField] private Mine _mine;

    public Mine Mine => _mine;

    public void SetMine(Mine mine)
    {
        _mine = mine;
    }
}
