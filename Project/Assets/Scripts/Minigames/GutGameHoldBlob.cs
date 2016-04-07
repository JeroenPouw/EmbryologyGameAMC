using UnityEngine;
using System.Collections;

public class GutGameHoldBlob : MonoBehaviour {

	public GutMap mapref;
	private Transform blob;

	void OnTriggerEnter2D (Collider2D _collision) {
		if (_collision.name.Contains("Blob") && blob == null) {
			blob = _collision.transform;
			_collision.transform.GetComponent<GutFollowPlayer> ().SetDestination(this.transform, 1);
		}
		if (_collision.name.Contains("Goal") && blob != null) {
			blob.transform.GetComponent<GutFollowPlayer> ().SetDestination(_collision.transform, 0);
			blob = null;
			mapref.points--;
			if (mapref.points >= 0) {
				GameObject.Find("SaveState").GetComponent<SaveState>().SaveVariable(GameObject.Find("SaveState").GetComponent<SaveState>().loaded_data.lvl+1,0,"");
				Application.LoadLevel(2);
			}
		}
	}
	
	public void Teleport () {
		if (blob != null) {
			blob.transform.position = -blob.transform.position;
		}
	}
}
