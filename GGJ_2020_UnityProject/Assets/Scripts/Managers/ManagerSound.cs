using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSound : MonoBehaviour
{
    public static ManagerSound instance;
    public AudioSource source;
    public AudioClip[] clips;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void StopMusic()
    {
        source.Stop();
    }

    public void PlayMusic(int soundIndex)
    {
        source.Stop();
        source.clip = clips[soundIndex];
        source.Play();
    }
}
