using System.Collections;
using TMPro;
using UnityEngine;

public class UITextBoosts : MonoBehaviour
{
	#region Fields
	[SerializeField] private TextMeshProUGUI _text;
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text=("");
    }
    #endregion

    #region Public Methods
    public void SpeedBoost()
    {
        _text.text=("Has recibido un bono de velocidad del 30%");
        StartCoroutine(Text());
    }
    public void JumpBoost()
    {
        _text.text=("Has recibido un bono de salto del 30%");
        StartCoroutine(Text());
    }
    public void DoubleJumpCharge()
    {
        _text.text=("Has recibido un salto doble");
        StartCoroutine(Text());
    }
    #endregion

    #region Private Methods
    private IEnumerator Text()
    {
        yield return new WaitForSeconds(0.75f);
        _text.text=("");
    }
    #endregion
}
