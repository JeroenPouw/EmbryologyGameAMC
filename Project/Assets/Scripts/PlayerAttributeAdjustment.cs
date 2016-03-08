using UnityEngine;
using System.Collections;

public class PlayerAttributeAdjustment : MonoBehaviour {

	public Transform stage8spawn;
	public Transform stage10spawn;

	public Vector3 stage8scale;
	public Vector3 stage10scale;

	private MovementScript moveref;

	void Start () {
		moveref = this.GetComponent<MovementScript> ();
	}

	public void ChangeScale(int _stage) {
		if (_stage == 8) {
			this.transform.localScale = stage8scale;
		}
		if (_stage == 10) {
			this.transform.localScale = stage10scale;
		}
	}

	public void ChangeStage(int _stage) {
		if (_stage == 8) {
			this.transform.position = stage8spawn.position;
			ChangeScale (_stage);
		}
		if (_stage == 10) {
			this.transform.position = stage10spawn.position;
			ChangeScale (_stage);
		}
	}




}
