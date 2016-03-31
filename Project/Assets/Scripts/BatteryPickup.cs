using UnityEngine;
using System.Collections;

public class BatteryPickup : MonoBehaviour {

	public bool destroyoncollide;

	void OnTriggerEnter(Collider _collision) {
		_collision.GetComponent<Fuel> ().Refuel ();
		if (destroyoncollide) {
			this.gameObject.SetActive(false);
		}
	}
}
