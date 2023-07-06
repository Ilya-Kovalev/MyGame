using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private const string _isRun = "IsRun";
    private const string _isJump = "IsJump";

    [SerializeField] private UnityEvent _jumped;
    [SerializeField] private float _speed;
    [SerializeField] private float _thrust;

    private Animator _animator;
    private bool _isOnSurfase = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.D)) 
        {
            int MovementDirection = 1;
            DescribeMovement(MovementDirection);
        }

        else if(Input.GetKey(KeyCode.A)) 
        {
            int MovementDirection = -1;
            DescribeMovement(MovementDirection);
        }

        else 
        {
            _animator.SetBool(_isRun, false);
        }

        if(Input.GetKeyDown(KeyCode.W)) 
        {
            if(_isOnSurfase == true) 
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * _thrust, ForceMode2D.Impulse);
                _jumped.Invoke();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Ground ground)) 
        {
            _animator.SetBool(_isJump, false);
            _isOnSurfase = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Ground ground)) 
        {
            _animator.SetBool(_isJump, true);
            _isOnSurfase = false;
        }
    }

    private void DescribeMovement(int movementDirection)
    {       
        _animator.SetBool(_isRun, true); 
        transform.Translate(_speed * Time.deltaTime * movementDirection, 0, 0);
        Vector3 newScale = new Vector3(movementDirection, transform.localScale.y, transform.localScale.z);
        transform.localScale = newScale;
    }
}

