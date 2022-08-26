using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Yarn.Unity;

public class VoiceDeliveryShim : MonoBehaviour
{

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip audioClip;

    [SerializeField]
    AudioLineProvider lineProvider;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(lineProvider.LinesAvailable);
        // lineProvider.
    }
}
