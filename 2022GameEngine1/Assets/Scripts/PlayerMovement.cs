using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private PlayerControls _playerControls;
    public Camera _camera;
    public LayerMask interacableLayer;
    public Vector3 moveDir;
    public bool _isGrounded { get; private set; }

    private float _jumpPower = 500;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerControls = GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        // _rigidbody.AddForce(Input.GetAxis("Horizontal") * Time.deltaTime * 500, 0, 0);
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     // _rigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
        // }
    }

    private void FixedUpdate()
    {
        Movement();
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
        moveDir = _playerControls.Move.normalized;
        _rigidbody.AddForce(moveDir.x * Time.deltaTime * 500, 0, moveDir.y * Time.deltaTime * 500);
        
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
