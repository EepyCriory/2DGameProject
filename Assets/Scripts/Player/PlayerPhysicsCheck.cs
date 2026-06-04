using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerPhysicsCheck : MonoBehaviour
{
    #region Properties
    public event Action FloorEnter;
    public event Action FloorExit;
    public event Action Fall;
    public event Action NoFall;
    #endregion

    #region Fields
    [Header("References")]
    [SerializeField] private Rigidbody2D _rigidbody;

    [Header("Physics Check")]
    [SerializeField] private bool _floorContact;

    [Header("Debug")]
    [SerializeField] private Vector2 _boxCastSize;
    [SerializeField] private float _boxCastDistance;
    [SerializeField] private LayerMask _floorLayerMask;
    #endregion

    #region Unity Callbacks
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        #region Fall
        if (_rigidbody.linearVelocity.y < -0f && _floorContact == false)
        {
            Fall?.Invoke();
        }

        if (_rigidbody.linearVelocity.y >= 0f && _floorContact == false)
        {
            NoFall?.Invoke();
        }
        #endregion

        IsTouchingFloor();
    }
    #endregion

    #region Public Methods
    #region Floor Collision
    public bool IsTouchingFloor()
    {
        if (Physics2D.BoxCast(transform.position, _boxCastSize, 0f, Vector2.down, _boxCastDistance, _floorLayerMask))
        {
            _floorContact = true;
            FloorEnter?.Invoke();
            return true;
        }
        else
        {
            _floorContact = false;
            FloorExit?.Invoke();
            return false;
        }
    }
    #endregion

    #region Facing Direction
    public void FaceRight()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void FaceLeft()
    {
        transform.localScale = new Vector3(-1f, 1f, 1f);
    }
    #endregion
    #endregion

    #region Private Methods
    private void OnDrawGizmosSelected() //Visualize Ground Check in Editor
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.down * _boxCastDistance, _boxCastSize);
    }
    #endregion
}