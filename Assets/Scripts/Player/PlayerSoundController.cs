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
	[SerializeField] private bool _isGrounded;
	#endregion

	#region Public Methods
	public void Attack()
	{
		_attack.Play();
	}
	public void Jump()
	{
        _jump.Play();
    }
    public void Walk()
	{
        if(_walk.isPlaying)
		{
			return;
		}
		else if (_isWalking && _isGrounded)
		{
			_walk.Play();
		}
    }

	public void IsWalking(bool isMoving)
	{
		_isWalking = isMoving;
	}

	public void IsGrounded(bool isGrounded)
	{
        _isGrounded = isGrounded;
	}
    #endregion
}
