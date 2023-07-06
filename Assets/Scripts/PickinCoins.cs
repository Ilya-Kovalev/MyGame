using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickinCoins : MonoBehaviour
{
    private GameObject _coin;
    private int _points;

    private void Start()
    {
        _coin = this.transform.gameObject;
        _points = _coin.GetComponent<Coin>().GetPointsValue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player)) 
        {
            player.AddPoints(_points);
            Destroy(this.transform.gameObject);
        }
    }
}
