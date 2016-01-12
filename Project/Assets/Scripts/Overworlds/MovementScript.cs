using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	public float speed;
	public float maxSpeed;
	// Use this for initialization
	void Start () {

	}

	void FixedUpdate() {
		if (speed>maxSpeed) {
			float brakeSpeed = speed - maxSpeed;
			Vector3 normalisedVelocity = GetComponent<Rigidbody>().velocity.normalized;
			Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;

			GetComponent<Rigidbody>().AddForce(-brakeVelocity);
		}

		if (Input.GetKey(KeyCode.W)) {
			GetComponent<Rigidbody>().AddForce(transform.forward* speed);
		}
		if (Input.GetKey(KeyCode.S)) {
			GetComponent<Rigidbody>().AddForce(-transform.forward * speed);
		}
		if (Input.GetKey(KeyCode.D)) {
			//GetComponent<Rigidbody>().AddTorque(new Vector3(0,0,transform.rotation.z) * speed);
		}
		if (Input.GetKey(KeyCode.A)) {
			//GetComponent<Rigidbody>().AddForce(-transform.right * speed);
			//GetComponent<Rigidbody>().AddTorque(-transform.up * 50);
		}
		//GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(horRotSpeed * Input.GetAxis("Mouse X"), vertRotSpeed * Input.GetAxis("Mouse Y"), 0f));
		//GetComponent<Rigidbody> ().rotation.SetLookRotation (transform.forward);

	}
}
