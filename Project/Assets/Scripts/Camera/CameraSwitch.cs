using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class CameraSwitch : MonoBehaviour {
	public Camera Cam1;
	public Camera Cam2;
	MovementScript Script2D;
	bool FPSView = true;
	OpagueScript transSwitch;
	// Use this for initialization
	void Start () {
		Script2D = gameObject.GetComponent<MovementScript>();
		transSwitch = gameObject.GetComponent<OpagueScript> ();
	}
	void SwitchCameras(){
		Cam1.enabled = !Cam1.enabled; // turn on/off FPS Camera
		Script2D.enabled = !Script2D.enabled; // turn on/off TopView movement
		Cam2.enabled = !Cam2.enabled; // turn on/off TopView Camera
		if (FPSView) {
			Debug.Log("trans");
			transSwitch.MakeTransparent();
		}else if (!FPSView) {
			transSwitch.MakerOpague();
		}


	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			SwitchCameras();
			FPSView = !FPSView;
				}
	}
}
