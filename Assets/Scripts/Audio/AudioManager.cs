﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    SourceManager source;
    ClipManager clipManager;

    private void Awake()
    {
        Instance = this;
        source = new SourceManager(gameObject);
        clipManager = new ClipManager();
    }

    //开始播放
    public void StartAudio(string clipName)
    {
        AudioSource freeSouce = source.GetFreeAudioSource();
        AudioClip clip = clipManager.FindClip(clipName);
        freeSouce.clip = clip;
        freeSouce.Play();
    }
    //停止播放
    public void StopAudio(string clipName)
    {
        source.StopClip(clipName);
        source.DelSurplusAudioSource();

    }

    private void Update()
    {

    }

}
