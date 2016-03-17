using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fuel : MonoBehaviour {
	public Slider fuelline;
	float maxfuel = 100;
	float minfuel = 0;
	public float currentFuel;
	public float fuelconsumption;

	private MovementScript movref;

	void Start () {
		movref = this.GetComponent<MovementScript> ();
	}

	void Awake () {
		currentFuel = maxfuel;
	}

	void Update () {
		if (currentFuel > maxfuel) {
			currentFuel = maxfuel;
		}
		if (currentFuel < minfuel) {
			currentFuel = minfuel;
			movref.PenalizeMaxSpeed ();
		}


		fuelline.value = currentFuel;
	}

	public void Refuel () {
		currentFuel = maxfuel;
		movref.RestoreMaxSpeed ();
	}

	public void ConsumeFuel () {
		currentFuel -= fuelconsumption * Time.deltaTime;
	}
}
