using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	public float speed = 35.0f;
	float maxSpeed = 30.0f;
	// Use this for initialization
	void Start () {

	}

	void Update(){
//	RaycastHit hitForward = new RaycastHit();
//		if (Physics.Raycast (transform.position, -transform.up,out hitForward, 1.0f)) {
//			if (Vector3.Dot(Vector3.up,hitForward.normal)>0.7f) {
//				Vector3 newDir = Vector3.RotateTowards(transform.forward,Vector3.Dot(Vector3.up,hitForward.normal),speed,0.0f);
//			}
		//}
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

		//Debug.Log (GetComponent<Rigidbody>().velocity.magnitude);
	}
	// Update is called once per frame
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
			//GetComponent<Rigidbody>().AddForce(transform.right * speed);
			//GetComponent<Rigidbody>().AddTorque(transform.up * 50);
		}
		if (Input.GetKey(KeyCode.A)) {
			//GetComponent<Rigidbody>().AddForce(-transform.right * speed);
			//GetComponent<Rigidbody>().AddTorque(-transform.up * 50);
		}
		//GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(horRotSpeed * Input.GetAxis("Mouse X"), vertRotSpeed * Input.GetAxis("Mouse Y"), 0f));
		//GetComponent<Rigidbody> ().rotation.SetLookRotation (transform.forward);

	}
}
