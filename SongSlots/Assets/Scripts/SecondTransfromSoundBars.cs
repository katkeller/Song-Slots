using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTransfromSoundBars : MonoBehaviour
{
    [SerializeField]
    private bool useBuffer;

    [SerializeField]
    private int bandNumber;

    [SerializeField]
    private float startScale = .25f, scaleMultiplier = 10.0f;

    void Update()
    {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (SecondAudioSampleCollector.audioBandBuffer[bandNumber] * scaleMultiplier) + startScale, transform.localScale.z);
        }
        else if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (SecondAudioSampleCollector.audioBand[bandNumber] * scaleMultiplier) + startScale, transform.localScale.z);
        }
    }
}
