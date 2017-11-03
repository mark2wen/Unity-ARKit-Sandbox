using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneVisualConfig : MonoBehaviour {

	[SerializeField]
	Material planeMaterial;

	[SerializeField]
	Shader invisibleShader;

	[SerializeField]
	PointCloudVisual pointCloudVisual;

	private Shader originalShader;

	void Start () 
	{
		originalShader = planeMaterial.shader;
		Settings.Instance.DisplayPlanesChanged += UpdateDisplayPlanes;
		Settings.Instance.DisplayPointsChanged += UpdateDisplayPoints;
		UpdateDisplayPlanes(Settings.Instance.DisplayPlanes);
	}

	void UpdateDisplayPlanes(bool value) 
	{
		if (value) 
		{
			planeMaterial.shader = originalShader;
		}
		else
		{
			planeMaterial.shader = invisibleShader;
		}
	}

	void UpdateDisplayPoints(bool value)
	{
		if (value)
		{
			pointCloudVisual.gameObject.SetActive(true);
		}
		else 
		{
			pointCloudVisual.gameObject.SetActive(false);
		}
	}
}
