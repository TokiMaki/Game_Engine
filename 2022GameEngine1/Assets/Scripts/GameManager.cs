using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private StageSelect _stageInfo = StageSelect.instance;
    public PlayerState playerstates;
    public GameObject Pplayer;
    public float Score;
    public bool Item_Event;
    public float Item_time; //아이템이 실행되는 동안에 게이지가 줄어드는 속도
    public bool started = false;
    public int nowMeasure;
    public GameObject readyImage;
    private bool _invincible = false;
    private int _nowGround = -1;
    public static GameManager GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<GameManager>();
            if(instance == null)
            {
                GameObject container = new GameObject("GameManager");
                instance = container.AddComponent<GameManager>();
            }
        }
        return instance;
        
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Item_time = 0.1f;
        nowMeasure = 0;
        Invoke("GameStart",5f);
        playerstates = Pplayer.GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerstates.health <= 0)
        {
            playerstates.Die();
        }
    }

    public void TurnOnInvincible()
    {
        _invincible = true;
        Invoke("TurnOffInvincible", 3);
    }

    private void TurnOffInvincible()
    {
        _invincible = false;
    }

    public void PlusNowGround()
    {
        _nowGround++;
        nowMeasure = _nowGround / 4;
    }

    private void GameStart()
    {
        readyImage.SetActive(false);
        SoundManager.instance.PlayBGM(_stageInfo.Stages[_stageInfo.arrayIndex].soundName);
        Pplayer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX|RigidbodyConstraints.FreezePositionY;
        started = true;
    }
}
