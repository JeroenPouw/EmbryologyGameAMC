using UnityEngine;
using System.Collections;

public class Blinkscript : MonoBehaviour {
	double timer = 0.0f;
	bool onoff;

	void Awake () {

	}

	void indicator_Blink(){
		if (Time.time > timer) {
			timer = Time.time + .4;
			onoff = !onoff;
			this.gameObject.GetComponent<Renderer>().enabled = onoff;
		}
	}

	void Update () {
		indicator_Blink ();
	}
}
