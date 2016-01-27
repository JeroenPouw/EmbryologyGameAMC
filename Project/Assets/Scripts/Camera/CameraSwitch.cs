using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class CameraSwitch : MonoBehaviour {
	public Camera Cam1;
	public Camera Cam2;
	MovementScript Script2D;
	bool TPSView = true;
	OpagueScript transSwitch;
	GameObject YouAreHere;
	MouseTorque mouseScript;
	GameObject[] highlights;

	// Use this for initialization
	void Start () {
		Script2D = gameObject.GetComponent<MovementScript>();
		transSwitch = gameObject.GetComponent<OpagueScript> ();
		mouseScript = gameObject.GetComponent<MouseTorque> ();
		YouAreHere = GameObject.FindGameObjectWithTag ("YouAreHere");
		highlights = GameObject.FindGameObjectsWithTag ("Highlightable");
		YouAreHere.gameObject.SetActive (false);
		foreach (GameObject go in highlights) {
			GameObject script = go.transform.parent.gameObject;
			script.gameObject.layer = 2;
		}
	}

	void SwitchCameras(){
		Cam1.enabled = !Cam1.enabled; // turn on/off third person Camera
		Script2D.enabled = !Script2D.enabled; // turn on/off movement
		Cam2.enabled = !Cam2.enabled; // turn on/off TopView Camera
		mouseScript.enabled = !mouseScript.enabled; // turn on/off mouserotation
	
		if (TPSView) {
			transSwitch.MakeTransparent();
			YouAreHere.SetActive (true);
			foreach (GameObject go in highlights) {
				GameObject script = go.transform.parent.gameObject;
				script.gameObject.layer = 23;
			}
		}else if (!TPSView) {
			transSwitch.MakerOpague();
			YouAreHere.SetActive (false);
			foreach (GameObject go in highlights) {
				GameObject script = go.transform.parent.gameObject;
				script.gameObject.layer = 2;
			}
		}


	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			SwitchCameras();
			TPSView = !TPSView;
				}
	}
}
