using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.rotation = Quaternion.Euler(90, -270, 0);
	}
}
