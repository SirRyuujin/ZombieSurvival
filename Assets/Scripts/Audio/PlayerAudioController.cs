using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public AudioClip[] Footsteps;
    public AudioClip[] Fire;
    public AudioClip[] Reload;
    public AudioClip[] Grunts;

    public AudioSource FootstepsSource;
    public AudioSource FireSource;
    public AudioSource ReloadSource;
    public AudioSource GruntSource;

    public void PlayFootstepsClip()
    {
        if (!FootstepsSource.isPlaying)
        {
            FootstepsSource.clip = Footsteps[Random.Range(0, Footsteps.Length)];
            FootstepsSource.Play();
        }
    }

    public void PlayFiringClip()
    {

    }
    
    public void PlayReloadClip()
    {

    }

    public void PlayGetHitEvent()
    {
        if (!GruntSource.isPlaying)
        {
            GruntSource.clip = Grunts[Random.Range(0, Grunts.Length)];
            GruntSource.Play();
        }
    }
}