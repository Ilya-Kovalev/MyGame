using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private int _firstLevelScene = 1;

    public void OpenReference(GameObject panel) 
    {
        panel.SetActive(true);
    }

    public void GoBackToMenu(GameObject panel) 
    {
        panel.SetActive(false);
    }

    public void RunGame() 
    {
        SceneManager.LoadScene(_firstLevelScene);
    }
}
