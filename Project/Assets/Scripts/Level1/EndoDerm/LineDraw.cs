using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineDraw : MonoBehaviour {
	Ray ray;
	RaycastHit hit;
	public Camera camera;
	LineRenderer linerender;
	int numberofpoints = 0;
	Vector3 lineStart = new Vector3(0,0,0);
	Vector3 lineEnd = new Vector3(0,0,0);

	string startString = "start";
	string endString = "end";
	// Use this for initialization
	void Start () {
		linerender = GetComponent<LineRenderer> ();
		linerender.SetVertexCount(numberofpoints);
		linerender.SetWidth (0.05f, 0.05f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Mouse0)) {
			numberofpoints++;	
			linerender.SetVertexCount (numberofpoints);
			Vector3 mousePos = new Vector3 (0, 0, 0);
			mousePos = Input.mousePosition;
			mousePos.z = 1.0f;
			Vector3 worldPos = new Vector3 ();
			worldPos = camera.ScreenToWorldPoint (mousePos);
			linerender.SetPosition (numberofpoints - 1, worldPos);
		} else {
			numberofpoints = 0;
			linerender.SetVertexCount(numberofpoints);
		}
		//Debug.Log (startString);
		if (Input.GetKey(KeyCode.Mouse0)) {
			ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray,out hit)) {
				Debug.Log(hit.transform.tag);
				startString = hit.transform.tag;
			}
			if (hit.transform != null) {
				if (hit.transform.tag == "Lava") {
					numberofpoints = 0;
					linerender.SetVertexCount(numberofpoints);
				}
			}

		}
		if (Input.GetKeyUp(KeyCode.Mouse0)) {
			ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray,out hit)) {
				Debug.Log(hit.point);
				endString = hit.transform.tag;
				if (startString == endString) {
					Debug.Log("Succes");
				}else{
					Debug.Log("failure");
					startString = "start";
					endString = "end";
				}
			}
		}

//		if( Input.GetKey( KeyCode.Mouse0 ) ) {
//			numberOfPoints++;
//			lineRender.SetVertexCount( numberOfPoints );
//			var mousePos : Vector3 = new Vector3(0,0,0);
//			mousePos = Input.mousePosition;
//			mousePos.z = 1.0f;
//			var worldPos : Vector3 = camera.ScreenToWorldPoint(mousePos);
//			lineRender.SetPosition(numberOfPoints - 1, worldPos);
//		} else {
//			numberOfPoints = 0;
//			lineRender.SetVertexCount(0);
//		}

	}
}
