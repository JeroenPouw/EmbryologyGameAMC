using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour {

	private int stage = 8;

	void Start () {

	}

	void Update () {
		if (stage == 8) {
			this.transform.rotation = Quaternion.LookRotation (Vector3.up, Vector3.forward);
		}
		if (stage == 10) {

		}
	}

	public void ChangeStage (int _stage) {
		stage = _stage;
	}
}
