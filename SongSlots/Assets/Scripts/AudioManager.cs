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

    [SerializeField]
    private float timeToFade = 2.0f;

    private AudioClip currentPlayingClip;
    private AudioClip clipToPlay;
    private int buttonNumberToPlay;
    private bool audioSource1IsPlaying, audioSource2IsPlaying;
    private AudioSource currentAudioSource;
    private AudioSource audioSourceToPlay;

    //public static Event Action ChangeAudioSourceToSample;

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
            FadeBetweenClips();
        }
        else if (Input.GetButtonDown("2"))
        {
            clipToPlay = audioClip[1];
            FadeBetweenClips();
        }
        else if (Input.GetButtonDown("3"))
        {
            clipToPlay = audioClip[2];
            FadeBetweenClips();
        }
        else if (Input.GetButtonDown("4"))
        {
            clipToPlay = audioClip[3];
            FadeBetweenClips();
        }
        else if (Input.GetButtonDown("5"))
        {
            clipToPlay = audioClip[4];
            FadeBetweenClips();
        }
        else if (Input.GetButtonDown("6"))
        {
            clipToPlay = audioClip[5];
            FadeBetweenClips();
        }
        else if (Input.GetButtonDown("7"))
        {
            clipToPlay = audioClip[6];
            FadeBetweenClips();
        }
        else if (Input.GetButtonDown("8"))
        {
            clipToPlay = audioClip[7];
            FadeBetweenClips();
        }
        else if (Input.GetButtonDown("9"))
        {
            clipToPlay = audioClip[8];
            FadeBetweenClips();
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

        FadeBetweenClips();
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
    /// - make it so that if the selected clip is already playing, it won't start over
    /// - display name of currently playing song
    /// - set audio visualizer to current audiosource (also add audiovisualizer)
    /// </summary>
    private void FadeBetweenClips()
    {
        if(clipToPlay != currentPlayingClip)
        {
            StartCoroutine(FadeOutAudio());

            //StartCoroutine(FadeInAudio());

            if (currentAudioSource == audioSource1)
            {
                audioSource2.PlayOneShot(clipToPlay, 1.0f);
                //ChangeAudioSourceToSample?.Invoke();
            }
            else if (currentAudioSource == audioSource2)
            {
                audioSource1.PlayOneShot(clipToPlay, 1.0f);
            }

            //if (audioSource1IsPlaying)
            //{
            //    audioSource2.PlayOneShot(clipToPlay, 1.0f);
            //    //audioSource1.Stop();
            //    //audioSource1IsPlaying = false;
            //    audioSource2IsPlaying = true;

            //}
            //else if (audioSource2IsPlaying)
            //{

            //    audioSource1.PlayOneShot(clipToPlay, 1.0f);
            //    //audioSource2.Stop();
            //    //audioSource2IsPlaying = false;
            //    audioSource1IsPlaying = true;
            //}

            //currentPlayingClip = clipToPlay;
        }
        //audioSourceToPlay.PlayOneShot(clipToPlay, 1.0f);

        //currentAudioSource = audioSourceToPlay;
    }

    private IEnumerator FadeOutAudio()
    {
        float startVolume = currentAudioSource.volume;

        while (currentAudioSource.volume > 0.0f)
        {
            currentAudioSource.volume -= startVolume * Time.deltaTime / timeToFade;
            yield return null;
        }

        currentAudioSource.Stop();
        currentAudioSource.volume = startVolume;

        if (currentAudioSource == audioSource1)
        {
            currentAudioSource = audioSource2;
            audioSourceToPlay = audioSource1;
        }
        else if (currentAudioSource == audioSource2)
        {
            currentAudioSource = audioSource1;
            audioSourceToPlay = audioSource2;
        }

        currentPlayingClip = clipToPlay;
    }

    private IEnumerator FadeInAudio()
    {
        audioSourceToPlay.PlayOneShot(clipToPlay, 0.0f);

        while (audioSourceToPlay.volume < 1.0f)
        {
            audioSourceToPlay.volume = Mathf.Lerp(audioSourceToPlay.volume, 1, timeToFade);
            yield return null;
        }
    }
}
