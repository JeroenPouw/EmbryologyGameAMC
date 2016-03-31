using UnityEngine;
using System.Collections;

public class LookatCamera : MonoBehaviour {
	public Transform mapCam;

	double timer = 0.0f;
	bool onoff = false;

	void Update () {
		if (mapCam.gameObject.activeSelf) {
			transform.LookAt (mapCam);
			IndicatorBlink ();
		} else {
			this.gameObject.GetComponent<Renderer>().enabled = false;
		}
	}

	void IndicatorBlink(){
		if (Time.time > timer) {
			timer = Time.time + .4;
			onoff = !onoff;
			this.gameObject.GetComponent<Renderer>().enabled = onoff;
		}
	}
}
