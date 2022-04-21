using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    private float _RotateSpeed = 180;       // 1초에 한바퀴
    public bool _Rotatedir;                 // 회전방향, 0이면 시계 1이면 반시계방향으로 돔
    public Rigidbody _Rigidbody;
    
    void Start()
    {
        // _Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Wingrotate(_Rotatedir);
    }

    void Wingrotate(bool rotatedir)
    {
        if (rotatedir == false)
        {
            transform.rotation *= Quaternion.Euler(0,  _RotateSpeed * Time.deltaTime, 0);
            // _Rigidbody.rotation *= Quaternion.Euler(0,  _RotateSpeed * Time.deltaTime, 0);
        }
        else if (rotatedir == true)
        {
            transform.rotation *= Quaternion.Euler(0,  -_RotateSpeed * Time.deltaTime, 0);
            // _Rigidbody.rotation *= Quaternion.Euler(0,  -_RotateSpeed * Time.deltaTime, 0);
        }
    }
}
