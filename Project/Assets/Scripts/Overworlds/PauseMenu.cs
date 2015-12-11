using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	GameObject shipUI;
	bool gamePaused = false;

	void Awake(){
		shipUI = GameObject.Find ("ShipUIFunc");
		if (shipUI != null) {
			shipUI.SetActive (false);
		}
	}
	void PauseGame(){
		if (!gamePaused) {
			Time.timeScale = 0;
			gamePaused = true;
			shipUI.SetActive(true);
		}else if (gamePaused) {
			Time.timeScale = 1;
			gamePaused = false;
			shipUI.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update () {
	if (Input.GetKeyUp(KeyCode.Escape)) {
			PauseGame();
		}
	}
}
