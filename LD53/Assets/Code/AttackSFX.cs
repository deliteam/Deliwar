using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSFX : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip attackA;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

     void Update()
    {

       if ((Input.GetKeyDown("f")) || (Input.GetKeyDown("q")))
        {
            audioSource.PlayOneShot(attackA, 0.7F);
			
        }

    }


}
