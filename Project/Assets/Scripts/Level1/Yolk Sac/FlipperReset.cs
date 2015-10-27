using UnityEngine;
using System.Collections;

public class FlipperReset : MonoBehaviour {
	public Transform rot1;
	public Transform rot2;
	float maxRot = 55.0f;
	float minRot = 35.0f;
	// Use this for initialization
	void Start () {
	
	}

	float ClampAngle(float angle, float from, float to) {
		if(angle > maxRot) angle = 360 - angle;
		angle = Mathf.Clamp(angle, from, to);
		if(angle < minRot) angle = 360 + angle;
		return angle;
	}

	
	// Update is called once per frame
	void Update () { // reset the flippers to their starting rotations.
		if (rot1.transform.eulerAngles.z > maxRot) {
			rot1.transform.eulerAngles = new Vector3(0,0,ClampAngle(rot1.rotation.eulerAngles.z ,maxRot,maxRot));
			rot2.transform.eulerAngles = new Vector3(0,0,ClampAngle(rot2.rotation.eulerAngles.z ,-maxRot,-maxRot));
		}
		if (rot1.transform.eulerAngles.z < minRot) {
			rot1.transform.eulerAngles = new Vector3(0,0,ClampAngle(rot1.rotation.eulerAngles.z, minRot,minRot));
			rot2.transform.eulerAngles = new Vector3(0,0,ClampAngle(rot2.rotation.eulerAngles.z, -minRot,-minRot));
		}
		if (rot1 != null) {
			rot1.transform.Rotate(0, 0, -2);
			rot2.transform.Rotate(0, 0, 2);
		}
	}
}
