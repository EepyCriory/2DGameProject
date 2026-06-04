using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovementController : MonoBehaviour
{
    #region Properties
    #endregion

    #region Fields
    [Header("References")]
    [SerializeField] private Rigidbody2D _playerRigidbody;

    [Header("Movement Settings")]
    //Base values
    [SerializeField] private float _baseMoveSpeed;
    [SerializeField] private float _baseSprintSpeed;
    [SerializeField] private float _baseJumpForce;
    [SerializeField] private float _baseDoubleJumpForce;

    //Multipliers
    [SerializeField] private float _moveSpeedMultiplier;
    [SerializeField] private float _sprintSpeedMultiplier;
    [SerializeField] private float _jumpForceMultiplier;

    //Final values
    [SerializeField] private float _finalMoveSpeed;
    [SerializeField] private float _finalSprintSpeed;
    [SerializeField] private float _totalMoveSpeed;
    [SerializeField] private float _totalJumpForce;
    [SerializeField] private float _totalDoubleJumpForce;

    //Boolean Checks
    [SerializeField] private bool _isSprinting;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isFalling;
    [SerializeField] private bool _canDoubleJump;

    //Counters
    [SerializeField] private int _doubleJumps;
    #endregion

    #region Unity Callbacks
    void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _moveSpeedMultiplier = 1;
        _sprintSpeedMultiplier = 1;
        _jumpForceMultiplier = 1;
        _doubleJumps = 0;
        _canDoubleJump = true;
    }
    #endregion

    #region Public Methods
    #region Jump
    public void OnJump()
    {
        if (!_isGrounded && _canDoubleJump && _doubleJumps != 0)
        {
            _canDoubleJump = false;
            DoubleJump();
        }
        else if (_isGrounded)
        {
            Jump();
        }
    }

    public void OnStopJump()
    {
        if (!_isFalling)
        {
            _playerRigidbody.linearVelocity = new Vector2(_playerRigidbody.linearVelocity.x, _playerRigidbody.linearVelocity.y * 0.5f);
        }
    }
    #endregion

    #region Lateral Movement
    public void OnLeft()
    {
        LateralMovement(-1);
    }
    public void OnRight()
    {
        LateralMovement(1);
    }

    public void OnStopMoving()
    {
        LateralMovement(0);
    }
    public void OnSprint()
    {
        _isSprinting = true;
    }
    public void OnStopSprint()
    {
        _isSprinting = false;
    }
    #endregion

    #region Ground Check
    public void FloorContact(bool isGrounded)
    {
        _isGrounded = isGrounded;
        if (_isGrounded)
        {
            _canDoubleJump = false;
        }
        else
        {
            _canDoubleJump = true;
        }
    }
    #endregion

    #region Falling Check
    public void Falling(bool isFalling)
    {
        _isFalling = isFalling;
    }
    #endregion

    #region Boosts
    public void SpeedBoost(float boost)
    {
        float convertBoost = boost / 100;
        _moveSpeedMultiplier += convertBoost;
        _sprintSpeedMultiplier += convertBoost;
    }

    public void JumpBoost(float boost)
    {
        float convertBoost = boost / 100;
        _jumpForceMultiplier += convertBoost;
    }

    public void DoubleJumpCharge(int amount)
    {
        _doubleJumps += amount;
    }
    #endregion
    #endregion

    #region Private Methods
    #region Jump
    private void Jump()
    {
        JumpForceCalc();
        _playerRigidbody.linearVelocity = new Vector2(_playerRigidbody.linearVelocity.x, _totalJumpForce);
    }
    private void DoubleJump()
    {
        _playerRigidbody.linearVelocity = new Vector2(_playerRigidbody.linearVelocity.x, _totalDoubleJumpForce);
        _doubleJumps--;
    }

    private void JumpForceCalc()
    {
        _totalJumpForce = _baseJumpForce * _jumpForceMultiplier;
        _totalDoubleJumpForce = _baseDoubleJumpForce * _jumpForceMultiplier;
    }
    #endregion

    #region Lateral Movement

    private void LateralMovement(int movementDirection) //Movement Direction: -1 for left, 1 for right, 0 for stop/idle
    {
        if (_isSprinting)
        {
            MoveSpeedCalc(true);
            _playerRigidbody.linearVelocity = new Vector2(movementDirection * _totalMoveSpeed, _playerRigidbody.linearVelocity.y);
        }
        else
        {
            MoveSpeedCalc(false);
            _playerRigidbody.linearVelocity = new Vector2(movementDirection * _totalMoveSpeed, _playerRigidbody.linearVelocity.y);
        }
    }

    private void MoveSpeedCalc(bool isSprinting) //Speed Calculation
    {
        _finalMoveSpeed = _baseMoveSpeed * _moveSpeedMultiplier;
        _finalSprintSpeed = _baseSprintSpeed * _sprintSpeedMultiplier;

        if (isSprinting)
        {
            _totalMoveSpeed = _finalSprintSpeed;
        }
        else
        {
            _totalMoveSpeed = _finalMoveSpeed;
        }
    }
    #endregion
    #endregion
}