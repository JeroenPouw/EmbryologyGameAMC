using UnityEngine;
using System.Collections;

public class Gameover : MonoBehaviour {
	float timer;
	// Use this for initialization
	void Start () {
	
	}

	void GameOver(){
		Application.LoadLevel ("Overworld");
	}
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 4f) {
			//end game
			GameOver();
		}
	}
}
