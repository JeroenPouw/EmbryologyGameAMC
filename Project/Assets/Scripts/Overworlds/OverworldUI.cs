using UnityEngine;
using System.Collections;

public class OverworldUI : MonoBehaviour {

	public Transform[] components;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			components[1].gameObject.SetActive(!components[1].gameObject.activeSelf);
		}
	}

	public void ClickedCompass () {
		Debug.Log ("yay, button works on compass");
	}
}
