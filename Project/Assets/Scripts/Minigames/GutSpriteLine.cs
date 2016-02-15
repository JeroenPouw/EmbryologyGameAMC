using UnityEngine;
using System.Collections;

public class GutSpriteLine : MonoBehaviour {

	public Transform point1;
	public Transform point2;

	private Vector3 start;
	private LineRenderer line;

	void Start () {
		start = this.transform.position;
		line = this.GetComponent<LineRenderer> ();
		line.enabled = false;
	}

	void Update () {
		if (line.enabled) {
			line.SetPosition (0, point1.position);
			line.SetPosition (1, point2.position);
		}
	}

	public void SetLine (Transform _transform1, Transform _transform2) {
		point1 = _transform1;
		point2 = _transform2;
		line.enabled = true;
	}

	public void DropLine () {
		line.enabled = false;
	}
}
