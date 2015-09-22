using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class CameraSwitch : MonoBehaviour {
	public Camera Cam1;
	public Camera Cam2;
	public Component FPSscript;
	Movement Script2D;
	bool FPSView = true;
	FirstPersonController Script3D;
	public Collider Collider2D;
	CharacterController cc;
	// Use this for initialization
	void Start () {
		Script2D = gameObject.GetComponent<Movement>();
		Script3D = gameObject.GetComponent<FirstPersonController> ();
		cc = gameObject.GetComponent(typeof(CharacterController)) as CharacterController;
	}
	void SwitchCameras(){
		Script3D.enabled = !Script3D.enabled; // turn on/off FPS movement
		Cam1.enabled = !Cam1.enabled; // turn on/off FPS Camera
		Script2D.enabled = !Script2D.enabled; // turn on/off TopView movement
		Cam2.enabled = !Cam2.enabled; // turn on/off TopView Camera
		Collider2D.enabled = !Collider2D.enabled;
		cc.enabled = !cc.enabled;


	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			SwitchCameras();
				}
	}
}
