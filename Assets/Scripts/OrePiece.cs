using UnityEngine;
using UnityEngine.Events;

public class OrePiece : MonoBehaviour
{
    private float _health;
    private float _goldAmount;
    private Ore _parent;

    public float Health => _health;
    [HideInInspector] public UnityAction<OrePiece> Destroyed;
    [HideInInspector] public UnityAction Damaged;

    public void Init(Ore parent, float health, float gold)
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
        Damaged?.Invoke();

        if (_health <= 0)
        {
            Scores.Instance.AddGold(_goldAmount);
            ObjectPool.Instance.Spawn(_goldAmount, SpriteType.Gold, transform.position);
            Destroyed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
