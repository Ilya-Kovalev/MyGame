using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDying : MonoBehaviour
{
    private const string _isDying = "IsDying";

    [SerializeField] private UnityEvent _dead;

    private Animator _animator;
    private GameObject _enemy;
    private float _tossForse = 25;
    private float _dyingTime = 0.5f;
    private int _points;

    private void Start()
    {
        _enemy = this.transform.parent.gameObject;
        _points = _enemy.GetComponent<Enemy>().GetPointsValue();
        _animator = _enemy.GetComponent<Animator>();
        _animator.SetBool(_isDying, false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player)) 
        {
            _dead.Invoke();
            player.GetComponent<Rigidbody2D>().AddForce(transform.up * _tossForse, ForceMode2D.Impulse);
            player.AddPoints(_points);

            StartCoroutine(EnemyDestroying());
        }
    }

    IEnumerator EnemyDestroying()
    {
        _animator.SetBool(_isDying, true);
        _enemy.GetComponent<EnemyMovement>().enabled = false;
        yield return new WaitForSeconds(_dyingTime);
        Destroy(this.transform.parent.gameObject);
    }
}
