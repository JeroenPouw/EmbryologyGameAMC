using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestUpdate : MonoBehaviour {

	public string title;
	public string message;
	public bool bigupdate;
	public bool spawnpoint;
	public bool isstage8;
	public int orderlocation;

	void OnTriggerEnter(Collider _collider) {
		if (bigupdate) {
			GameObject.Find ("GameUI").GetComponent<OverworldUI> ().TurnOnBigQuest (message, title);
			_collider.GetComponent<MouseTorque>().enabled = false;
			_collider.GetComponent<MovementScript>().enabled = false;
		} else {
			GameObject.Find ("GameUI").GetComponent<OverworldUI> ().TurnOnQuest (message, title);

		}
		GameObject.Find ("SaveState").GetComponent<SaveState> ().SaveVariable (orderlocation, 0, "");
	}
}
