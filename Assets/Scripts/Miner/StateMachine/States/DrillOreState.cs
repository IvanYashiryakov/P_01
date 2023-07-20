using UnityEngine;

[RequireComponent(typeof(Miner))]
public class DrillOreState : State
{
    [SerializeField] private Miner _miner;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ParticleSystem _destroyEffect;

    private float _effectTime = 0.2f;
    private float _elapsedTime = 0f;
    private bool _onCollision = false;

    private void OnEnable()
    {
        _rigidbody.isKinematic = false;
    }

    private void OnDisable()
    {
        _rigidbody.isKinematic = true;
    }

    private void Update()
    {
        _rigidbody.velocity = -transform.forward * _speed;

        _elapsedTime += Time.deltaTime;
        if (_onCollision && _elapsedTime > _effectTime && Scores.Instance.Fuel > 0)
        {
            _destroyEffect.Play();
            _elapsedTime = 0f;
        }

        _miner.RotateDrill(Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<OrePiece>(out OrePiece orePiece))
        {
            _onCollision = true;

            if (Scores.Instance.TryRemoveFuel(_miner.FuelUsage) == true)
            {
                orePiece.ApplyDamage(_miner.Damage);

                SoundManager.Instance.PlayDrillSound();
                //if (_audioSource.isPlaying == false)
                //{
                //    _audioSource.Play();
                //}
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<OrePiece>(out OrePiece orePiece))
        {
            _onCollision = false;
        }
    }
}
