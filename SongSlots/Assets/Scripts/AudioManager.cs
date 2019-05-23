using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// TODO: 
    /// - add volume selection functionality for each clip.
    /// - make clips fade in/out
    /// - maybe add 2D audio visualizer for playing song?
    /// </summary>
    [SerializeField]
    private AudioClip clip1, clip2, clip3, clip4, clip5, clip6, clip7, clip8, clip9;

    [SerializeField]
    private AudioSource audioSource1,audioSource2;

    private AudioClip currentPlayingClip;
    private AudioClip clipToPlay;
    private int buttonNumberToPlay;
    private bool audioSource1IsPlaying, audioSource2IsPlaying;
    private AudioSource currentAudioSource;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        audioSource1.PlayOneShot(clip1, 1.0f);
        audioSource1IsPlaying = true;
    }

    public void SetClipToBePlayed(string buttonNumber)
    {
        buttonNumberToPlay = Int32.Parse(buttonNumber);

        if (buttonNumberToPlay == 1)
            clipToPlay = clip1;
        else if (buttonNumberToPlay == 2)
            clipToPlay = clip2;
        else if (buttonNumberToPlay == 3)
            clipToPlay = clip3;
        else if (buttonNumberToPlay == 4)
            clipToPlay = clip4;
        else if (buttonNumberToPlay == 5)
            clipToPlay = clip5;
        else if (buttonNumberToPlay == 6)
            clipToPlay = clip6;
        else if (buttonNumberToPlay == 7)
            clipToPlay = clip7;
        else if (buttonNumberToPlay == 8)
            clipToPlay = clip8;
        else if (buttonNumberToPlay == 9)
                clipToPlay = clip9;

        FadePlayingClip();
    }

    private void FadePlayingClip()
    {
        
    }
}
