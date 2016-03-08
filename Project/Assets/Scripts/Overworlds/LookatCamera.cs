using UnityEngine;
using System.Collections;

public class LookatCamera : MonoBehaviour {
	Transform mapCam;
	// Use this for initialization
	void Start () {
		OnLevelWasLoaded (); // Because Unity does not call OnLevelWasLoaded when starting a scene.
	}

	void OnLevelWasLoaded(){
		mapCam = GameObject.Find ("Outer Camera").transform;
	}
	// Update is called once per frame
	void Update () {
		if (mapCam == null) {
			OnLevelWasLoaded();
		}
		transform.LookAt (mapCam);
	}
}
