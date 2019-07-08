using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Clip1;
    public AudioClip Clip2;
    public AudioClip Clip3;
    public AudioClip Clip4;
    public AudioClip Clip5;
    public AudioClip Clip6;

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
        if((state == 1&& !audioSource.isPlaying)||(state==2&&!audioSource.isPlaying)|| (state == 3 && !audioSource.isPlaying) || (state == 4 && !audioSource.isPlaying) || (state == 5 && !audioSource.isPlaying) || (state == 6 && !audioSource.isPlaying))
        {
            RandomPlay();
        }
    }

    void RandomPlay()
    {
        randomNum = Random.Range(1.0f, 7.0f);
        if (randomNum >= 1.0f && randomNum < 2.0f) { state = 1; audioSource.clip = Clip1; audioSource.Play(); }
        else if (randomNum >= 2.0f && randomNum < 3.0f) { state = 2; audioSource.clip = Clip2; audioSource.Play(); }
        else if (randomNum >= 3.0f && randomNum <= 4.0f) { state = 3; audioSource.clip = Clip3; audioSource.Play(); }
        else if (randomNum >= 4.0f && randomNum <= 5.0f) { state = 4; audioSource.clip = Clip4; audioSource.Play(); }
        else if (randomNum >= 5.0f && randomNum <= 6.0f) { state = 5; audioSource.clip = Clip5; audioSource.Play(); }
        else if (randomNum >= 6.0f && randomNum <= 7.0f) { state = 6; audioSource.clip = Clip6; audioSource.Play(); }

    }
}
