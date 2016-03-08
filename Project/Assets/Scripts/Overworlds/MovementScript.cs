using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	public float speed;
	public float turnspeed;
	public float maxSpeed;
	private Rigidbody rigidref;
	// Use this for initialization
	void Start () {
		rigidref = GetComponent<Rigidbody> ();

	}

	void FixedUpdate() {
		if (speed>maxSpeed) {
			float brakeSpeed = speed - maxSpeed;
			Vector3 normalisedVelocity = rigidref.velocity.normalized;
			Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;

			rigidref.AddForce(-brakeVelocity);
		}

		if (Input.GetKey(KeyCode.W)) {
			rigidref.AddForce(transform.forward * speed);
		}
		if (Input.GetKey(KeyCode.S)) {
			rigidref.AddForce(-transform.forward * speed);
		}
		if (Input.GetKey(KeyCode.D)) {
			rigidref.AddTorque(transform.up * turnspeed);
		}
		if (Input.GetKey(KeyCode.A)) {
			rigidref.AddTorque(-transform.up * turnspeed);
		}
		if (Input.GetKey(KeyCode.Q)) {
			rigidref.AddTorque(transform.forward * turnspeed);
		}
		if (Input.GetKey(KeyCode.E)) {
			rigidref.AddTorque(-transform.forward * turnspeed);
		}
	}
}
