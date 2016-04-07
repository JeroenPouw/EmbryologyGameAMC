using UnityEngine;
using System.Collections;

public class TriggerLevelLoader : MonoBehaviour {

	public int levelinteger;

	void OnTriggerEnter (Collider _other) {
		if (_other.name.Contains("Player")) {
			Application.LoadLevel(levelinteger);
		}
	}
}
