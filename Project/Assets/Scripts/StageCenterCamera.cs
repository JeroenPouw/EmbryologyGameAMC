using UnityEngine;
using System.Collections;

public class StageCenterCamera : MonoBehaviour {

	public Transform Stage8center;
	public float Stage8distance;
	public Transform Stage10center;
	public float Stage10distance;
	public bool isonstage8 = true;

	void Update () {
		if (isonstage8) {
			this.transform.rotation = Quaternion.LookRotation (Stage8center.position - this.transform.position, Vector3.up);
			this.GetComponent<Camera> ().farClipPlane = 2500;
			if (Vector3.Distance (Stage8center.position, this.transform.position) != Stage8distance) {
				this.transform.position = (Stage8center.position + this.transform.position).normalized * Stage8distance;
			}
		} else {
			this.transform.rotation = Quaternion.LookRotation (Stage10center.position- this.transform.position, Vector3.up);

			if (Vector3.Distance (Stage10center.position, this.transform.position) != Stage10distance) {
				this.transform.position = (Stage10center.position + this.transform.position).normalized * Stage10distance;
			}
		}


	}

	public void ChangeStage () {
		isonstage8 = !isonstage8;
	}
}
