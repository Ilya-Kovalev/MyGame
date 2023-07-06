using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;

    void Update()
    {
        if(_player != null) 
        {
            Vector3 temp = transform.position;
            temp.x = _player.position.x;
            temp.y = _player.position.y;
            transform.position = temp;
        }
    }
}
