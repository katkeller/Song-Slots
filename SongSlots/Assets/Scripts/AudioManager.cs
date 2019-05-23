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
    //[SerializeField]
    //private AudioClip clip1, clip2, clip3, clip4, clip5, clip6, clip7, clip8, clip9;
    [SerializeField]
    private AudioClip[] audioClip = new AudioClip[9];

    [SerializeField]
    private AudioSource audioSource1,audioSource2;

    private AudioClip currentPlayingClip;
    private AudioClip clipToPlay;
    private int buttonNumberToPlay;
    private bool audioSource1IsPlaying, audioSource2IsPlaying;
    private AudioSource currentAudioSource;
    private AudioSource audioSourceToPlay;

    void Start()
    {

        //audioSource = GetComponent<AudioSource>();
        audioSource1.PlayOneShot(audioClip[0], 1.0f);
        audioSource1IsPlaying = true;
        currentAudioSource = audioSource1;
        audioSourceToPlay = audioSource2;
        currentPlayingClip = audioClip[0];
    }

    private void Update()
    {
        //find out if there's a cleaner way to do this?
        if (Input.GetButtonDown("1"))
        {
            clipToPlay = audioClip[0];
            FadePlayingClip();
        }
        else if (Input.GetButtonDown("2"))
        {
            clipToPlay = audioClip[1];
            FadePlayingClip();
        }
        else if (Input.GetButtonDown("3"))
        {
            clipToPlay = audioClip[2];
            FadePlayingClip();
        }
        else if (Input.GetButtonDown("4"))
        {
            clipToPlay = audioClip[3];
            FadePlayingClip();
        }
        else if (Input.GetButtonDown("5"))
        {
            clipToPlay = audioClip[4];
            FadePlayingClip();
        }
        else if (Input.GetButtonDown("6"))
        {
            clipToPlay = audioClip[5];
            FadePlayingClip();
        }
        else if (Input.GetButtonDown("7"))
        {
            clipToPlay = audioClip[6];
            FadePlayingClip();
        }
        else if (Input.GetButtonDown("8"))
        {
            clipToPlay = audioClip[7];
            FadePlayingClip();
        }
        else if (Input.GetButtonDown("9"))
        {
            clipToPlay = audioClip[8];
            FadePlayingClip();
        }
    }

    public void SetClipToBePlayedByButton(string buttonNumber)
    {
        buttonNumberToPlay = Int32.Parse(buttonNumber);

        clipToPlay = audioClip[buttonNumberToPlay];

        //if (buttonNumberToPlay == 1)
        //    clipToPlay = clip1;
        //else if (buttonNumberToPlay == 2)
        //    clipToPlay = clip2;
        //else if (buttonNumberToPlay == 3)
        //    clipToPlay = clip3;
        //else if (buttonNumberToPlay == 4)
        //    clipToPlay = clip4;
        //else if (buttonNumberToPlay == 5)
        //    clipToPlay = clip5;
        //else if (buttonNumberToPlay == 6)
        //    clipToPlay = clip6;
        //else if (buttonNumberToPlay == 7)
        //    clipToPlay = clip7;
        //else if (buttonNumberToPlay == 8)
        //    clipToPlay = clip8;
        //else if (buttonNumberToPlay == 9)
                //clipToPlay = clip9;

        FadePlayingClip();
    }

    public void SetClipToPlayByKey()
    {

    }

    /// <summary>
    /// TODO:
    /// - Set clip for second audiosource
    /// - fade volume up over time
    /// - fade volume of first clip down over time
    /// - set new audiosource as the one that's playing
    /// </summary>
    private void FadePlayingClip()
    {
        if (audioSource1IsPlaying)
        {
            audioSource2.PlayOneShot(clipToPlay, 1.0f);
            audioSource1.Stop();
            audioSource1IsPlaying = false;
            audioSource2IsPlaying = true;
        }
        else if (audioSource2IsPlaying)
        {
            audioSource1.PlayOneShot(clipToPlay, 1.0f);
            audioSource2.Stop();
            audioSource2IsPlaying = false;
            audioSource1IsPlaying = true;
        }
        //audioSourceToPlay.PlayOneShot(clipToPlay, 1.0f);

        //currentAudioSource = audioSourceToPlay;
    }
}
