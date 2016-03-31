using UnityEngine;
using System.Collections;

public class PlacedPieceManager : MonoBehaviour {
	
	void Start () {
		int i = 1;
		foreach (MeshRenderer render in GetComponentsInChildren<MeshRenderer>()) {
			if (i <= 15)
			if (GameObject.Find ("SaveState").GetComponent<SaveState> ().GetPuzzleStatus(i) == "p") {
				render.enabled = true;
			}
			i++;
		}
	}
}
