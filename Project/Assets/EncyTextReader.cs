using UnityEngine;
using System.Collections;

public class EncyTextReader : MonoBehaviour {

	// Use this for initialization
//	var savestate : SaveState;
	//public SaveState save;

	void Start () {
		GetSaveState ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GetSaveState () {

		Debug.Log(SaveState.loaded_data.puztrack + " Got Save");
	}
}
