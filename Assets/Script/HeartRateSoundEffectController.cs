using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRateSoundEffectController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip heartRate;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void heartRateSoundEffect() {
        audioSource.PlayOneShot(heartRate);
       
    }
}
