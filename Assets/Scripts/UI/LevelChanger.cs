using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private UnityEvent _completion;

    private int _changingTime = 2;
    private int _sceneAfterChange = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player)) 
        {
            _completion.Invoke();
            player.SaveCharacteristics();

            StartCoroutine(ChangingLevel());
        }
    }

    IEnumerator ChangingLevel()
    {
        _image.gameObject.SetActive(true);
        yield return new WaitForSeconds(_changingTime);
        SceneManager.LoadScene(_sceneAfterChange);
    }
}
