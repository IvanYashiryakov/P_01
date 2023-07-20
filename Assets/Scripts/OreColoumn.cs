using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OreColoumn : MonoBehaviour
{
    [SerializeField] private GameObject _orePrafab;
    
    private int _count;
    private List<Ore> _ores;
    private float _offsetX;
    private int _oreHealth = 0;
    private float _oreGold = 0;

    [HideInInspector] public UnityAction<OreColoumn> Destroyed;

    private void Start()
    {
        _ores = new List<Ore>();

        for (int i = 0; i < _count; i++)
        {
            var ore = Instantiate(_orePrafab, transform);
            ore.name = transform.name + "| Ore " + i;
            ore.transform.position = new Vector3(i + _offsetX, 0.5f, transform.position.z);
            _ores.Add(ore.GetComponent<Ore>());

            _ores[i].Destroyed += OnOreDestroyed;
            _ores[i].Init(_oreHealth, _oreGold);
        }
    }

    private void OnDestroy()
    {
        Destroyed?.Invoke(this);
    }

    public void Init(int count, float offsetX, int oreHealth, float oreGold)
    {
        _count = count;
        _offsetX = offsetX;
        _oreHealth = oreHealth;
        _oreGold = oreGold;
    }

    public Ore TryGetFreeOre()
    {
        for (int i = _ores.Count - 1; i >= 0; i--)
        {
            if (_ores[i].IsFree == true)
            {
                _ores[i].SetBusy();
                return _ores[i];
            }
        }

        return null;
    }

    public Ore TryGetNearestFreeOre(Vector3 point)
    {
        float minDistance = float.MaxValue;
        int minDistanceOreIndex = -1;

        for (int i = 0; i < _ores.Count; i++)
        {
            if (_ores[i].IsFree == true)
            {
                float distance = Vector3.Distance(point, _ores[i].transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    minDistanceOreIndex = i;
                }
            }
        }

        if (minDistanceOreIndex != -1)
        {
            _ores[minDistanceOreIndex].SetBusy();
            return _ores[minDistanceOreIndex];
        }

        return null;
    }

    private void OnOreDestroyed(Ore ore)
    {
        ore.Destroyed -= OnOreDestroyed;
        _ores.Remove(ore);

        if (_ores.Count == 0)
        {
            Destroy(gameObject);
        }
    }
}
