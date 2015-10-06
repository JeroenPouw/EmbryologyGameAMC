using UnityEngine;
using System.Collections;

public class FlipperRotate : MonoBehaviour {
	float maxRot = 55.0f;
	float minRot = 35.0f;
	float tempRot;
	public GameObject flipper1;
	public GameObject flipper2;
	public GameObject flipper3;
	bool isOpen;
	Transform rot1;
	Transform rot2;
	// Use this for initialization
	void Start () {
		rot1 = flipper1.transform.FindChild ("rot1");
		rot2 = flipper1.transform.FindChild ("rot2");
	}

	float ClampAngle(float angle, float from, float to) {
		if(angle > maxRot) angle = 360 - angle;
		angle = Mathf.Clamp(angle, from, to);
		if(angle < minRot) angle = 360 + angle;
		return angle;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q) && isOpen == false) {
			rot1 = flipper1.transform.FindChild ("rot1");
			rot2 = flipper1.transform.FindChild ("rot2");
		}
		if (Input.GetKeyDown(KeyCode.W) && isOpen == false) {
			rot1 = flipper2.transform.FindChild ("rot1");
			rot2 = flipper2.transform.FindChild ("rot2");
		}
		if (Input.GetKeyDown(KeyCode.E) && isOpen == false) {
			rot1 = flipper3.transform.FindChild ("rot1");
			rot2 = flipper3.transform.FindChild ("rot2");
		}

		if (Input.GetKey(KeyCode.S)) {
			isOpen = true;
			rot1.transform.Rotate(0, 0, 5);
			rot2.transform.Rotate(0, 0, -5);
		}
		if (Input.GetKeyUp(KeyCode.S)) {
			isOpen = false;
		}
		if (rot1.transform.eulerAngles.z > maxRot) {
			rot1.transform.eulerAngles = new Vector3(0,0,ClampAngle(rot1.rotation.eulerAngles.z ,maxRot,maxRot));
			rot2.transform.eulerAngles = new Vector3(0,0,ClampAngle(rot2.rotation.eulerAngles.z ,-maxRot,-maxRot));
		}
		if (rot1.transform.eulerAngles.z < minRot) {
			rot1.transform.eulerAngles = new Vector3(0,0,ClampAngle(rot1.rotation.eulerAngles.z, minRot,minRot));
			rot2.transform.eulerAngles = new Vector3(0,0,ClampAngle(rot2.rotation.eulerAngles.z, -minRot,-minRot));
		}
//		if (rot1 != null) {
//			rot1.transform.Rotate(0, 0, -2);
//			rot2.transform.Rotate(0, 0, 2);
//		}
		
		
	}
}
