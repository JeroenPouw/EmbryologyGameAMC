using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OverworldUI : MonoBehaviour {

	public Text questtext;
	public Transform[] components;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape)
		    && !components[2].gameObject.activeSelf) {
			components[1].gameObject.SetActive(!components[1].gameObject.activeSelf);
			components[0].gameObject.SetActive(!components[1].gameObject.activeSelf);
		}
		if (!components [1].gameObject.activeSelf) {
			components[0].gameObject.SetActive(!components[1].gameObject.activeSelf);
		}
	}

	public void TurnOnQuest (string _message, string _title) {
		components [3].gameObject.SetActive (true);
		components [3].FindChild("MissionDescription").GetComponent<Text> ().text = _message;
		components [3].FindChild("MissionTitle").GetComponent<Text> ().text = _title;
	}

	public void TurnOnBigQuest (string _message, string _title) {
		components [4].gameObject.SetActive (true);
		components [4].FindChild("MissionDescription").GetComponent<Text> ().text = _message;
		components [4].FindChild("MissionTitle").GetComponent<Text> ().text = _title;
	}

	public void ReturnToMainMenu () {
		Application.LoadLevel (0);
	}
}
