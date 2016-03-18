using UnityEngine;
using System.Collections;

public class OverworldGameMenu : MonoBehaviour {

	public Transform player;

	private PlayerAttributeAdjustment playeratt;
	private int stageselect = 8;
	
	void Start () {
		playeratt = player.GetComponent<PlayerAttributeAdjustment> ();
	}

	public void Stage8Press () {
		stageselect = 8;
	}

	public void Stage10Press () {
		stageselect = 10;
	}

	public void Stage13Press () {
		Application.LoadLevel ("Puzzel");
	}
	/*
	public void Encyclopedia () {

	}*/

	public void ConfirmStage () {
		if (stageselect != 0) {
			playeratt.ChangeStage (stageselect);
			playeratt.ChangeScale (stageselect);
			playeratt.Stage = stageselect;
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
