using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARObjectUIEntry : MonoBehaviour {

	[SerializeField]
	Text title;

	[SerializeField]
	Button button;

	private System.Action<ARObject> onPressedAction;
	private ARObject obj;

	public void Init(ARObject arObject, System.Action<ARObject> onPressed) 
	{
		obj = arObject;
		onPressedAction = onPressed;
		title.text = arObject.Title;
		button.onClick.AddListener(ButtonPressed);
	}
	
	void ButtonPressed() 
	{
		if (onPressedAction != null) 
		{
			onPressedAction(obj);
		}
	}
}
