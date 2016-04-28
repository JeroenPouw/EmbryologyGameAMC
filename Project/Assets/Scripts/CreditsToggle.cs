using UnityEngine;
using System.Collections;

public class CreditsToggle : MonoBehaviour {

	public GameObject[] textswitch;

	public void Toggle() {
		foreach (GameObject stuff in textswitch) {
			stuff.SetActive(!stuff.activeSelf);
		}
	}
}
