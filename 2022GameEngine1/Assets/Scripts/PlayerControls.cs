using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    private PlayerInput _playerInput;
    public Vector2 Move { get; private set; }
    public bool Jump { get; private set; }

    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnMove(InputValue value)
    {
        Move = value.Get<Vector2>();
    }
    private void OnJump(InputValue value)
    {
        if (value.isPressed)
            _playerMovement.Jump();
    }
}
