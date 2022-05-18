using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Composites;

public class SoundManager : MonoBehaviour
{
    public AudioSource titleBGM;
    public AudioSource fx;
    public AudioClip btnClick;

    public static SoundManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
    }

    private void Start()
    {
        PlayTitleBGM();
    }

    public void PlayTitleBGM()
    {
        titleBGM.loop = true;
        titleBGM.Play();
    }

    public void PlayBtnClick()
    {
        fx.PlayOneShot(btnClick);
    }
}
