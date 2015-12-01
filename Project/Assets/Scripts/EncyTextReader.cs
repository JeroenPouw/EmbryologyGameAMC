using UnityEngine;
using System.Collections;

public class EncyTextReader : MonoBehaviour {

	private SaveState save;

	void Start () {
		GameObject go = GameObject.Find("SaveState");
		save = go.GetComponent<SaveState> ();

		GetSaveState ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GetSaveState () {
		Debug.Log(save.loaded_data.puztrack + " Got Save");
	}
}
