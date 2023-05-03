using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] GameObject controlsPanel;

    void Start()
    {
        controlsPanel.SetActive(false);
    }

    public void OpenPanel()
    {
        if (controlsPanel.activeSelf == false)
        {
            controlsPanel.SetActive(true);
        }
        else if (controlsPanel.activeSelf == true)
        {
            controlsPanel.SetActive(false);
        }
    }
}
