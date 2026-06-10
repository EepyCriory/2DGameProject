using UnityEngine;
using UnityEngine.SceneManagement;


public class InGameController : MonoBehaviour
{
    #region Unity Callbacks
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    #endregion
}
