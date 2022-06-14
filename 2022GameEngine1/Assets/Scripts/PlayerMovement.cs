using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private StageSelect _stageInfo = StageSelect.instance;
    private GameManager _gameManager;
    public PlayerState _PlayerState;
    private Rigidbody _rigidbody;
    private PlayerControls _playerControls;
    public Camera _camera;
    public LayerMask interacableLayer;
    public Vector3 moveDir;
    private bool _autoPlay;
    public bool _isGrounded { get; private set; }

    private float _jumpPower = 500;

    private int _stageIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
        _rigidbody = GetComponent<Rigidbody>();
        _playerControls = GetComponent<PlayerControls>();
        _PlayerState = GetComponent<PlayerState>();
        _autoPlay = _stageInfo.autoPlay;

        _stageIndex = _stageInfo.arrayIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_PlayerState._dead)
        {
            if (GameManager.GetInstance().started)
            {
                int nowMeasure = _gameManager.nowMeasure;
                float nowBPM = _stageInfo.Stages[_stageIndex].timings[nowMeasure].bpm;

                transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, 0, 10),
                    10f * (nowBPM / 60f) * Time.deltaTime);
                transform.Rotate(Vector3.right, nowBPM * 2 * Time.deltaTime);
                if (_autoPlay)
                {
                    AutoPlay();
                }
                else
                {
                    Movement();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ground(Clone)")
        {
            _gameManager.PlusNowGround();
        }
    }

    private void FixedUpdate()
    {
        // transform.position += new Vector3(0, 0, 3f * Time.deltaTime);
        //_rigidbody.AddForce(0, 0, 500f * Time.deltaTime);
    }

    void AutoPlay()
    {
        if (CubesforAuto.instance.cubes.Count == 0) return;
        var kind = CubesforAuto.instance.cubes[0];

        switch (kind)
        {
            case (int)Obstacle.ObstacleKind.Cube1:
            transform.position = new Vector3(-4.0f, transform.position.y, transform.position.z);
            break;
            
            case (int)Obstacle.ObstacleKind.Cube2:
            transform.position = new Vector3(-2.0f, transform.position.y, transform.position.z);
            break;
            
            case (int)Obstacle.ObstacleKind.Cube3:
            transform.position = new Vector3(2.0f, transform.position.y, transform.position.z);
            break;
            
            case (int)Obstacle.ObstacleKind.Cube4:
            transform.position = new Vector3(4.0f, transform.position.y, transform.position.z);
            break;
        }
       
    }
    
    void Movement()
    {
        if (_playerControls.Move.magnitude >= 0.1f)
        {
            //float targetAngle = Mathf.Atan2(_playerControls.Move.x, _playerControls.Move.y) * Mathf.Rad2Deg +
            //                     _camera.transform.eulerAngles.y;
            // moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            // moveDir = moveDir;
        }
        
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(-4.0f, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.position = new Vector3(-2.0f, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            transform.position = new Vector3(2.0f, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            transform.position = new Vector3(4.0f, transform.position.y, transform.position.z);
        }
        // moveDir = _playerControls.Move.normalized;
        // _rigidbody.AddForce(moveDir.x * Time.deltaTime * 500, 0, moveDir.y * Time.deltaTime * 500);
        
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            Vector3 jump = new Vector3(0, 1, 0);
            _rigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }
    
    void CheckGround()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down * 0.51f, Color.red);
 
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 0.51f, interacableLayer))
        {
            _isGrounded = true;
            return;
        }
        _isGrounded = false;
    }
}
