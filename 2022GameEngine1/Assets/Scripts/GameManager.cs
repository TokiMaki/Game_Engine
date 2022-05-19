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
    public float Item_time; //이벤트가 진행되는 동안 줄어드는 게이지의 속도
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
        playerstates = Pplayer.GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
