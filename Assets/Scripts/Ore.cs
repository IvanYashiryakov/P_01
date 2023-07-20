using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Ore : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private List<OrePiece> _orePieces;
    [SerializeField] private Slider _slider;

    private float _goldAmount;
    private bool _isFree;
    private float _startHealth;

    public bool IsFree => _isFree;

    [HideInInspector] public UnityAction<Ore> Destroyed;

    private void Start()
    {
        _isFree = true;
        float orePieceHealth = _health / _orePieces.Count;
        float orePieceGold = _goldAmount / _orePieces.Count;

        foreach (var piece in _orePieces)
        {
            piece.Init(this, orePieceHealth, orePieceGold);
            piece.Destroyed += OnOrePieceDestroyed;
            piece.Damaged += UpdateHealth;
        }

        _slider.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Destroyed?.Invoke(this);
    }

    public void Init(int health, float gold)
    {
        _health = health;
        _goldAmount = gold;
        _startHealth = _health;
    }

    public void SetBusy(bool busy = true)
    {
        _isFree = !busy;
    }

    private void OnOrePieceDestroyed(OrePiece orePiece)
    {
        orePiece.Destroyed -= OnOrePieceDestroyed;
        orePiece.Damaged -= UpdateHealth;

        _orePieces.Remove(orePiece);

        if (_orePieces.Count == 0)
            Destroy(gameObject);
    }

    private void UpdateHealth()
    {
        _slider.gameObject.SetActive(true);
        float currentHealth = 0;

        foreach (var piece in _orePieces)
            currentHealth += piece.Health;

        _slider.value = currentHealth / _startHealth;
    }
}
