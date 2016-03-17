using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestUpdate : MonoBehaviour {

	public string title;
	public string message;

	void OnTriggerEnter(Collider _collider) {
		GameObject.Find ("GameUI").GetComponent<OverworldUI> ().TurnOnQuest ();
		GameObject.Find ("MissionDescription").GetComponent<Text> ().text = message;
		GameObject.Find ("MissionTitle").GetComponent<Text> ().text = title;
	}
}
