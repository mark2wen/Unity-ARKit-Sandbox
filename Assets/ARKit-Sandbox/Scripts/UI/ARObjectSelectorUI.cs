using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARObjectSelectorUI : MonoBehaviour {

	[SerializeField]
	List<ARObject> objects;

	[SerializeField]
	ARObjectUIEntry uiEntryPrefab;

	[SerializeField]
	Transform objectListParent;

	[SerializeField]
	Button settingsButton;

	[SerializeField]
	Button dismissButton;

	[SerializeField]
	ARObjectContextUI contextView;

	[SerializeField]
	Transform settingsTransform;

	void Start () 
	{
		settingsButton.onClick.AddListener(SettingsPressed);
		dismissButton.onClick.AddListener(DismissPressed);
	
		foreach (ARObject obj in objects) 
		{
			ARObjectUIEntry entry = Instantiate (uiEntryPrefab);
			entry.Init (obj, ObjectSelected);
			entry.transform.SetParent(objectListParent);
		}
	}

	void OnDestroy()
	{
		settingsButton.onClick.RemoveListener(SettingsPressed);
		dismissButton.onClick.RemoveListener(DismissPressed);
	}

	void OnEnable() 
	{
		contextView.gameObject.SetActive(false);
	}

	void ObjectSelected(ARObject obj)
	{
		gameObject.SetActive(false);
		GameObject arObj = Instantiate (obj) . gameObject;
		arObj.gameObject.AddComponent<ObjectPlacer>();
		contextView.SelectObject(arObj.GetComponent<ARObject>());
	}

	void SettingsPressed()
	{
		if (settingsTransform.gameObject.activeInHierarchy) 
		{
			settingsTransform.gameObject.SetActive(false);
		}
		else 
		{
			settingsTransform.gameObject.SetActive(true);
		}
	}

	void DismissPressed() 
	{
		settingsTransform.gameObject.SetActive(false);
		gameObject.SetActive(false);
	}
}
