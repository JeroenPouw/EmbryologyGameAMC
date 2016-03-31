using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class CameraSwitch : MonoBehaviour {
	GameObject Cam1;
	public Camera Cam2;
	MovementScript Script3D;
	public bool TPSView = true;
	OpagueScript transSwitch;
	GameObject YouAreHere;
	MouseTorque mouseScript;
	GameObject[] highlights;
	GameObject player;
	public bool tabpress;
	public static bool firsttime;
	public static bool firstclose;

	void Start(){
		OnLevelWasLoaded (); // Because unity doesn't call OnLevelWasLoaded when starting a Scene.
		Script3D = gameObject.GetComponent<MovementScript> ();
		transSwitch = gameObject.GetComponent<OpagueScript> ();
		mouseScript = gameObject.GetComponent<MouseTorque> ();
		YouAreHere = GameObject.FindGameObjectWithTag ("YouAreHere");
		YouAreHere.gameObject.SetActive (false);
	}
	void OnLevelWasLoaded () {
		highlights = null;
		highlights = GameObject.FindGameObjectsWithTag ("Highlightable");
		Cam1 = null;
		Cam1 = GameObject.Find ("Map Camera");
		if (!Cam2.isActiveAndEnabled) {
			Cam1.GetComponent<Camera>().enabled = true;
			Cam1.GetComponent<MoveCamera>().enabled = true;
		}
		foreach (GameObject go in highlights) {
			//GameObject script = go.transform.parent.gameObject;
			//script.gameObject.layer = 2;
		}
		
	}

	public void SwitchCameras(){
		Debug.Log ("M is pressed");
		firsttime = true;
		Cam1.GetComponent<Camera>().enabled = !Cam1.GetComponent<Camera>().enabled; // turn on/off third person Camera
		Cam1.GetComponent<MoveCamera> ().enabled = !Cam1.GetComponent<MoveCamera> ().enabled; // turn on/off camerascript
		Script3D.enabled = !Script3D.enabled; // turn on/off movement
		Cam2.enabled = !Cam2.enabled; // turn on/off TopView Camera
		mouseScript.enabled = !mouseScript.enabled; // turn on/off mouserotation
		Debug.Log ("objects about to be loaded");
		if (TPSView) {
			YouAreHere.SetActive (true);
			foreach (GameObject go in highlights) {
				go.GetComponent<Renderer>().enabled = true;
				go.GetComponent<Collider>().enabled = true; 
				//GameObject script = go.transform.parent.gameObject;
				//script.gameObject.layer = 23;
			}
			transSwitch.MakeTransparent();
			StartCoroutine(wait ());	
			TPSView = !TPSView;
		}else if (!TPSView) {
			firstclose = true;
			transSwitch.MakeOpague();
			YouAreHere.SetActive (false);
			foreach (GameObject go in highlights) {
				//GameObject script = go.transform.parent.gameObject;
				//script.gameObject.layer = 2;
				go.GetComponent<Collider>().enabled = false;
				go.GetComponent<Renderer>().enabled = false;
			}
			StartCoroutine(wait ());
			TPSView = !TPSView;
		}
	}

	IEnumerator wait(){
		tabpress = true;
		yield return new WaitForSeconds (1);
		tabpress = false;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.M) && !tabpress) {
			SwitchCameras();
			Debug.Log("cameraswitch");
		}
	}
}
