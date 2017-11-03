using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateWidget : MonoBehaviour {

	public enum WidgetType {
		TranslateWidget,
		ScaleWidget
	}

	public Transform targetObject;

	[SerializeField]
	WidgetType widgetType;

	[SerializeField]
	List<Transform> axes;

	[SerializeField]
	float speed = 0.25f;

	private Transform activeAxis;

	void Update () 
	{
		List<Touch> touches = TouchHelper.GetTouches();

		if (touches.Count > 0)
		{
			var touch = touches[0];
			
			if (touch.phase == TouchPhase.Began) 
			{
				float closestDot = -1f;

				foreach (Transform axis in axes) 
				{
				    Ray ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0));
					Vector3 vectorToAxis = (axis.position - Camera.main.transform.position).normalized;
					float currentDot = Vector3.Dot(ray.direction, vectorToAxis);

					if (currentDot > closestDot) 
					{
						closestDot = currentDot;
						activeAxis = axis;
					}
				}
			}
			
			if ( touch.phase == TouchPhase.Moved )
			{
				Vector3 offset = activeAxis.forward;
				offset.x *= touch.deltaPosition.x;
				offset.y *= touch.deltaPosition.y;
				offset.z *= touch.deltaPosition.x;
				
				if (widgetType == WidgetType.TranslateWidget) 
				{
					targetObject.position += offset * speed * Time.deltaTime;
				}
				else if (widgetType == WidgetType.ScaleWidget) 
				{
					targetObject.localScale += offset * speed * Time.deltaTime;	
				}
			}

			if (touch.phase == TouchPhase.Ended) 
			{
				activeAxis = null;
			}
		}
	}
}
