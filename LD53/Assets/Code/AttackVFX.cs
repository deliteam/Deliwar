using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVFX : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip attackA;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown("f"))
        {

            audioSource.PlayOneShot(attackA, 0.7F);
        }

    }
}
