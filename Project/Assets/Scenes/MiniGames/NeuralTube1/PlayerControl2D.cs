using UnityEngine;
using System.Collections;

public class PlayerControl2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.Translate(new Vector3(0.5f,0f,0f)*Time.deltaTime);
		}
	}
}
