using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWidget : MonoBehaviour {

	public Transform targetObject;

	[SerializeField]
	float speed = 2f;

	void Update () 
	{
		List<Touch> touches = TouchHelper.GetTouches();

		if (touches.Count > 0)
		{
			var touch = touches[0];
			
			if ( touch.phase == TouchPhase.Moved )
			{
				targetObject.Rotate(targetObject.up * touch.deltaPosition.x * speed * Time.deltaTime);	
			}
		}
	}
}
