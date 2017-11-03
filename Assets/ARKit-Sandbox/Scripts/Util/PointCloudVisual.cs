// Code Mostly from Unity's ARKit plugin https://bitbucket.org/Unity-Technologies/unity-arkit-plugin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class PointCloudVisual : MonoBehaviour {

	[SerializeField]
    ParticleSystem pointCloudParticlePrefab;

	private ParticleSystem currentPS;

    public int maxPointsToShow = 1000;
    public float particleSize = 0.01f;
    private Vector3[] m_PointCloudData;
    private bool frameUpdated = false;
    private ParticleSystem.Particle [] particles;

	void OnEnable()
	{
		UnityARSessionNativeInterface.ARFrameUpdatedEvent += ARFrameUpdated;
        
		if (currentPS == null)
		{
			currentPS = Instantiate (pointCloudParticlePrefab);
			currentPS.transform.parent = transform.parent;
		}
        frameUpdated = false;
	}

	void OnDisable()
	{
		frameUpdated = false;
		m_PointCloudData = null;
		UnityARSessionNativeInterface.ARFrameUpdatedEvent -= ARFrameUpdated;
		Destroy(currentPS);
	}
	
    public void ARFrameUpdated(UnityARCamera camera)
    {
        m_PointCloudData = camera.pointCloudData;
        frameUpdated = true;
    }

	void Update () {
        if (frameUpdated) {
            if (m_PointCloudData != null && m_PointCloudData.Length > 0) {
                int numParticles = Mathf.Min (m_PointCloudData.Length, maxPointsToShow);
                ParticleSystem.Particle[] particles = new ParticleSystem.Particle[numParticles];
                int index = 0;
                foreach (Vector3 currentPoint in m_PointCloudData) {     
                    particles [index].position = currentPoint;
                    particles [index].startColor = new Color (1.0f, 1.0f, 1.0f);
                    particles [index].startSize = particleSize;
                    index++;
                }
                currentPS.SetParticles (particles, numParticles);
            } else {
                ParticleSystem.Particle[] particles = new ParticleSystem.Particle[1];
                particles [0].startSize = 0.0f;
                currentPS.SetParticles (particles, 1);
            }
            frameUpdated = false;
        }
	}
}
