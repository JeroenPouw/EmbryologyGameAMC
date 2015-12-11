using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fuel : MonoBehaviour {
	float maxFuel = 100;
	float minFuel = 0;
	public static float currentFuel;
	public Slider fuelSlider;
	// Use this for initialization
	void Awake () {
		currentFuel = maxFuel;

	}
	
	// Update is called once per frame
	void Update () {
		fuelSlider.value = currentFuel;
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
	}	
}
