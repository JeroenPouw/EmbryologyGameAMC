using UnityEngine;
using System.Collections;

public class PlayerAttributeAdjustment : MonoBehaviour {

	public Transform stage8spawn;
	public Transform stage10spawn;

	public Vector3 stage8scale;
	public Vector3 stage10scale;

	private MovementScript moveref;
	private int stage;

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
			GetComponent<Rigidbody> ().mass = 2;
			this.transform.position = stage8spawn.position;
			ChangeScale (_stage);
		}
		if (_stage == 10) {
			GetComponent<Rigidbody> ().mass = 1;
			this.transform.position = stage10spawn.position;
			ChangeScale (_stage);
		}
	}




	public int Stage {
		get {
			return stage;
		}
		set {
			stage = value;
		}
	}
}
