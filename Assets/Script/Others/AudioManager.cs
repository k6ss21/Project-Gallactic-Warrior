using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource audioSource;                  //Reference to Audio Source
    [SerializeField] AudioClip explosionSfx;  //Audio clip


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayExplosionSFX()
    {
        audioSource.PlayOneShot(explosionSfx);  // Play SFX
    }

}
