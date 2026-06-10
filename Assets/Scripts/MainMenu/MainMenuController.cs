using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	#region Fields
	[SerializeField] private Button _continue;
	[SerializeField] private Button _quit;
	#endregion

	#region Unity Callbacks
    void Start()
    {
		_continue.onClick.AddListener(StartGame);
		_quit.onClick.AddListener(ExitGame);
    }
    #endregion

    #region Private Methods
    private void StartGame()
	{
		SceneManager.LoadScene("GameScene");
	}

	private void ExitGame()
	{
		Application.Quit();
	}
	#endregion
}