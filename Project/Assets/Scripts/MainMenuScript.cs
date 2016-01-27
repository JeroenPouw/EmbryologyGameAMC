using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	private SaveState save;

	void Start () {
		save = GameObject.Find ("SaveState").GetComponent<SaveState> ();
		if (save.loaded_data.lvl == 0) {
			GameObject.Find("ContinueButton").SetActive(false);
		}
	}

	public void ContinueGame () {
		if (save.loaded_data.lvl != 0) {

		}
	}

	public void LevelSwitch(int sceneToChangeTo){
		Application.LoadLevel(sceneToChangeTo);
	}

	public void CloseGame(){
		Application.Quit ();
	}

}
