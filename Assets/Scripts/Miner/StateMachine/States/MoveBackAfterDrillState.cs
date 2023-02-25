using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAfterDrillState : State
{
    [SerializeField] private float _speed = 35f;
    [SerializeField] private float _zOffset = 2f;
    [SerializeField] private MovedBackAfterDrillTransition transition;

    private Vector3 newPosition;

    private void OnEnable()
    {
        newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + _zOffset);
        transition.SetTargetPosition(newPosition);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPosition, _speed * Time.deltaTime);
    }
}
