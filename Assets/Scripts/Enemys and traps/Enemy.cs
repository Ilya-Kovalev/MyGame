using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _pointsForDestroy = 20;

    public int GetPointsValue()
    {
        return _pointsForDestroy;
    }
}
