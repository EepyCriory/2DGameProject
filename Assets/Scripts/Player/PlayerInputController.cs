using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    #region Properties
    public event Action MovingLeft;
    public event Action StopMovingLeft;
    public event Action MovingRight;
    public event Action StopMovingRight;
    public event Action Sprint;
    public event Action StopSprint;
    public event Action Jump;
    public event Action StopJump;
    public event Action Attack;
    #endregion

    #region Fields
    [Header("Physics Check")]
    [SerializeField] private bool _floorContact;
    #endregion

    #region Unity Callbacks
    void Update()
    {
        #region Lateral Movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MovingLeft?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StopMovingLeft?.Invoke();
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MovingRight?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            StopMovingRight?.Invoke();
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Sprint?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            StopSprint?.Invoke();
        }
        #endregion

        #region Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopJump?.Invoke();
        }
        #endregion

        #region Attack
        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack?.Invoke();
        }
    }
    #endregion
    #endregion
}
