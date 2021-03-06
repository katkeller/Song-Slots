﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSoundBars : MonoBehaviour
{
    [SerializeField]
    private bool useBuffer;

    [SerializeField]
    private int bandNumber;

    [SerializeField]
    private float startScale = .25f, scaleMultiplier = 10.0f;

    //[SerializeField]
    //private GameObject audioSampleCollectorObject;

    void Start()
    {
        //audioSampleCollector = GameObject.FindGameObjectWithTag("SoundBars1").GetComponent<AudioSampleCollector>();
    }

    void Update()
    {
        //if (useBuffer)
        //{
        //    transform.localScale += new Vector3(transform.localScale.x, (AudioSampleCollector.audioBandBuffer[bandNumber] * scaleMultiplier) + startScale, transform.localScale.z);
        //}
        //else if (!useBuffer)
        //{
        //    transform.localScale = new Vector3(transform.localScale.x, (AudioSampleCollector.audioBand[bandNumber] * scaleMultiplier) + startScale, transform.localScale.z);
        //}

        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioSampleCollector.audioBandBuffer[bandNumber] * scaleMultiplier) + startScale, transform.localScale.z);
        }
        else if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioSampleCollector.audioBand[bandNumber] * scaleMultiplier) + startScale, transform.localScale.z);
        }
    }
}
