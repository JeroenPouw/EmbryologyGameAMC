using UnityEngine;
using System.Collections;

public class OverworldGameMenu : MonoBehaviour {

	public Transform player;

	private PlayerAttributeAdjustment playeratt;
	private int stageselect = 0;
	
	void Start () {
		playeratt = player.GetComponent<PlayerAttributeAdjustment> ();
	}

	public void Stage8Press () {
		Debug.Log ("8");
		stageselect = 8;
	}

	public void Stage10Press () {
		Debug.Log ("10");
		stageselect = 10;
	}

	public void Stage13Press () {

	}
	/*
	public void Encyclopedia () {

	}*/

	public void ConfirmStage () {
		Debug.Log ("confirmed");
		if (stageselect != 0) {
			playeratt.ChangeStage (stageselect);
			playeratt.ChangeScale (stageselect);
			this.gameObject.SetActive (!this.gameObject.activeSelf);
		}
	}
	/*
	public void PuzzleInventoryButton () {

	}*/

	void OnEnable() {
		player.gameObject.SetActive (false);
	}

	void OnDisable () {
		player.gameObject.SetActive (true);
	}
}
