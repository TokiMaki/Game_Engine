using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    public bool _dead { get; private set; } // 죽은지 안죽은지 아는 변수
    public Vector3 _respawnVector;          // 리스폰 위치
    public float health { get; private set; } // 플레이어의 체력
    public float max_health { get; private set; } // 플레이어의 최대 체력
    public float Guard{ get; private set; } //목숨 1회 방지권 횟수
    public event Action onDeath;            // 사망시 발동할 이벤트
    void Start()
    {
        max_health = 5;
        health = max_health;
        _dead = false;
    }

    void Update()
    {
        
    }

    public void Die()
    {
        _dead = true;
        if (onDeath != null)
        {
            onDeath();
        }
        Invoke("LoadResultScene", 3);
    }

    public void LoadResultScene()
    {
        SceneManager.LoadScene("Result");
    }

    // 맵 생성할 때 리스폰위치 설정
    public void SetRespawn(Vector3 respawnposition)
    {
        _respawnVector = respawnposition;
    }

    public void getDamage()
    {
        health -= 1;
    }
    public void Heal()
    {
        print("불림");
        if (max_health > health)
        {
            health += 1;
        }
    }
    public float getHealth()
    {
        return health;
    }
    public void addGuard(float amount)
    {
        Guard += amount;
    }

    public float getGuard()
    {
        return Guard;
    }
}
