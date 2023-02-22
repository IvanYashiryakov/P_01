using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private GameObject _oreColoumnPrafab;
    [SerializeField] private int _count;

    private List<OreColoumn> _oreColoumns;

    private void Start()
    {
        _oreColoumns = new List<OreColoumn>();

        for (int i = 0; i < _count; i++)
        {
            var oreColoumn = Instantiate(_oreColoumnPrafab, transform);
            oreColoumn.transform.position = new Vector3(0, 0.5f, -i);
            _oreColoumns.Add(oreColoumn.GetComponent<OreColoumn>());
            _oreColoumns[i].Destroyed += OnOreColoumnDestroyed;
        }
    }

    public Ore TryGetFreeOre()
    {
        if (_oreColoumns.Count > 0)
        {
            return _oreColoumns[0].TryGetFreeOre();
        }

        return null;
    }

    public Ore TryGetNearestFreeOre(Vector3 point)
    {
        if (_oreColoumns.Count > 0)
        {
            return _oreColoumns[0].TryGetNearestFreeOre(point);
        }

        return null;
    }

    private void OnOreColoumnDestroyed(OreColoumn oreColoumn)
    {
        oreColoumn.Destroyed -= OnOreColoumnDestroyed;
        _oreColoumns.Remove(oreColoumn);
    }
}
