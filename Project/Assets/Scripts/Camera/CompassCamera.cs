using UnityEngine;
using System.Collections;

public class CompassCamera : MonoBehaviour {
	public Camera compassCamera;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
	if (compassCamera == null) {
			compassCamera = GameObject.Find ("Compass Camera").GetComponent<Camera> ();
			GetComponent<Canvas> ().worldCamera = compassCamera;
		}
	}
}
