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

	public void ContinueGame (int sceneToChangeTo) {
		if (save.loaded_data.lvl != 0) {
			Application.LoadLevel(sceneToChangeTo);
		}
	}

	public void NewGame(int sceneToChangeTo){
		save.ResetFile ();
		Application.LoadLevel(sceneToChangeTo);
	}

	public void CloseGame(){
		Application.Quit ();
	}

}
