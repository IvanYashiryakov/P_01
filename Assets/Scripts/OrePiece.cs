using UnityEngine;
using UnityEngine.Events;

public class OrePiece : MonoBehaviour
{
    private float _health;
    private int _goldAmount;
    private Ore _parent;

    [HideInInspector] public UnityAction<OrePiece> Destroyed;

    private void OnDestroy()
    {
        Destroyed?.Invoke(this);
        Scores.Instance.AddGold(_goldAmount);
    }

    public void Init(Ore parent, float health, int gold)
    {
        _parent = parent;
        _health = health;
        _goldAmount = gold;
    }

    public void ApplyDamage(float damage)
    {
        if (_parent.IsFree == true)
            return;

        _health -= damage;

        if (_health < 0)
            Destroy(gameObject);
    }
}
