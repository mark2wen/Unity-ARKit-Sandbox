using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	[SerializeField]
	Button showMenuButton;

	[SerializeField]
	Transform addObjectTransform;

	[SerializeField]
	ARObjectContextUI contextView;

	void Start() 
	{
		showMenuButton.onClick.AddListener(ToggleMenu);

		HideMenuButton(Settings.Instance.InvisibleMenuButton);
		Settings.Instance.InvisibleMenuChanged += HideMenuButton;
	}

	void OnDestroy() 
	{
		showMenuButton.onClick.RemoveListener(ToggleMenu);
	}

	void ToggleMenu() 
	{
		if (addObjectTransform.gameObject.activeInHierarchy)
		{
			addObjectTransform.gameObject.SetActive(false);
		}
		else 
		{
			contextView.Dismiss();
			addObjectTransform.gameObject.SetActive(true);
		}
	}

	void HideMenuButton(bool value)
	{
		if (value) 
		{
			showMenuButton.GetComponentInChildren<Text>().color = new Color(1f, 1f, 1f, 0f);
		}
		else
		{
			showMenuButton.GetComponentInChildren<Text>().color = Color.white;
		}
	}
}
