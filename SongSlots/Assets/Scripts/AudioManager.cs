using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

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

    [SerializeField]
    private Text songNameText, fadingText, fadingCurrentValueText, volumeCurrentValueText;

    [SerializeField]
    private string fadingTextString = "Fading...";

    [SerializeField]
    private Slider fadeTimeSlider, volumeSlider;

    private AudioClip currentPlayingClip;
    private AudioClip clipToPlay;
    private int buttonNumberToPlay;
    private bool audioSource1IsPlaying, audioSource2IsPlaying;
    private AudioSource currentAudioSource;
    private AudioSource audioSourceToPlay;
    private bool isFading = false;

    //public static Event Action ChangeAudioSourceToSample;

    void Start()
    {

        //audioSource = GetComponent<AudioSource>();
        songNameText.text = audioClip[0].name;
        audioSource1.PlayOneShot(audioClip[0], 1.0f);
        audioSource1IsPlaying = true;
        currentAudioSource = audioSource1;
        audioSourceToPlay = audioSource2;
        currentPlayingClip = audioClip[0];
        fadingText.text = string.Empty;
    }

    private void Update()
    {
        if (!isFading)
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
    }

    public void SetClipToBePlayedByButton(string buttonNumber)
    {
        if (!isFading)
        {
            buttonNumberToPlay = Int32.Parse(buttonNumber);
            clipToPlay = audioClip[buttonNumberToPlay];
            FadeBetweenClips();
        }
    }

    public void SetFadeSpeed()
    {
        if (!isFading)
        {
            fadingCurrentValueText.text = fadeTimeSlider.value.ToString();
            timeToFade = fadeTimeSlider.value;
        }
        else if (isFading)
        {
            fadingText.text = "Cannot change fade speed while fading.";
        }
    }

    public void SetVolume()
    {
        if (!isFading)
        {
            volumeCurrentValueText.text = volumeSlider.value.ToString("0.00");
            currentAudioSource.volume = volumeSlider.value;
        }
        else if (isFading)
        {
            fadingText.text = "Cannot change volume while fading.";
        }
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
    /// - fix bug where audio stops if you change between clips too quickly
    /// - add pause toggle
    /// </summary>
    private void FadeBetweenClips()
    {
        if(clipToPlay != currentPlayingClip)
        {
            
            songNameText.text = clipToPlay.name;
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
        isFading = true;
        fadingText.text = fadingTextString;
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
        fadingText.text = string.Empty;
        isFading = false;
    }

    private IEnumerator FadeInAudio()
    {
        isFading = true;
        audioSourceToPlay.PlayOneShot(clipToPlay, 0.0f);

        while (audioSourceToPlay.volume < 1.0f)
        {
            audioSourceToPlay.volume = Mathf.Lerp(audioSourceToPlay.volume, 1, timeToFade);
            yield return null;
        }
        isFading = false;
    }

    //private IEnumerator SetIsFading()
    //{
    //    isFading = true;
    //    yield return new WaitForSeconds(timeToFade);
    //    isFading = false;
    //}
}
