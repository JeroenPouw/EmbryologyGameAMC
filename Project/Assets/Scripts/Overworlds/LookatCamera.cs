using UnityEngine;
using System.Collections;

public class LookatCamera : MonoBehaviour {
	public Transform mapCam;
	public float scalemultiplier;

	double timer = 0.0f;
	bool onoff = false;

	void Update () {
		if (mapCam.gameObject.activeSelf) {
			transform.LookAt (mapCam);
			this.transform.localScale = this.transform.localScale.normalized * Vector3.Distance(mapCam.transform.position,this.transform.position) * scalemultiplier;
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
