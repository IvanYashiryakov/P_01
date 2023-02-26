using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ore : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private List<OrePiece> _orePieces;
    [SerializeField] private int _goldAmount;

    private bool _isFree;

    public bool IsFree => _isFree;

    [HideInInspector] public UnityAction<Ore> Destroyed;

    private void Start()
    {
        _isFree = true;
        float orePieceHealth = _health / _orePieces.Count;
        int orePieceGold = _goldAmount / _orePieces.Count;

        foreach (var piece in _orePieces)
        {
            piece.Init(this, orePieceHealth, orePieceGold);
            piece.Destroyed += OnOrePieceDestroyed;
        }
    }

    private void OnDestroy()
    {
        Destroyed?.Invoke(this);
    }

    public void SetBusy(bool busy = true)
    {
        _isFree = !busy;
    }

    private void OnOrePieceDestroyed(OrePiece orePiece)
    {
        orePiece.Destroyed -= OnOrePieceDestroyed;
        _orePieces.Remove(orePiece);

        if (_orePieces.Count == 0)
            Destroy(gameObject);
    }
}
