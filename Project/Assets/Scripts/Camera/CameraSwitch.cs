using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class CameraSwitch : MonoBehaviour {
	GameObject Cam1;
	public Camera Cam2;
	MovementScript Script2D;
	bool TPSView = true;
	OpagueScript transSwitch;
	GameObject YouAreHere;
	MouseTorque mouseScript;
	GameObject[] highlights;
	GameObject player;
	bool tabpress;

	void Start(){
		OnLevelWasLoaded (); // Because unity doesn't call OnLevelWasLoaded when starting a Scene.
		Script2D = gameObject.GetComponent<MovementScript> ();
		transSwitch = gameObject.GetComponent<OpagueScript> ();
		mouseScript = gameObject.GetComponent<MouseTorque> ();
		YouAreHere = GameObject.FindGameObjectWithTag ("YouAreHere");
		YouAreHere.gameObject.SetActive (false);
	}
	void OnLevelWasLoaded () {
		highlights = GameObject.FindGameObjectsWithTag ("Highlightable");
		Cam1 = null;
		Cam1 = GameObject.Find ("Map Camera");
		if (!Cam2.isActiveAndEnabled) {
			Cam1.GetComponent<Camera>().enabled = true;
		}
		foreach (GameObject go in highlights) {
			GameObject script = go.transform.parent.gameObject;
			script.gameObject.layer = 2;
		}
		
	}

	public void SwitchCameras(){
		Cam1.GetComponent<Camera>().enabled = !Cam1.GetComponent<Camera>().enabled; // turn on/off third person Camera
		Script2D.enabled = !Script2D.enabled; // turn on/off movement
		Cam2.enabled = !Cam2.enabled; // turn on/off TopView Camera
		mouseScript.enabled = !mouseScript.enabled; // turn on/off mouserotation
	
		if (TPSView) {
			YouAreHere.SetActive (true);
			foreach (GameObject go in highlights) {
				go.GetComponent<Renderer>().enabled = true;
				go.GetComponent<Collider>().enabled = true;
				GameObject script = go.transform.parent.gameObject;
				script.gameObject.layer = 23;
			}
			transSwitch.MakeTransparent();
			StartCoroutine(wait ());				
		}else if (!TPSView) {
			transSwitch.MakeOpague();
			YouAreHere.SetActive (false);
			foreach (GameObject go in highlights) {
				GameObject script = go.transform.parent.gameObject;
				script.gameObject.layer = 2;
				go.GetComponent<Collider>().enabled = false;
				go.GetComponent<Renderer>().enabled = false;
			}
			StartCoroutine(wait ());
		}
	}

	IEnumerator wait(){
		tabpress = true;
		yield return new WaitForSeconds (1);
		tabpress = false;
	}
	// Update is called once per frame
	void Update () {
		Debug.Log (Cam1);
		if (Input.GetKeyDown(KeyCode.Tab) && tabpress != true) {
			SwitchCameras();
			TPSView = !TPSView;
				}
		if (player == null) {
			player = GameObject.Find("Player(Clone)");
		}
	}
}
