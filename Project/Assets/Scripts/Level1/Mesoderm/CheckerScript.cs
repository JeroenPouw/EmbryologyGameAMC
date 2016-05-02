using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckerScript : MonoBehaviour {
	public static string direction;
	public string startDirection;

	public static int placedpipes;
	public static int bonusPoints;

	RaycastHit hit;
	
	bool GameOver;

	GameObject controller;
	MesoPipeCases pipe;
	// Use this for initialization
	void Start () {
		controller = GameObject.Find ("GameScripts");
		pipe = controller.GetComponent<MesoPipeCases> ();
	}

	void Check(){
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			Debug.Log("Checking this " + hit.transform.gameObject.name);

			switch (hit.transform.gameObject.name) {
			case "EndPipe":
				switch (Application.loadedLevelName) {
				case "Mesoderm 1":
					if (bonusPoints >= 1 && GameOver == false) {
						ScoreScript.score += 100;
						ScoreScript.score += bonusPoints;
						GameOver = true;
						GameObject.Find("SaveState").GetComponent<SaveState>().SaveVariable(GameObject.Find("SaveState").GetComponent<SaveState>().loaded_data.lvl+1,0,"");
						Application.LoadLevel(2);
					}
					break;
				case "Mesoderm 2":
					if (bonusPoints >= 2 && GameOver == false) {
						ScoreScript.score += 100;
						ScoreScript.score += bonusPoints;
						GameOver = true;
						GameObject.Find("SaveState").GetComponent<SaveState>().SaveVariable(GameObject.Find("SaveState").GetComponent<SaveState>().loaded_data.lvl+1,0,"");
						Application.LoadLevel(2);
					}
					break;
				case "Mesoderm 3":
					if (bonusPoints >= 3 && GameOver == false) {
						ScoreScript.score += 100;
						ScoreScript.score += bonusPoints;
						GameOver = true;
						GameObject.Find("SaveState").GetComponent<SaveState>().SaveVariable(GameObject.Find("SaveState").GetComponent<SaveState>().loaded_data.lvl+1,0,"");
						Application.LoadLevel(2);
					}
					break;
				}

			break;
			case "Organ":
				Debug.Log("HitOrgan");
				bonusPoints += 1;
				placedpipes++;
				pipe.Cross();
				break;
			case "StartPipe":
				Debug.Log("start");
				direction = startDirection;
				pipe.StartPipe();
				break;
			case "LNorthWest":
				Debug.Log("NorthWest");
				pipe.LNorthWest();
				break;
			case "LSouthEast":
				Debug.Log("SouthEast");
				pipe.LSouthEast();
				break;
			case "LNorthEast":
				Debug.Log("NorthEast");
				pipe.LNorthEast();
				break;
			case "LSouthWest":
				Debug.Log("SouthWest");
				pipe.LSouthWest();
				break;
			case "StraightVert":
				Debug.Log("StraightVertical");
				pipe.StraightVert();
				break;
			case "StraightHor":
				Debug.Log("StraightHorizontal");
				pipe.StraightHor();
				break;
			case "TNorth":
				Debug.Log("North?");
				pipe.TNorth();
				break;
			case "TSouth":
				Debug.Log("South?");
				pipe.TSouth();
				break;
			case "TWest":
				Debug.Log("West?");
				pipe.TWest();
				break;
			case "TEast":
				Debug.Log("East?");
				pipe.TEast();
				break;
			case "Cross":
				Debug.Log("Cross!");
				pipe.Cross();
				break;
			}
		}
		MesoPipeCases.Nempty = false;
		MesoPipeCases.Sempty = false;
		MesoPipeCases.Eempty = false;
		MesoPipeCases.Wempty = false;
	}
	
	public IEnumerator Solving(){
		for (int i = 0; i < placedpipes+2; i++) {
			Check ();
			Debug.Log((i+1) + "/" + (placedpipes+2));
			yield return new WaitForSeconds(0.5f);
		}
	}

	void Update () {
		//Debug.Log (direction);
	}
}
