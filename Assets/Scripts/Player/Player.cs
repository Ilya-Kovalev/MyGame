using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _amountOfHealth;
    [SerializeField] private TMP_Text _amountOfPoints;
    [SerializeField] private UnityEvent _pick;

    private int _score;
    private int _health;
    private int _tempScore;
    private int _amountOfPointsForReward = 100;
    private int _reward = 1;

    public void Start()
    {
        InstalCharacteristics();
    }

    public void AddPoints(int points) 
    {
        _score += points;
        _tempScore += points;
        _amountOfPoints.text = _score.ToString();

        if(_tempScore >= _amountOfPointsForReward) 
        {
            ChangeHealth(_reward);
            _tempScore -= _amountOfPointsForReward;
        }
    }

    public int GetHealth() 
    {
        return _health;
    }

    public void ChangeHealth(int amountOfChange) 
    {
        _health += amountOfChange;
        _amountOfHealth.text = _health.ToString();
    }

    public void SaveCharacteristics() 
    {
        PlayerCharacteristics.Score = _score;
        PlayerCharacteristics.Health = _health;
    }

    public void InstalCharacteristics() 
    {
        _score = PlayerCharacteristics.Score;
        _health = PlayerCharacteristics.Health;
        _amountOfHealth.text = _health.ToString();
        _amountOfPoints.text = _score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PickinZone>()) 
        {
            Debug.Log(1);
            _pick.Invoke();
        }
    }
}
