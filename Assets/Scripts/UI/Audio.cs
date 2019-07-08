using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Clip1;
    public AudioClip Clip2;
    public AudioClip Clip3;
    public float musicVolume;
    public float randomNum;
    public int state;
    void Start()
    {
        musicVolume = 0.5f;
        RandomPlay();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVolume;
        if((state == 1&& !audioSource.isPlaying)||(state==2&&!audioSource.isPlaying)|| (state == 2 && !audioSource.isPlaying))
        {
            RandomPlay();
        }
    }

    void RandomPlay()
    {
        randomNum = Random.Range(1.0f, 4.0f);
        if (randomNum >= 1.0f && randomNum < 2.0f) { state = 1; audioSource.clip = Clip1; audioSource.Play(); }
        else if (randomNum >= 2.0f && randomNum < 3.0f) { state = 2; audioSource.clip = Clip2; audioSource.Play(); }
        else if (randomNum >= 3.0f && randomNum <= 4.0f) { state = 3; audioSource.clip = Clip3; audioSource.Play(); }
    }
}
