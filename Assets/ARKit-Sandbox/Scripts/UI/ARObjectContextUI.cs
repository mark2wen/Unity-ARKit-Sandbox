using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARObjectContextUI : MonoBehaviour {

	//[HideInInspector]
	public ARObject currentObject;

	[SerializeField] 
	Button translateButton;

	[SerializeField] 
	Button rotateButton;

	[SerializeField] 
	Button scaleButton;

	[SerializeField] 
	Button deleteButton;

	[SerializeField]
	Button reflectFloatButton;

	[SerializeField]
	Button doneButton;

	[SerializeField]
	Text objectNameLabel;

	[SerializeField]
	TranslateWidget translateWidgetPrefab;

	[SerializeField]
	RotateWidget rotateWidgetPrefab;

	[SerializeField]
	TranslateWidget scaleWidgetPrefab;

	[SerializeField]
	FloatModifierUI floatModifyMenu;

	private TranslateWidget translateWidget;
	private RotateWidget rotateWidget;
	private TranslateWidget scaleWidget;

	void Start ()
	{
		translateButton.onClick.AddListener(TranslatePressed);
		rotateButton.onClick.AddListener(RotatePressed);
		scaleButton.onClick.AddListener(ScalePressed);
		deleteButton.onClick.AddListener(DeletePressed);
		doneButton.onClick.AddListener(DonePressed);
		reflectFloatButton.onClick.AddListener(ReflectFloatPressed);
	}
	
	void OnDestroy() 
	{
		translateButton.onClick.RemoveListener(TranslatePressed);
		rotateButton.onClick.RemoveListener(RotatePressed);
		scaleButton.onClick.RemoveListener(ScalePressed);
		deleteButton.onClick.RemoveListener(DeletePressed);
		doneButton.onClick.RemoveListener(DonePressed);
		reflectFloatButton.onClick.AddListener(ReflectFloatPressed);
	}

	public void SelectObject(ARObject obj)
	{
		objectNameLabel.text = obj.Title;
		currentObject = obj;
		gameObject.SetActive(true);
	}

	public void Dismiss() 
	{
		currentObject = null;
		RemoveWidgets();
		gameObject.SetActive(false);
	}

	void TranslatePressed() 
	{
		if (translateWidget == null) 
		{
			RemoveWidgets();
			translateWidget = Instantiate(translateWidgetPrefab, currentObject.transform.position, currentObject.transform.rotation);
			translateWidget.targetObject = currentObject.transform;
			translateWidget.transform.parent = currentObject.transform;
		}
	}

	void RotatePressed() 
	{
		if (rotateWidget == null) 
		{
			RemoveWidgets();
			rotateWidget = Instantiate(rotateWidgetPrefab, currentObject.transform.position, currentObject.transform.rotation);
			rotateWidget.targetObject = currentObject.transform;
			rotateWidget.transform.parent = currentObject.transform;
		}
	}

	void ScalePressed() 
	{
		if (scaleWidget == null) 
		{
			RemoveWidgets();
			scaleWidget = Instantiate(scaleWidgetPrefab, currentObject.transform.position, currentObject.transform.rotation);
			scaleWidget.targetObject = currentObject.transform;
			FollowObject followObj = scaleWidget.gameObject.AddComponent<FollowObject>();
			followObj.Target = currentObject.transform;
		}
	}

	void DeletePressed()
	{
		if (currentObject != null) 
		{
			Destroy(currentObject.gameObject);
			gameObject.SetActive(false);
		}

		RemoveWidgets();
	}

	void DonePressed() 
	{
		Dismiss();
	}

	void ReflectFloatPressed()
	{
		if (!floatModifyMenu.gameObject.activeInHierarchy) 
		{
			RemoveWidgets();
			floatModifyMenu.SetupWithObject(currentObject);
		}
		else 
		{
			floatModifyMenu.Dismiss();
		}
	}

	void RemoveWidgets() 
	{
		floatModifyMenu.Dismiss();
		
		if (translateWidget != null) 
		{
			Destroy(translateWidget.gameObject);
		}

		if (rotateWidget != null) 
		{
			Destroy(rotateWidget.gameObject);
		}

		if (scaleWidget != null) 
		{
			Destroy(scaleWidget.gameObject);
		}
	}
}
