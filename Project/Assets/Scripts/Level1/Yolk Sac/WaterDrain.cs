using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterDrain : MonoBehaviour {
	public float Endotimer;
	public float Ectotimer;
	public float Mesotimer;

	public bool endoEvent = false;
	bool oldendoEvent;
	public bool ectoEvent = false;
	bool oldectoEvent;
	public bool mesoEvent = false;
	bool oldmesoEvent;

	public Color trueColor;
	
	// Use this for initialization
	void Awake () {
		RandomTimer ();
	}
	void OnTriggerStay(Collider other){
		trueColor = other.gameObject.GetComponent<Renderer> ().material.color;
		switch (other.gameObject.tag) {
		case "Endoderm":
			StartCoroutine(WaitandDestroy(Endotimer));
			if (endoEvent == true) { // change color to red, for player feedback.
				other.gameObject.GetComponent<Renderer>().material.color = Color.red;
			}else{
				other.gameObject.GetComponent<Renderer>().material.color = Color.white;
			}
			break;
		case "Ectoderm":
			StartCoroutine(WaitandDestroy(Ectotimer));
			if (ectoEvent == true) {// change color to red, for player feedback.
				other.gameObject.GetComponent<Renderer>().material.color = Color.red;
			}else{
				other.gameObject.GetComponent<Renderer>().material.color = Color.white;
			}
			break;
		case "Mesoderm":
			StartCoroutine(WaitandDestroy(Mesotimer));
			if (mesoEvent == true) {// change color to red, for player feedback.
				other.gameObject.GetComponent<Renderer>().material.color = Color.red;
			}else{
				other.gameObject.GetComponent<Renderer>().material.color = Color.white;
			}
			break;
		}

	}

	public void RandomEventStart(int eventNum){
		switch (eventNum) {//Depending on the number from RandomDrainEvent.cs, start the random event for either the Meso, Ecto or Endoderm.
		case 1:
			if (endoEvent == true) {
				oldendoEvent = false;
			}
			endoEvent = !endoEvent;
			RandomTimer();
			break;
		case 2:
			if (ectoEvent == true) {
				oldectoEvent = false;
			}
			ectoEvent = !ectoEvent;
			RandomTimer();
			break;
		case 3:
			if (mesoEvent == true) {
				oldmesoEvent = false;
			}
			mesoEvent = !mesoEvent;
			RandomTimer();
			break;
		}
	}

	void RandomTimer(){
		if (ectoEvent == true) { // Determine draining speed. Lower speeds are for random events.
			Ectotimer = 0.75f;
		}else Ectotimer = 4f;

		if (endoEvent == true) {
			Endotimer = 0.75f	;
		}else Endotimer = 4f;

		if (mesoEvent == true) {
			Mesotimer = 0.75f;
		}else Mesotimer = 4f;
	}

	public void ClearList(){ // Set gameObjects false, Cannot destroy due to Null error.
		this.gameObject.SetActive (false);
	}

	IEnumerator WaitandDestroy(float timer){
		yield return new WaitForSeconds (timer);
		ClearList ();

	}


	// Update is called once per frame
	void Update () {
		
	}
}