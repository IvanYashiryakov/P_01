using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraBorder : MonoBehaviour
{
    [SerializeField] private float _startZPosition = -2.5f;
    [SerializeField] private float _zDelta = 4f;
    [SerializeField] private float _moveTime = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Miner miner) == true)
        {
            //StopAllCoroutines();
            //StartCoroutine(Move(_startZPosition - _zDelta));
            MoveZ(transform.position.z - _zDelta);
        }
    }

    public void ResetPosition()
    {
        MoveZ(_startZPosition);
        //StopAllCoroutines();
        //StartCoroutine(Move(_startZPosition));
    }

    private void MoveZ(float endZPosition)
    {
        transform.DOMoveZ(endZPosition, _moveTime);
    }

    private IEnumerator Move(float endZPosition)
    {
        float timer = Time.deltaTime;
        float originZPosition = transform.position.z;

        while (transform.position.z != endZPosition)
        {
            float newZPosition = Mathf.Lerp(originZPosition, endZPosition, timer);
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, newZPosition);
            transform.position = newPosition;

            timer += Time.deltaTime;
            yield return null;
        }
    }
}
