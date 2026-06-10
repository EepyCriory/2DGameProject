using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections.Generic;

public class UISettings : MonoBehaviour
{
	#region Fields
	[SerializeField] private TMP_Dropdown _qualityDropdown;

	[SerializeField] private Toggle _VsyncToggle;
	[SerializeField] private Toggle _fullScreenToggle;

	[SerializeField] private Toggle _noShadowToggle;
	[SerializeField] private Toggle _SoftShadowToggle;
	[SerializeField] private Toggle _HardShadowToggle;

	[SerializeField] private Slider _particleResSlider;
	#endregion

	#region Unity Callbacks
	void Start()
	{
        _qualityDropdown.ClearOptions();
        _qualityDropdown.onValueChanged.AddListener(SetQuality);
        QualityInitialize();

        _VsyncToggle.onValueChanged.AddListener(SetVSync);
		_fullScreenToggle.onValueChanged.AddListener(SetFullScreen);

		_noShadowToggle.onValueChanged.AddListener(SetNoShadows);
        _SoftShadowToggle.onValueChanged.AddListener(SetSoftShadows);
        _HardShadowToggle.onValueChanged.AddListener(SetHardShadows);

        _particleResSlider.onValueChanged.AddListener(SetParticleResolution);
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #region Quality
    private void QualityInitialize()
	{
		List<string> QualityOptions = new List<string>(QualitySettings.names);
		_qualityDropdown.AddOptions(QualityOptions);

		_qualityDropdown.value = QualitySettings.GetQualityLevel();
		_qualityDropdown.RefreshShownValue();
	}

	private void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
	}
	#endregion

	#region Toggles
	private void SetVSync(bool stateOn)
	{
		if (stateOn)
		{
			QualitySettings.vSyncCount = 0;
		}
		else
		{
			QualitySettings.vSyncCount = 1;
		}
	}

	private void SetFullScreen(bool stateOn)
	{ 
		Screen.fullScreen = !Screen.fullScreen;
	}

	private void SetParticleResolution (float value)
	{
		QualitySettings.particleRaycastBudget = (int)value;
	}
    #endregion

    #region Shadows
	private void SetNoShadows (bool stateOn)
	{
		if (stateOn)
		{
			QualitySettings.shadows = ShadowQuality.Disable;
		}
	}

	private void SetSoftShadows (bool stateOn)
	{
		if (stateOn)
		{
			QualitySettings.shadows = ShadowQuality.All;
		}
	}

	private void SetHardShadows (bool stateOn)
	{
		if (stateOn)
		{
			QualitySettings.shadows = ShadowQuality.HardOnly;
		}
	}
    #endregion
    #endregion
}
