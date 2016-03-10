using UnityEngine;
using System.Collections;

public class StageCenterCamera : MonoBehaviour {

	public Transform stage8center;
	public Transform stage10center;
	public bool isonstage8 = false;

	private Vector3 prevmousepos = Vector3.zero;
	private Plane rotateYplane;

	void Start () {
		ChangeStage ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			prevmousepos = Input.mousePosition;
		}
		if (Input.GetMouseButton (0)) {
			if (isonstage8) {
				transform.RotateAround(stage8center.position, Vector3.up, -(prevmousepos.x - Input.mousePosition.x));
				rotateYplane = new Plane(stage8center.position, stage8center.position + Vector3.up, this.transform.position);
				transform.RotateAround(stage8center.position, rotateYplane.normal, -(prevmousepos.y - Input.mousePosition.y));
			} else {
				transform.RotateAround(stage10center.position, Vector3.up, -(prevmousepos.x - Input.mousePosition.x));
				rotateYplane = new Plane(stage10center.position, stage10center.position + Vector3.up, this.transform.position);
				transform.RotateAround(stage10center.position, rotateYplane.normal, -(prevmousepos.y - Input.mousePosition.y));
			}
			prevmousepos = Input.mousePosition;
		}
		if (Input.GetMouseButtonDown (1)) {
			prevmousepos = Input.mousePosition;
		}
		if (Input.GetMouseButton (1)) {
			this.transform.Translate(new Vector3(0f,0f,-(prevmousepos.y - Input.mousePosition.y)*2));
			prevmousepos = Input.mousePosition;
		}
	}

	public void ChangeStage () {
		isonstage8 = !isonstage8;
		if (isonstage8) {
			this.transform.position = new Vector3 (0, 0, -8500);
			this.GetComponent<Camera> ().farClipPlane = 2500;
		} else {
			this.transform.position = new Vector3 (0, 0, -8500);
			this.GetComponent<Camera> ().farClipPlane = 2500;
		}
	}
}
