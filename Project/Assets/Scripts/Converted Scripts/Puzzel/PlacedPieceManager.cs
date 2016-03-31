using UnityEngine;
using System.Collections;

public class PlacedPieceManager : MonoBehaviour {


	void Start () {
		string pieces = GameObject.Find ("SaveState").GetComponent<SaveState> ().loaded_data.puztrack;
		int i = 1;
		foreach (MeshRenderer render in GetComponentsInChildren<MeshRenderer>()) {
			if (pieces.Substring(pieces.IndexOf(i.ToString()+1,1)) == "p") {
				render.enabled = true;
			}
			i++;
		}
	}
}
