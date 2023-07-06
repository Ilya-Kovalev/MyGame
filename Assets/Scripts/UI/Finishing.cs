using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Finishing : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private UnityEvent _completion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _completion.Invoke();
            _image.gameObject.SetActive(true);
        }
    }
}
