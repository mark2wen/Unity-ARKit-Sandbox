using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatModifierUIEntry : MonoBehaviour {

	[SerializeField]
	new Text name;

	[SerializeField]
	Text floatValue;

	[SerializeField]
	InfinisliderUI slider;

	private CCReflectFloat reflectFloat;

	public void SetupWithReflector(CCReflectFloat rFloat) 
	{
		rFloat.ReloadField();	
		slider.OnSlide += VariableUpdated;
		reflectFloat = rFloat;
		name.text = reflectFloat.varName;		
		floatValue.text = reflectFloat.GetFloat().ToString();
	}

	void Increase() 
	{
		reflectFloat.SetValue((float)reflectFloat.GetFloat()+1);
	}

	void VariableUpdated(float value)
	{
		float val = reflectFloat.GetFloat();
		val += value;
		reflectFloat.SetValue(val);
		floatValue.text = reflectFloat.GetFloat().ToString();
	}
}
