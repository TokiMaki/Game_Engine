using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public PlayerState playerstates;
    public GameObject Pplayer;
    public float Score;
    public bool Item_Event;
    public float Item_time; //�������� ����Ǵ� ���ȿ� �������� �پ��� �ӵ�
    public bool started = false;
    public GameObject readyImage;
    private bool _invincible = false;
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
        Invoke("GameStart",5f);
        playerstates = Pplayer.GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerstates.health <= -9990)
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

    private void GameStart()
    {
        readyImage.SetActive(false);
        SoundManager.instance.PlayBGM("game1");
        Pplayer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX|RigidbodyConstraints.FreezePositionY;
        started = true;
    }
}
