using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestUpdate : MonoBehaviour {

	public string title;
	public string message;
	public bool spawnpoint;
	public bool isstage8;
	public int orderlocation;

	void OnTriggerEnter(Collider _collider) {
		GameObject.Find ("GameUI").GetComponent<OverworldUI> ().TurnOnQuest ();
		GameObject.Find ("MissionDescription").GetComponent<Text> ().text = message;
		GameObject.Find ("MissionTitle").GetComponent<Text> ().text = title;
		GameObject.Find ("SaveState").GetComponent<SaveState> ().SaveVariable (orderlocation, 0, "");
	}
}
