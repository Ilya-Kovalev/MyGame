using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;
    [SerializeField] private Vector3 _startPosition;

    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_path.childCount];
        transform.position = _startPosition;

        for(int i = 0; i < _path.childCount; i++) 
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        var direction = (target.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if(transform.position == target.position) 
        {
            ChangeDirection();
            _currentPoint++;

            if(_currentPoint >= _points.Length) 
            {
                _currentPoint = 0;
            }
        }
    }

    public void ChangeDirection()
    {
        Vector3 newScale = transform.localScale;
        newScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        transform.localScale = newScale;
    }
}
