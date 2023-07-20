using UnityEngine;

public class MoveToOreState : State
{
    [SerializeField] private float _speed = 35f;
    [SerializeField] private Miner _miner;

    private void Update()
    {
        if (Target == null)
            return;

        Vector3 newPosition = new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z + 2f);
        transform.position = Vector3.MoveTowards(transform.position, newPosition, _speed * Time.deltaTime);
        _miner.RotateDrill(Time.deltaTime);
    }
}
