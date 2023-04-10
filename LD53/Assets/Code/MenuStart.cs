using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuStart : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    
    public void QuitGame()
    {
        Application.Quit();
    }
}
