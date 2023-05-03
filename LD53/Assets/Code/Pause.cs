using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject controlsPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !controlsPanel.activeSelf)
        {
            SceneManager.LoadScene("Menu_Start");
        }
    }
}
