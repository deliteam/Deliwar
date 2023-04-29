using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuStart : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("Main_Scene");
    }

       public void QuitGame()
    {
        Application.Quit();
    }

        public void Credits()
    {
        SceneManager.LoadScene("Credits_Scene");
    }
}
