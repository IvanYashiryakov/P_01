using UnityEngine;

[RequireComponent(typeof(Miner))]
public class DrillOreState : State
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ParticleSystem _destroyEffect;

    private Miner _miner;
    private float _effectTime = 0.2f;
    private float _elapsedTime = 0f;

    private void OnEnable()
    {
        _rigidbody.isKinematic = false;
    }

    private void OnDisable()
    {
        _rigidbody.isKinematic = true;
    }

    private void Start()
    {
        _miner = GetComponent<Miner>();
    }

    private void Update()
    {
        _rigidbody.velocity = -transform.forward * _speed;

        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _effectTime)
        {
            _destroyEffect.Play();
            _elapsedTime = 0f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<OrePiece>(out OrePiece orePiece))
        {
            orePiece.ApplyDamage(_miner.Damage);
        }
    }
}
