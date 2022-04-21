using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public bool _dead { get; private set; } // 죽은지 안죽은지 아는 변수
    public Vector3 _respawnVector;          // 리스폰 위치
    public event Action onDeath;            // 사망시 발동할 이벤트
    void Start()
    {
        _dead = false;
    }

    void Update()
    {
        Respawn();
    }

    public void Die()
    {
        _dead = true;
        if (onDeath != null)
        {
            onDeath();
        }
    }

    // 맵 생성할 때 리스폰위치 설정
    public void SetRespawn(Vector3 respawnposition)
    {
        _respawnVector = respawnposition;
    }

    void Respawn()
    {
        if (_dead)
        {
            transform.position = _respawnVector;
            _dead = false;
        }
    }
}
