using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings {

	public static Settings Instance
	{
		get 
		{
			if (instance == null) 
			{
				instance = new Settings();
			}
			return instance;
		}
	}

	public System.Action<bool> DisplayPlanesChanged;
	public System.Action<bool> DisplayPointsChanged;
	public System.Action<bool> InvisibleMenuChanged;

	private const string DisplayPlanesKey = "DisplayPlanes";
	private const string DisplayPointsKey = "DisplayPoints";
	private const string InvisibleMenuButtonKey = "InvisibleMenuButton";

	private static Settings instance;  

	public bool DisplayPlanes 
	{
		get 
		{
			bool val = PlayerPrefs.GetInt(DisplayPlanesKey) == 0 ? false : true;
			return val;
		}
		set
		{
			int val = value ? 1 : 0;
			PlayerPrefs.SetInt(DisplayPlanesKey, val);

			if (DisplayPlanesChanged != null) 
			{
				DisplayPlanesChanged(value);
			}

			PlayerPrefs.Save();
		}
	}

	public bool DisplayPoints
	{
		get 
		{
			bool val = PlayerPrefs.GetInt(DisplayPointsKey) == 0 ? false : true;
			return val;
		}
		set
		{
			int val = value ? 1 : 0;
			PlayerPrefs.SetInt(DisplayPointsKey, val);

			if (DisplayPointsChanged != null) 
			{
				DisplayPointsChanged(value);
			}

			PlayerPrefs.Save();
		}
	}

	public bool InvisibleMenuButton
	{
		get 
		{
			bool val = PlayerPrefs.GetInt(InvisibleMenuButtonKey) == 0 ? false : true;
			return val;
		}
		set
		{
			int val = value ? 1 : 0;
			PlayerPrefs.SetInt(InvisibleMenuButtonKey, val);
			
			if (InvisibleMenuChanged != null) 
			{
				InvisibleMenuChanged(value);
			}

			PlayerPrefs.Save();
		}
	}
}
