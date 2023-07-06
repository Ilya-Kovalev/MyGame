using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _pointsForPickin = 5;
    private int _enemyLayer = 6;
    private int _coinLayer = 10;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(_coinLayer, _enemyLayer);
    }

    public int GetPointsValue()
    {
        return _pointsForPickin;
    }
}
