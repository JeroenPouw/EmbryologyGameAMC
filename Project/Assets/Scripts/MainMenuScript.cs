using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public void LevelSwitch(int sceneToChangeTo){
		Application.LoadLevel(sceneToChangeTo);
	}

}
