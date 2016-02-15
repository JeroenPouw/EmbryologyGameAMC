using UnityEngine;
using System.Collections;

public class GutGameHoldBlob : MonoBehaviour {

	private Transform blob;

	void OnTriggerEnter2D (Collider2D _collision) {
		if (_collision.name == "Blob" && blob == null) {
			blob = _collision.transform;
			_collision.transform.GetComponent<GutFollowPlayer> ().SetDestination(this.transform, 1);
		}
		if (_collision.name == "Goal" && blob != null) {
			blob.transform.GetComponent<GutFollowPlayer> ().SetDestination(_collision.transform, 0);
			blob = null;
		}
	}
	
	public void Teleport () {
		if (blob != null) {
			blob.transform.position = -blob.transform.position;
		}
	}
}
