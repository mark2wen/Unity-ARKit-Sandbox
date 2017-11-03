using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfinisliderUI : EventTrigger {

	public System.Action<float> OnSlide;
	private Vector2 offset = Vector2.zero;
	public float scalar = 4.0f;

	void Start() 
	{
		GetComponent<Image>().material = new Material(GetComponent<Image>().materialForRendering);
	}

	public override void OnDrag(PointerEventData data)
	{
		if (Input.touchCount > 0)
		{
			float delta = Input.GetTouch(0).deltaPosition.x/Screen.width;
			offset.x -= delta*scalar;

			GetComponent<Image>().materialForRendering.SetTextureOffset("_MainTex", offset);

			if (OnSlide != null)
			{
				OnSlide(delta*scalar);
			}	
		}
	}
}
