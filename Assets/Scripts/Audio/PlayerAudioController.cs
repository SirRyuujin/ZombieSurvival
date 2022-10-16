using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Account for different weapons => refactor
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
        //if (!FireSource.isPlaying)
        //{
        //    FireSource.clip = Fire[Random.Range(0, Fire.Length)];
        //    FireSource.Play();
        //}
        FireSource.Play();
    }
    
    public void PlayReloadClip()
    {
        StartCoroutine(PlayReloadSequenceCoroutine());
    }

    private IEnumerator PlayReloadSequenceCoroutine()
    {
        yield return StartCoroutine(PlayReloadClipsCoroutine(0));
        yield return StartCoroutine(PlayReloadClipsCoroutine(1));
        yield return StartCoroutine(PlayReloadClipsCoroutine(2));
    }

    private IEnumerator PlayReloadClipsCoroutine(int clipID)
    {
        ReloadSource.clip = Reload[clipID];
        ReloadSource.Play();
        while (ReloadSource.isPlaying)
            yield return null;
    }

    public void PlayGetHitClip()
    {
        GruntSource.clip = Grunts[Random.Range(0, Grunts.Length)];
        GruntSource.Play();
    }
}