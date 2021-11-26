using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource peasantAudioSource;
    [SerializeField] private AudioClip peasantAudioClip;
    [SerializeField] private AudioSource knightAudioSource;
    [SerializeField] private AudioClip[] knightAudioClips;
    private int knightAudioID = 0;
    [SerializeField] private AudioSource themeAudioSource;
    [SerializeField] private AudioClip themeAudioClip;
    [SerializeField] private AudioSource wheatCollectAudioSource;
    [SerializeField] private AudioClip wheatCollectAudioClip;
    [SerializeField] private AudioSource eatingAudioSource;
    [SerializeField] private AudioClip eatingAudioClip;
    [SerializeField] private AudioSource enemyAudioSource;
    [SerializeField] private AudioClip enemyAudioClip;
    [SerializeField] private AudioSource winAudioSource;
    [SerializeField] private AudioClip winAudioClip;
    [SerializeField] private Image audioSourceButtonImage;
    [SerializeField] private Sprite[] audioSourceButtonSprite;
    [SerializeField] private AudioSource[] buttonsAudioSources;
    private bool _allAudioMute = false;
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
    public void WinAudioPlay()
    {
        winAudioSource.clip = winAudioClip;
        winAudioSource.Play();
    }
    public void AllSoundSourceMute()
    {
        if (!_allAudioMute)
        {
            peasantAudioSource.mute = true;
            knightAudioSource.mute = true;
            themeAudioSource.mute = true;
            wheatCollectAudioSource.mute = true;
            eatingAudioSource.mute = true;
            enemyAudioSource.mute = true;
            winAudioSource.mute = true;
            foreach (AudioSource aS in buttonsAudioSources)
            {
                aS.mute = true;
            }
            audioSourceButtonImage.sprite = audioSourceButtonSprite[1];
        }
        else
        {
            peasantAudioSource.mute = false;
            knightAudioSource.mute = false;
            themeAudioSource.mute = false;
            wheatCollectAudioSource.mute = false;
            eatingAudioSource.mute = false;
            enemyAudioSource.mute = false;
            winAudioSource.mute = false;
            foreach (AudioSource aS in buttonsAudioSources)
            {
                aS.mute = false;
            }
            audioSourceButtonImage.sprite = audioSourceButtonSprite[0];
        }
        _allAudioMute = !_allAudioMute;
    }
}
