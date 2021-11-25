using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]private AudioSource peasantAudioSource;
    [SerializeField]private AudioClip peasantAudioClip;
    [SerializeField]private AudioSource knightAudioSource;
    [SerializeField]private AudioClip[] knightAudioClips;
    private int knightAudioID = 0;
    [SerializeField]private AudioSource themeAudioSource;
    [SerializeField]private AudioClip themeAudioClip;
    [SerializeField]private AudioSource wheatCollectAudioSource;
    [SerializeField]private AudioClip wheatCollectAudioClip;
    [SerializeField]private AudioSource eatingAudioSource;
    [SerializeField]private AudioClip eatingAudioClip;
    [SerializeField]private AudioSource enemyAudioSource;
    [SerializeField]private AudioClip enemyAudioClip;
    
    public void PeasantAudioPlay()
    {
        peasantAudioSource.clip = peasantAudioClip;
        peasantAudioSource.Play();
    }
    public void KnightAudioPlay()
    {
        knightAudioSource.clip = knightAudioClips[knightAudioID];
        knightAudioSource.Play();
        knightAudioID++;
        if (knightAudioID == knightAudioClips.Length)
            knightAudioID = 0;
    }
    public void WheatCollectAudioPlay()
    {
        wheatCollectAudioSource.clip = wheatCollectAudioClip;
        wheatCollectAudioSource.Play();
    }
    public void EatingAudioPlay()
    {
        eatingAudioSource.clip = eatingAudioClip;
        eatingAudioSource.Play();
    }
    public void EnemyAudioPlay()
    {
        enemyAudioSource.clip = enemyAudioClip;
        enemyAudioSource.Play();
    }
}
