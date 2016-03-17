using UnityEngine;
using System.Collections;

public class StageCenterCamera : MonoBehaviour {

	public Transform stage8center;
	public Transform stage10center;

	private bool isonstage8;
	private Vector3 prevmousepos = Vector3.zero;
	private Plane rotateYplane;

	void Start () {
		ChangeStage (isonstage8);
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
			}
			if (!isonstage8) {
				transform.RotateAround(stage10center.position, Vector3.up, -(prevmousepos.x - Input.mousePosition.x));
				rotateYplane = new Plane(stage10center.position, stage10center.position + Vector3.up, this.transform.position);
				transform.RotateAround(stage10center.position, rotateYplane.normal, -(prevmousepos.y - Input.mousePosition.y));
			}
			prevmousepos = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp (0)) {
			rotateYplane = new Plane();
		}
		if (Input.GetMouseButtonDown (1)) {
			prevmousepos = Input.mousePosition;
		}
		if (Input.GetMouseButton (1)) {
			this.transform.Translate(new Vector3(0f,0f,-(prevmousepos.y - Input.mousePosition.y)*2));
			prevmousepos = Input.mousePosition;
		}
	}

	public void ChangeStage (bool _stage8) {
		isonstage8 = _stage8;
		if (isonstage8) {
			this.transform.position = new Vector3 (0, 0, -28500);
			this.transform.rotation = new Quaternion (0f,180f,0f,1f);
			this.GetComponent<Camera> ().farClipPlane = 2500;
		}
		if (!isonstage8) {
			this.transform.position = new Vector3 (0, 0, 15000);
			this.transform.rotation = new Quaternion (0f,180f,0f,1f);
			this.GetComponent<Camera> ().farClipPlane = 20000;
		}
	}

	public void ChangeStage (int _stage) {
		if (_stage == 8 && !isonstage8) {
			ChangeStage(true);
		}
		if (_stage == 10 && isonstage8) {
			ChangeStage(false);
		}
	}

	void OnEnable () {
		ChangeStage (GameObject.Find ("Player").GetComponent<PlayerAttributeAdjustment> ().Stage);
	}

	void OnDisable () {

	}
}
