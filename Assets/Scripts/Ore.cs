using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ore : MonoBehaviour
{
    [SerializeField] private int _health;

    private bool _isFree;

    public bool IsFree => _isFree;

    [HideInInspector] public UnityAction<Ore> Destroyed;

    private void Start()
    {
        _isFree = true;
    }

    private void OnDestroy()
    {
        Destroyed?.Invoke(this);
    }

    public void SetBusy()
    {
        _isFree = false;
    }
}
