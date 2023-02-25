using UnityEngine;
using UnityEngine.Events;

public class OrePiece : MonoBehaviour
{
    private float _health;

    [HideInInspector] public UnityAction<OrePiece> Destroyed;

    private void OnDestroy()
    {
        Destroyed?.Invoke(this);
    }

    public void Init(float health)
    {
        _health = health;
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;

        if (_health < 0)
            Destroy(gameObject);
    }
}
