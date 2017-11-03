using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class ObjectPlacer : MonoBehaviour {

	bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
	{
		List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, resultTypes);
		if (hitResults.Count > 0) {
			transform.position = UnityARMatrixOps.GetPosition (hitResults[0].worldTransform);
			transform.rotation = UnityARMatrixOps.GetRotation (hitResults[0].worldTransform);
			return true;
		}
		return false;
	}
	
	void Update() 
	{
		if (Input.touchCount > 0) 
		{
			var touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
			{
				var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
				ARPoint point = new ARPoint {
					x = screenPosition.x,
					y = screenPosition.y
				};

				// prioritize reults types
				ARHitTestResultType[] resultTypes = {
					ARHitTestResultType.ARHitTestResultTypeExistingPlane,
					ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, 
					ARHitTestResultType.ARHitTestResultTypeHorizontalPlane, 
					ARHitTestResultType.ARHitTestResultTypeFeaturePoint
				}; 
				
				foreach (ARHitTestResultType resultType in resultTypes)
				{
					if (HitTestWithResultType (point, resultType))
					{
						return;
					}
				}
			}
			else if (touch.phase == TouchPhase.Ended) 
			{
				Destroy(this);
			}
		}
	}
}
