using UnityEngine;
using System.Collections;

public class PlayerControl2D : MonoBehaviour {

	public bool opposite = false;
	public float speed;

	private Vector3 destination;

	void Start () {
		
	}

	void Update () {
		if (!opposite) {
			if (Input.GetKey (KeyCode.RightArrow)) {
				destination += new Vector3(1f,0f);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				destination += new Vector3(-1f,0f);
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				destination += new Vector3(0f,1f);
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				destination += new Vector3(0f,-1f);
			}
		} else {
			if (Input.GetKey (KeyCode.RightArrow)) {
				destination += new Vector3(-1f,0f);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				destination += new Vector3(1f,0f);
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				destination += new Vector3(0f,-1f);
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				destination += new Vector3(0f,1f);
			}
		}
		this.transform.Translate (destination.normalized * speed * Time.deltaTime);
		destination = Vector3.zero;
	}
}
