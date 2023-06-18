using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusic;

    private AudioSource audioSourse;
    
    private void Awake()
    {
        audioSourse = GetComponent<AudioSource>();
        audioSourse.clip = backgroundMusic;
        audioSourse.Play();
    }
}
