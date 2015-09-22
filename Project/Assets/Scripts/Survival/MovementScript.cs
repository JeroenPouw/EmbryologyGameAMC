using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	public float speed = 7.0f;
	float maxSpeed = 6.0f;
	float disttoGround;
	public bool isGrounded;
	// Use this for initialization
	void Start () {
		disttoGround = GetComponent<Collider> ().bounds.extents.y;

	}

	void Update(){
	RaycastHit hitForward = new RaycastHit();
		if (Physics.Raycast (transform.position, -transform.up, disttoGround + 0.1f)) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}
//		if (Input.GetKey(KeyCode.W) && isGrounded == true) {
//			//GetComponent<Rigidbody>().AddForce(transform.forward * speed);
//			transform.Translate(transform.forward * 3 * Time.deltaTime);
//		}
//		if (Input.GetKey(KeyCode.S) && isGrounded == true) {
//			//GetComponent<Rigidbody>().AddForce(-transform.forward * speed);
//			transform.Translate(-transform.forward * 3 * Time.deltaTime);
//		}
//		if (Input.GetKey(KeyCode.D) && isGrounded == true ) {
//			//GetComponent<Rigidbody>().AddForce(transform.right * speed);
//			transform.Translate(transform.right * 3 * Time.deltaTime);
//		}
//		if (Input.GetKey(KeyCode.A)&& isGrounded == true) {
//			//GetComponent<Rigidbody>().AddForce(-transform.right * speed);
//			transform.Translate(-transform.right * 3	 * Time.deltaTime);
//		}

		Debug.Log (GetComponent<Rigidbody>().velocity.magnitude);
	}
	// Update is called once per frame
	void FixedUpdate() {
		if (speed>maxSpeed) {
			float brakeSpeed = speed - maxSpeed;
			Vector3 normalisedVelocity = GetComponent<Rigidbody>().velocity.normalized;
			Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;

			GetComponent<Rigidbody>().AddForce(-brakeVelocity);
		}

		if (Input.GetKey(KeyCode.W) && isGrounded == true) {
			GetComponent<Rigidbody>().AddForce(transform.forward * speed);
		}
		if (Input.GetKey(KeyCode.S) && isGrounded == true) {
			GetComponent<Rigidbody>().AddForce(-transform.forward * speed);
		}
		if (Input.GetKey(KeyCode.D) && isGrounded == true ) {
			GetComponent<Rigidbody>().AddForce(transform.right * speed);
		}
		if (Input.GetKey(KeyCode.A)&& isGrounded == true) {
			GetComponent<Rigidbody>().AddForce(-transform.right * speed);
		}

	}
}
