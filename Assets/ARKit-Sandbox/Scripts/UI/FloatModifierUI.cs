using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatModifierUI : MonoBehaviour {

	[SerializeField]
	Transform targetParent;

	[SerializeField]
	FloatModifierUIEntry entryPrefab; 

	private ARObject currentObj;

	public void SetupWithObject(ARObject obj)
	{
		currentObj = obj;

		foreach (CCReflectFloat refFloat in currentObj.ReflectFloats) 
		{
			FloatModifierUIEntry entry = Instantiate(entryPrefab).GetComponent<FloatModifierUIEntry>();
			entry.SetupWithReflector(refFloat);
			entry.transform.SetParent(targetParent);
		}

		gameObject.SetActive(true);
	}

	public void Dismiss()
	{
		foreach (Transform child in targetParent)
		{
			Destroy(child.gameObject);
		}

		gameObject.SetActive(false);
	}
}
