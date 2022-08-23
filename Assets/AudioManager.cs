using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{

    private AudioSource audioSource;

    public AudioClip dateMusic;
    public AudioClip tenseMusic;
    public AudioClip chaseMusic;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void swapToGame()
    {
        audioSource.clip = tenseMusic;
        audioSource.Play();
    }
    public void swapToRUN()
    {
        audioSource.clip = chaseMusic;
        audioSource.Play();
    }
}
