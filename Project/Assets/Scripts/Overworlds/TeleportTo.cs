using UnityEngine;
using System.Collections;

public class TeleportTo : MonoBehaviour {

	public Transform teletarget;

	void OnTriggerEnter(Collider _other) {
		if (_other.name == "Player") {
			_other.transform.position = teletarget.position;
		}
	}
}
