using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	private SaveState save;

	void Start () {
		save = GameObject.Find ("SaveState").GetComponent<SaveState> ();
	}

	public void ContinueGame () {

	}

	public void LevelSwitch(int sceneToChangeTo){
		Application.LoadLevel(sceneToChangeTo);
	}

	public void CloseGame(){
		Application.Quit ();
	}

}
