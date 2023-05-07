using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class PlayerFootstepSound : MonoBehaviour
    {

        AudioSource audioSource;


        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }

        void Update()
        {
            audioSource.Pause();

            if ((Input.GetAxisRaw("Horizontal") != 0))
            {
                audioSource.UnPause();

            }



        }
    }
}