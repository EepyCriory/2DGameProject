using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    #region Fields
    [Header("Player Scripts")]
    [SerializeField] private PlayerMovementController _playerMovementController;
    [SerializeField] private PlayerPhysicsCheck _playerPhysicsCheck;
    [SerializeField] private PlayerAnimationController _playerAnimationController;
    [SerializeField] private PlayerInputController _playerInputController;
    [SerializeField] private PlayerSoundController _playerSoundController;

    [Header("Player Related UI Scripts")]
    [SerializeField] private UITextBoosts _textBoosts;
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        _playerMovementController = GetComponent<PlayerMovementController>();
        _playerPhysicsCheck = GetComponent<PlayerPhysicsCheck>();
        _playerAnimationController = GetComponent<PlayerAnimationController>();
        _playerInputController = GetComponent<PlayerInputController>();
        _playerSoundController = GetComponent<PlayerSoundController>();
    }

    void Start()
    {
        #region Event Subscriptions
        _playerPhysicsCheck.FloorEnter += OnFloorEnter;
        _playerPhysicsCheck.FloorExit += OnFloorExit;
        _playerPhysicsCheck.Fall += OnFall;
        _playerPhysicsCheck.NoFall += OnNoFall;

        _playerInputController.MovingLeft += OnLeft;
        _playerInputController.MovingRight += OnRight;
        _playerInputController.StopMovingLeft += OnStopLeft;
        _playerInputController.StopMovingRight += OnStopRight;
        _playerInputController.Sprint += OnSprint;
        _playerInputController.StopSprint += OnStopSprint;
        _playerInputController.Jump += OnJump;
        _playerInputController.StopJump += OnStopJump;
        _playerInputController.Attack += OnAttack;
        #endregion
    }
    #endregion

    #region Public Methods
    #region Boosts
    public void OnSpeedBoost(float boost)
    {
        _playerMovementController.SpeedBoost(boost);
        _textBoosts.SpeedBoost();
    }

    public void OnJumpBoost(float boost)
    {
        _playerMovementController.JumpBoost(boost);
        _textBoosts.JumpBoost();
    }

    public void OnDoubleJumpCharge(int amount)
    {
        _playerMovementController.DoubleJumpCharge(amount);
        _textBoosts.DoubleJumpCharge();
    }
    #endregion
    #endregion

    #region Private Methods
    #region Floor Collision
    private void OnFloorEnter()
    {
        _playerMovementController.FloorContact(true);
        _playerAnimationController.TouchFloor();
        _playerSoundController.IsGrounded(true);
    }
    private void OnFloorExit()
    {
        _playerMovementController.FloorContact(false);
        _playerSoundController.IsGrounded(false);
    }
    #endregion

    #region Jump
    private void OnJump()
    {
        _playerMovementController.OnJump();
        _playerAnimationController.OnJump();
        _playerSoundController.Jump();
    }
    private void OnStopJump()
    {
        _playerMovementController.OnStopJump();
    }
    private void OnFall()
    {
        _playerMovementController.Falling(true);
        _playerAnimationController.OnFall();
    }
    private void OnNoFall()
    {
        _playerMovementController.Falling(false);
    }
    #endregion

    #region Lateral Movement
    private void OnLeft()
    {
        _playerMovementController.OnLeft();
        _playerAnimationController.Walk();
        _playerPhysicsCheck.FaceLeft();
        _playerSoundController.Walk();
        _playerSoundController.IsWalking(true);
    }
    private void OnStopLeft()
    {
        _playerMovementController.OnStopMoving();
        _playerAnimationController.StopMove();
        _playerSoundController.IsWalking(false);
    }
    private void OnRight()
    {
        _playerMovementController.OnRight();
        _playerAnimationController.Walk();
        _playerPhysicsCheck.FaceRight();
        _playerSoundController.Walk();
        _playerSoundController.IsWalking(true);
    }
    private void OnStopRight()
    {
        _playerMovementController.OnStopMoving();
        _playerAnimationController.StopMove();
        _playerSoundController.IsWalking(false);
    }
    private void OnSprint()
    {
        _playerMovementController.OnSprint();
        _playerAnimationController.Run();
        _playerSoundController.Walk();
        _playerSoundController.IsWalking(true);
    }
    private void OnStopSprint()
    {
        _playerMovementController.OnStopSprint();
        _playerAnimationController.Walk();
        _playerSoundController.IsWalking(false);
    }
    #endregion

    #region Attack 
    private void OnAttack()
    {
        _playerAnimationController.Attack();
        _playerSoundController.Attack();
    }
    #endregion
    #endregion
}
