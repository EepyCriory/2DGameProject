using System.Collections;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
	#region Fields
	[Header("Sounds")]
	[SerializeField] private AudioSource _attack;
	[SerializeField] private AudioSource _jump;
	[SerializeField] private AudioSource _walk;

	[Header("Conditions")]
	[SerializeField] private bool _isWalking;
	[SerializeField] private bool _isSprinting;
	[SerializeField] private bool _isGrounded;
	[SerializeField] private bool _coroutineOn;
	#endregion

	#region Public Methods
	public void Attack()
	{
		_attack.Play();
	}
	public void Jump()
	{
		if(_isGrounded)
		{ 
			_jump.Play();
        }
    }
	public void DoubleJump()
	{
		_jump.Play();
    }
    public void Walk()
	{
        if(_walk.isPlaying)
		{
			return;
		}
		else if (_isWalking && _isGrounded && !_coroutineOn)
		{
			StartCoroutine(WalkSound(0.5f));
        }
		else if (_isSprinting && _isGrounded && !_coroutineOn)
		{
			StartCoroutine(WalkSound(0.3f));
		}
    }

    #region Booleans
    public void IsWalking(bool isMoving)
	{
		_isWalking = isMoving;
	}

	public void IsSprinting(bool isRunning)
	{
        _isSprinting = isRunning;
	}

	public void IsGrounded(bool isGrounded)
	{
        _isGrounded = isGrounded;
	}
    #endregion
    #endregion

    #region Private Methods
	private IEnumerator WalkSound(float time)
	{
		_coroutineOn = true;
        _walk.Play();
        yield return new WaitForSeconds(time);
		_coroutineOn = false;
	}
    #endregion
}
