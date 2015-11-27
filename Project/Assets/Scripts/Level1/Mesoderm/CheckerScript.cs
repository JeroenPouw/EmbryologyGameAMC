using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckerScript : MonoBehaviour {
	public static string direction;
	public string startDirection;

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
			switch (hit.transform.gameObject.name) {
			case "EndPipe":
				switch (Application.loadedLevelName) {
				case "Mesoderm 1":
					if (bonusPoints >= 1 && GameOver == false) {
						ScoreScript.score += 100;
						ScoreScript.score += bonusPoints;
						GameOver = true;
						Application.LoadLevel("Overworld");
					}
					break;
				case "Mesoderm 2":
					if (bonusPoints >= 2 && GameOver == false) {
						ScoreScript.score += 100;
						ScoreScript.score += bonusPoints;
						GameOver = true;
						Application.LoadLevel("Overworld");
					}
					break;
				case "Mesoderm 3":
					if (bonusPoints >= 3 && GameOver == false) {
						ScoreScript.score += 100;
						ScoreScript.score += bonusPoints;
						GameOver = true;
						Application.LoadLevel("Overworld");
					}
					break;
				}

			break;
			case "Organ":
				bonusPoints += 1;
				pipe.Cross();
				break;
			case "StartPipe":
			//	Debug.Log("start");
				direction = startDirection;
				pipe.StartPipe();
				break;
			case "LNorthWest":
				pipe.LNorthWest();
				break;
			case "LSouthEast":
				pipe.LSouthEast();
				break;
			case "LNorthEast":
				pipe.LNorthEast();
				break;
			case "LSouthWest":
				pipe.LSouthWest();
				break;
			case "StraightVert":
				pipe.StraightVert();
				break;
			case "StraightHor":
				pipe.StraightHor();
				break;
			case "TNorth":
				pipe.TNorth();
				break;
			case "TSouth":
				pipe.TSouth();
				break;
			case "TWest":
				pipe.TWest();
				break;
			case "TEast":
				pipe.TEast();
				break;
			case "Cross":
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
		//for (int i = 0; i < (MesoLists.PipeList.Count*2); i++) {
			Check ();
			yield return new WaitForSeconds(.5f);
		//}
	
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log (direction);
	}
}
