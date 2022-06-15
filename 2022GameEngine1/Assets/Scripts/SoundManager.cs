using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Composites;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource fx;
    public AudioClip btnClick;
    public AudioClip clap;

    public static SoundManager instance;

    private string nowBGM;
    
    [Serializable]
    public struct BgmInfo
    {
        public string name;
        public AudioClip audio;
    }

    public BgmInfo[] BGMList;
    
    private void Awake()
    {
        if (SoundManager.instance == null)
        {
            DontDestroyOnLoad(this);
            SoundManager.instance = this;
        }
        else
        {
            if(instance!=this)
                Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        BGM.loop = true;
        PlayBGM("title");
    }

    private void Update()
    {
        if (nowBGM == "gamestart")
        {
            if (!BGM.isPlaying)
            {
                PlayBGM("gameloop");
            }
        }
    }

    public void PlayBGM(string bgmName)
    {
        if (nowBGM == bgmName) return;
        BGM.loop = bgmName is "title" or "result" or "gameloop";
        foreach (var target in BGMList)
        {
            if (target.name != bgmName) continue;
            BGM.clip = target.audio;
            BGM.Play();
            nowBGM = bgmName;
        }
    }

    public void PlayBtnClick()
    {
        fx.PlayOneShot(btnClick);
    }
    
    public void PlayClap()
    {
        fx.PlayOneShot(clap);
    }
}
