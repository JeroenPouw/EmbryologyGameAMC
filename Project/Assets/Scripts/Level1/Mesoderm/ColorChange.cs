using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorChange : MonoBehaviour {
	public bool isCorrect;
	public GameObject child1;
	public GameObject child2;
	float closeVPDist= 0.5f;

	GameObject current;
	ObjectSnapScript snap;
	// Use this for initialization
	void Start () {
		current = this.gameObject;
		snap = current.GetComponent<ObjectSnapScript> ();
	}

	void OnMouseDrag(){
		child1.GetComponent<Renderer>().material.color = Color.red;
		if (child2 != null) {
			child2.GetComponent<Renderer>().material.color = Color.red;
		}
	}
	void OnMouseUp(){
			if (snap.snap == true) {
			child1.GetComponent<Renderer> ().material.color = Color.yellow;
			if (child2 != null) {
				child2.GetComponent<Renderer> ().material.color = Color.yellow;
			}
		}
	}
	// Update is called once per frame
	void Update () {
	if (isCorrect) {
			child1.GetComponent<Renderer>().material.color = Color.green;
			if (child2 != null) {
				child2.GetComponent<Renderer>().material.color = Color.green;
			}
			isCorrect = false;
		}
	}
}
