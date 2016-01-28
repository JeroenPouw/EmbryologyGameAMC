using UnityEngine;
using System.Collections;

public class FloatPlayerControl : MonoBehaviour {

	public float speed;
	public float speedlimit;
	public float angularspeed;
	public float angularspeedlimit;

	private Rigidbody2D rb2;

	void Start () {
		rb2 = GetComponent<Rigidbody2D>();
	}

	void Update () {

	}

	void FixedUpdate() {
		if (Input.GetKey (KeyCode.RightArrow)) {
			rb2.AddTorque (-1f * angularspeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rb2.AddTorque (1f * angularspeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			rb2.AddRelativeForce (Vector2.up * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			rb2.AddRelativeForce (-Vector2.up * 0.5f * speed * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.D)) {
			rb2.AddTorque (-1f * angularspeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			rb2.AddTorque (1f * angularspeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.W)) {
			rb2.AddRelativeForce (Vector2.up * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) {
			rb2.AddRelativeForce (-Vector2.up * 0.5f * speed * Time.deltaTime);
		}
		
		if (rb2.angularVelocity > angularspeedlimit) {
			rb2.angularVelocity = angularspeedlimit;
		}
		if (rb2.angularVelocity < -angularspeedlimit) {
			rb2.angularVelocity = -angularspeedlimit;
		}

		if (rb2.velocity.magnitude > speedlimit) {
			rb2.velocity = rb2.velocity.normalized * speedlimit;
		}
		if (rb2.velocity.magnitude < -speedlimit) {
			rb2.velocity = -(rb2.velocity.normalized * speedlimit);
		}
	}



}
