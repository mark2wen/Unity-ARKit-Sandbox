using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour {

	[SerializeField]
	Toggle DisplayPlanesToggle;
	
	[SerializeField]
	Toggle DisplayPointsToggle;
	
	[SerializeField]
	Toggle InvisibleMenuToggle;

	void OnEnable() 
	{
		DisplayPlanesToggle.isOn = Settings.Instance.DisplayPlanes;
		DisplayPointsToggle.isOn = Settings.Instance.DisplayPoints;
		InvisibleMenuToggle.isOn = Settings.Instance.InvisibleMenuButton;
	}

	public void DisplayPlanesValueChanged(bool value) 
	{
		Settings.Instance.DisplayPlanes = value;
	}

	public void DisplayPointsValueChanged(bool value) 
	{
		Settings.Instance.DisplayPoints = value;
	}

	public void InvisibleMenuButtonValueChanged(bool value) 
	{
		Settings.Instance.InvisibleMenuButton = value;
	}	
}
