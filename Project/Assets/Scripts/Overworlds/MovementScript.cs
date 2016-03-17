using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	public float speed;
	public float turnspeed;
	public float maxspeed;
	public float penalizedmaxspeed;
	private float currentmaxspeed;
	private Rigidbody rigidref;

	void Start () {
		rigidref = GetComponent<Rigidbody> ();
		RestoreMaxSpeed ();
	}

	void FixedUpdate() {
		if (speed>currentmaxspeed && speed < 1f) {
			float brakeSpeed = speed - currentmaxspeed;
			Vector3 brakeVelocity = rigidref.velocity.normalized * brakeSpeed;

			rigidref.AddForce(-brakeVelocity);
		}

		if (Input.GetKey(KeyCode.W)) {
			rigidref.AddForce(transform.forward * speed);
			GetComponent<Fuel>().ConsumeFuel();
		}
		if (Input.GetKey(KeyCode.S)) {
			rigidref.AddForce(-transform.forward * speed);
			GetComponent<Fuel>().ConsumeFuel();
		}
		if (Input.GetKey(KeyCode.D)) {
			rigidref.AddTorque(transform.up * turnspeed);
			GetComponent<Fuel>().ConsumeFuel();
		}
		if (Input.GetKey(KeyCode.A)) {
			rigidref.AddTorque(-transform.up * turnspeed);
			GetComponent<Fuel>().ConsumeFuel();
		}
		if (Input.GetKey(KeyCode.Q)) {
			rigidref.AddTorque(transform.forward * turnspeed);
		}
		if (Input.GetKey(KeyCode.E)) {
			rigidref.AddTorque(-transform.forward * turnspeed);
		}
	}

	public void PenalizeMaxSpeed () {
		currentmaxspeed = penalizedmaxspeed;
	}

	public void RestoreMaxSpeed () {
		currentmaxspeed = maxspeed;
	}
}
