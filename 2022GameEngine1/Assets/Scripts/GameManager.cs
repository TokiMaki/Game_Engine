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
    public int Score;
    public bool Item_Event;
    public float Item_time; //�������� ����Ǵ� ���ȿ� �������� �پ��� �ӵ�
    public bool started = false;
    public int nowMeasure;
    public GameObject readyImage;
    //public bool autoPlay;
    private bool _invincible = false;
    private int _nowGround = -1;
    private int _nowCube = 0;
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
        DontDestroyOnLoad(this);
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
        Pplayer = GameObject.FindWithTag("Player");
        Invoke("GameStart",5f);
        if (Pplayer != null)
        {
            playerstates = Pplayer.GetComponent<PlayerState>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        print(nowMeasure);
        if (playerstates != null)
        {
            if (playerstates.health <= 0 || nowMeasure > _stageInfo.Stages[_stageInfo.arrayIndex].timings.Length-2)
            {
                playerstates.Die();
            }
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
    
    public void PlusNowCube()
    {
        _nowCube++;
    }

    public int GetGroundIndex()
    {
        return _nowGround;
    }
    
    public int GetNowCubeIndex()
    {
        return _nowCube;
    }

    private void GameStart()
    {
        readyImage.SetActive(false);
        SoundManager.instance.PlayBGM(_stageInfo.Stages[_stageInfo.arrayIndex].soundName);
        Pplayer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX|RigidbodyConstraints.FreezePositionY;
        Score = 0;
        started = true;
    }
}
