using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mine : MonoBehaviour
{
    [SerializeField] private GameObject _oreColoumnPrafab;
    [SerializeField] private int _width;
    [SerializeField] private int _height;

    private List<OreColoumn> _oreColoumns;
    private float _offsetX;

    [HideInInspector] public UnityAction Finished;

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

        if (_oreColoumns.Count == 0)
            Finished?.Invoke();
    }

    public void CreateLevel(Level level)
    {
        Scores.Instance.RefillFuel();
        _oreColoumns = new List<OreColoumn>();
        _offsetX = (5f - level.Width) / 2f;

        for (int i = 0; i < level.Height; i++)
        {
            var oreColoumn = Instantiate(_oreColoumnPrafab, transform);
            oreColoumn.name = "OC " + i;
            oreColoumn.transform.position = new Vector3(_offsetX, 0.5f, -i);
            _oreColoumns.Add(oreColoumn.GetComponent<OreColoumn>());
            _oreColoumns[i].Destroyed += OnOreColoumnDestroyed;
            _oreColoumns[i].Init(level.Width, _offsetX, level.OreHealth, level.OreGold);
        }
    }
}
