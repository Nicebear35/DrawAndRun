using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Obstacle
{
    [SerializeField] private Quaternion _rotation;
    //[SerializeField] private Transform[] _pointsToMove;
    //[SerializeField] private float _moveStep;

    private Transform _currentTargetPoint;

    private void Start()
    {
        StartCoroutine(Rotate());
        //_currentTargetPoint = _pointsToMove[0];
    }

    private void Update()
    {
        //if (transform.position == _currentTargetPoint.position)
        //{
        //    _currentTargetPoint = _pointsToMove[0] ? _pointsToMove[1] : _pointsToMove[0];
        //}
        //
        //transform.position = Vector3.MoveTowards(transform.position, _currentTargetPoint.position, _moveStep);
        //transform.rotation = transform.rotation * _rotation;
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            transform.rotation = transform.rotation * _rotation;
            yield return null;

        }
    }
}
