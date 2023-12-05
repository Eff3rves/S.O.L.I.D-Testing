using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour,IObserver
{
    private AudioSource audioSource;
    public AudioClip selectedAudioClip;

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // Method to play different audio clips
    private void PlayAudioClip()
    {
        if(selectedAudioClip != null)
        {
            audioSource.clip = selectedAudioClip;

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            // Play the audio clip
            audioSource.Play();
        }


    }

    public void UpdateObserver()
    {
        PlayAudioClip();
    }
}
