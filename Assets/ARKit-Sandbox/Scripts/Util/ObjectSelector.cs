using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour {

	[SerializeField]
	ARObjectContextUI contextMenu;

	void Update () 
	{
		List<Touch> touches = TouchHelper.GetTouches();

		if (touches.Count > 0) 
		{
			var touch = touches[0];
			if (touch.phase == TouchPhase.Began)
			{
				var ray = Camera.main.ScreenPointToRay(touch.position);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, 100)) 
				{
					ARObject arObj = hit.collider.GetComponent<ARObject>();
					
					if (arObj == null) 
					{
						arObj = hit.collider.GetComponentInParent<ARObject>();
					}
					if (arObj != null) 
					{
						SelectObject(arObj);
					}
				}	
			}
		}
	}

	void SelectObject(ARObject obj) 
	{
		contextMenu.SelectObject(obj);
	}
}
