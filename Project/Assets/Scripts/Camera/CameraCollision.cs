using UnityEngine;
using System.Collections;

public class CameraCollision : MonoBehaviour
{
public float minDistance = 1.0f;
public float maxDistance = 10.0f;


Vector3 dollyDir;
float distance; 


	void Awake()
	{
		dollyDir = transform.localPosition.normalized;
		distance = transform.localPosition.magnitude;
	}


	void Update()
	{
		Vector3 desiredCameraPos = transform.TransformPoint( dollyDir * distance );
	}
}