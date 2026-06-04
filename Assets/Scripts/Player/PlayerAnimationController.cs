using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimationController : MonoBehaviour
{
	#region Fields
    [Header("References")]
    [SerializeField] private Animator _playerAnimatior;
    #endregion

    #region Unity Callbacks
    void Awake()
    {
        _playerAnimatior = GetComponent<Animator>();
    }
    #endregion

    #region Public Methods
    #region Lateral Movement
    public void Walk()
    {
        _playerAnimatior.SetBool("Walk", true);
        _playerAnimatior.SetFloat("MoveSpeed", 1f);
    }
    public void Run()
    {
        _playerAnimatior.SetFloat("MoveSpeed", 1.4f);
    }
    public void StopMove()
    {
        _playerAnimatior.SetBool("Walk", false);
        _playerAnimatior.SetFloat("MoveSpeed", 0f);
    }
    #endregion

    #region Jump
    public void OnJump()
    {
        _playerAnimatior.SetBool("Jump", true);
        _playerAnimatior.SetBool("Slowed", false);
    }
    public void OnFall()
    {
        _playerAnimatior.SetBool("Jump", false);
        _playerAnimatior.SetBool("Fall", true);
    }

    public void TouchFloor()
    {
        _playerAnimatior.SetBool("Fall", false);
    }
    #endregion

    #region Attack
    public void Attack()
    {
        _playerAnimatior.SetTrigger("NormalAttack");
    }
    #endregion
    #endregion
}
