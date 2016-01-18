using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	GameObject shipUI;
	bool gamePaused = false;
	GameObject player;

	void Start(){
		player = GameObject.Find ("Player(Clone)");
		shipUI = GameObject.Find ("ShipUIFunc");
		if (shipUI != null) {
			shipUI.SetActive (false);
		}
	}	
	void PauseGame(){
		if (!gamePaused) {
			player.SetActive(false);
			gamePaused = true;
			shipUI.SetActive(true);
		}else if (gamePaused) {
			player.SetActive(true);
			gamePaused = false;
			shipUI.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape)) {
				PauseGame();
			}
		if (player == null) {
			player = GameObject.Find ("Player(Clone)");
		}
	}
}
