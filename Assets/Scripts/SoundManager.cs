using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public bool isAudioMute = false;
    public float gameVolume = 1f;

    public AudioSource SFX;
    public AudioSource MusicPlay;
    public AudioSource playerMove;


    public SoundType[] Sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetGameVolume(0.5f);
        PlayMusic(global::Sounds.Music);
    }

    public void SetGameVolume(float _gameVolume)
    {
        gameVolume = _gameVolume;
        SFX.volume = gameVolume;
        MusicPlay.volume = gameVolume;
        playerMove.volume = gameVolume;
    }

    public void PlayMusic(Sounds sound)
    {
        if (isAudioMute) return;

        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            MusicPlay.clip = clip;
            MusicPlay.Play();
        }
        else
        {
            Debug.LogError("Clip not found on soundType: " + sound);
        }
    }
    public void PlayerMove(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            playerMove.clip = clip;
            playerMove.Play();
        }
        else
        {
            Debug.LogError("Clip not found on soundType: " + sound);
        }
    }

    public void PlaySound(Sounds sound)
    {
        if (isAudioMute) return;

        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SFX.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not found on soundType: " + sound);
        }
    }


    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundType == sound);

        if (item != null) return item.audioClip;

        return null;
    }
}



[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip audioClip;
}

public enum Sounds
{
    ButtonClick,
    LevelSelection,
    Music,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
}