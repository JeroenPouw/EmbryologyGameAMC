using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fuel : MonoBehaviour {
	public Slider fuelline;
	float maxFuel = 100;
	float minFuel = 0;
	public static float currentFuel;

	// Use this for initialization
	void Awake () {
		currentFuel = maxFuel;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Fuel") {
			currentFuel += 25;
		}
	}
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp(KeyCode.O)) {
			currentFuel += 10;
		}
		if (Input.GetKeyUp(KeyCode.L)) {
			currentFuel -= 10;
		}
		if (currentFuel > maxFuel) {
			currentFuel = maxFuel;
		}
		if (currentFuel < minFuel) {
			currentFuel = minFuel;
		}
		fuelline.value = currentFuel;
	}

	public void Refuel () {
		currentFuel = maxFuel;
	}
}
