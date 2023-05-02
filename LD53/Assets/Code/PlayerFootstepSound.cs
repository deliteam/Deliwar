using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepSound : MonoBehaviour
{
    List<UnityEngine.KeyCode> keys = new List<UnityEngine.KeyCode>();

    private AudioSource audioSource;
    public AudioClip steps;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        keys.Add(KeyCode.W);
        keys.Add(KeyCode.S);
        keys.Add(KeyCode.A);
        keys.Add(KeyCode.D);
        keys.Add(KeyCode.UpArrow);
        keys.Add(KeyCode.DownArrow);
        keys.Add(KeyCode.LeftArrow);
        keys.Add(KeyCode.RightArrow);
    }

    void Update()
    {
        if (keys.Exists(key => Input.GetKeyDown(key)))
        {
            audioSource.PlayOneShot(steps, 0.7F);
        }


    }
}
