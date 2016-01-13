using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fuel : MonoBehaviour {
	float maxFuel = 100;
	float minFuel = 0;
	public static float currentFuel;
	Slider fuelSlider;
	Slider ingameSlider;
	// Use this for initialization
	void Start () {
		currentFuel = maxFuel;
//		OnLevelWasLoaded ();
	}

	void OnLevelWasLoaded(){
//		fuelSlider = GameObject.Find ("FuelSlider").GetComponent<Slider> ();
//		ingameSlider = GameObject.Find ("ingameslider").GetComponent<Slider> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Fuel") {
			currentFuel += 25;
		}
	}
	// Update is called once per frame
	void Update () {
//		fuelSlider.value = currentFuel;
//		ingameSlider.value = currentFuel;
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
