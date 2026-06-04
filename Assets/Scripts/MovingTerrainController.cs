using System.Collections;
using UnityEngine;

public class MovingTerrainController : MonoBehaviour
{
    #region Fields
    [SerializeField] private int _speed;

    [SerializeField] private GameObject _a;
    [SerializeField] private GameObject _b;

    [SerializeField] private Vector2 _currentTarget;
    #endregion

    #region Unity Callbacks
    void FixedUpdate()
    {
        var step = _speed * Time.deltaTime;

        if (transform.position ==  _a.transform.position)
        {
            _currentTarget = _b.transform.position;
        }

        if (transform.position ==  _b.transform.position)
        {
            _currentTarget = _a.transform.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, _currentTarget, step);
    }
	#endregion
}
