using UnityEngine;
using System.Collections;

public class Blinkscript : MonoBehaviour {
	double timer = 0.0f;
	bool onoff;
	// Use this for initialization
	void Awake () {

	}

	void indicator_Blink(){
	if (Time.time > timer) {Debug.Log ("we be blinking");
			Debug.Log ("we be blinking");
			timer = Time.time + .4;
			onoff = !onoff;
			this.gameObject.GetComponent<Renderer>().enabled = onoff;
		}
	}
	// Update is called once per frame
	void Update () {
		indicator_Blink ();
	}
}
