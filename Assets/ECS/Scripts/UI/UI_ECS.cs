using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ECS : MonoBehaviour
{
    [SerializeField] private GameObject _minerPrefab;
    [SerializeField] private GameObject _minePrefab;

    public void ButtonCreateMiner()
    {
        Instantiate(_minerPrefab);
    }

    public void ButtonCreateMine()
    {
        Instantiate(_minePrefab);
    }
}
