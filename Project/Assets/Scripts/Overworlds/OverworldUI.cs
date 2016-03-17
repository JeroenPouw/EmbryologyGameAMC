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

	public void ClickedCompass () {
	//	switch camera
	}

	public void TurnOnQuest () {
		components [3].gameObject.SetActive (true);
	}

	public void ReturnToMainMenu () {
		Application.LoadLevel (0);
	}
}
