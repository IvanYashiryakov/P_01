using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillOreState : State
{
    [SerializeField] private float _speed = 5f;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Drill());
    }

    private void Update()
    {
        
    }

    private IEnumerator Drill()
    {
        Vector3 newPosition = new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z);
        Vector3 endPosition = new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z + 2f);

        while (transform.position.z != Target.transform.position.z)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, _speed * Time.deltaTime);
            yield return null;
        }

        while (transform.position.z != endPosition.z)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, _speed * 2 * Time.deltaTime);
            yield return null;
        }

        Destroy(Target.gameObject);
    }
}
