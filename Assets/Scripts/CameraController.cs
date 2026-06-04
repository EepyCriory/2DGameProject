using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    #region Fields
    [Header("References")]
    [SerializeField] private GameObject _player;
    #endregion

    #region Unity Callbacks
    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + 3f, -10);
    }
    #endregion
}