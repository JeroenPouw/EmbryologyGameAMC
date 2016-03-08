using UnityEngine;
using System.Collections;

public class OverworldGameMenu : MonoBehaviour {

	public Transform player;

	public Transform stage8spawn;
	public Transform stage10spawn;

	void Start () {
	
	}

	public void Stage8Press () {
		Debug.Log ("registered");
		player.position = stage8spawn.position;
	}

	public void Stage10Press () {
		Debug.Log ("registered");
		player.position = stage10spawn.position;
	}

	public void Stage13Press () {

	}
	/*
	public void Encyclopedia () {

	}*/

	public void ConfirmStage () {

	}
	/*
	public void PuzzleInventoryButton () {

	}*/
	
}
