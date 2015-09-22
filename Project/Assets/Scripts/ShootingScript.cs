using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {
	public Rigidbody bullet;
	public float speed = 10f;
	public Vector3 bulletVelocity;
	// Use this for initialization
	void Start () {
	
	}

	void FireFunction(){
		Rigidbody bulletClone = (Rigidbody)Instantiate (bullet, transform.position + transform.forward, transform.rotation);
		bulletVelocity = transform.forward * speed;
		bulletClone.velocity = bulletVelocity;

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			FireFunction();
				}
	}
}
