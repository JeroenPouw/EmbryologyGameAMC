using UnityEngine;
using System.Collections;

public class GutFollowPlayer : MonoBehaviour {
	
	public float speed;
	public float distance;
	private int status = 2;
	private Transform destination;

	void Update () {
		if (destination != null) {
			if ((destination.position - this.transform.position).magnitude*distance < speed * Time.deltaTime) {
				if (status == 0) {
					this.transform.position = destination.position;
					destination = null;
				}
			} else {
				this.transform.Translate ((destination.position - this.transform.position).normalized * speed * Time.deltaTime);
			}
		}
	}

	public void SetDestination (Transform _destination, int _status) {
		if (status > 0) {
			destination = _destination;
		}
		status = _status;
	}
}
