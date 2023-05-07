using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ActionZone : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!audioSource.isPlaying)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //audioSource.Stop();
    }



}
