using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalZombieAudioController : MonoBehaviour
{
    public AudioClip[] Attacks;

    public AudioSource AttackSource;

    public void PlayAttackClip()
    {
        if (!AttackSource.isPlaying)
        {
            AttackSource.clip = Attacks[Random.Range(0, Attacks.Length)];
            AttackSource.Play();
        }
    }
}