using UnityEngine;
using System.Collections;

public class FuelPickUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter (Collider other){
		Fuel.currentFuel = 100;
		this.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
