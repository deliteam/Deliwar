using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class AttackSFX : MonoBehaviour
    {

        AudioSource audioSource;
        public AudioClip attack;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {

            if ((Input.GetKeyDown("f")) || (Input.GetKeyDown("q")))
            {
                audioSource.PlayOneShot(attack, 0.7F);

            }

        }


    }
}
