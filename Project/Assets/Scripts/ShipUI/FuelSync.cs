using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuelSync : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Slider> ().value = Fuel.currentFuel;
	}
}
