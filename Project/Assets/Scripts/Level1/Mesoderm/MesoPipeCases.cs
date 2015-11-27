using UnityEngine;
using System.Collections;

public class MesoPipeCases : MonoBehaviour {
	float distance = 1.1f;
	GameObject tempHitObj;
	GameObject checker;
	public static bool Nempty;
	public static bool Sempty;
	public static bool Eempty;
	public static bool Wempty;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		checker = GameObject.Find ("Checker");
	}

	public void StartPipe(){
	if (CheckerScript.direction == "S" || CheckerScript.direction == "N") {
			StraightVert();
		}
		if (CheckerScript.direction == "E" || CheckerScript.direction == "W") {
			StraightHor();
		}
	}
	public void LNorthWest(){
		if (CheckerScript.direction == "S") {
			GoWest();
			if (Wempty == true) {
				GoNorth();
			}
		}
		if (CheckerScript.direction == "E") {
			GoNorth();
			if (Nempty == true) {
				GoWest();
			}
		}
	}
	public void LNorthEast(){
		if (CheckerScript.direction == "S") {
			GoEast();
			if (Eempty == true) {
				GoNorth();
			}
		}
		if (CheckerScript.direction == "W") {
			GoNorth();
			if (Nempty == true) {
				GoEast();
			}
		}
	}
	public void LSouthEast(){
		if (CheckerScript.direction == "W") {
			GoSouth();
			if (Sempty == true) {
				GoEast();
			}
		}
		if (CheckerScript.direction == "N") {
			GoEast();
			if (Eempty == true) {
				GoSouth();
			}
		}
	}
	public void LSouthWest(){
		if (CheckerScript.direction == "E") {
			GoSouth();
			if (Sempty == true) {
				GoWest();
			}
		}
		if (CheckerScript.direction == "N") {
			GoWest();
			if (Wempty == true) {
				GoSouth();
			}
		}
	}
	public void StraightVert(){
		if (CheckerScript.direction == "S") {
			GoSouth();
			if (Sempty == true) {
				GoNorth();
			}
		}
		if (CheckerScript.direction == "N") {
			GoNorth();
			if (Nempty == true) {
				GoSouth();
			}
		}
	}
	public void StraightHor(){
		if (CheckerScript.direction == "W") {
			GoWest();
			if (Wempty == true) {
				GoEast();
			}
		}
		if (CheckerScript.direction == "E") {
			GoEast();
			if (Eempty == true) {
				GoWest();
			}
		}
	}
	public void TNorth(){
		if (CheckerScript.direction == "E") {
			GoEast();
			if (Eempty == true) {
				GoNorth();
				if (Eempty == true && Nempty == true) {
					GoWest();
				}
			}
		}
		if (CheckerScript.direction == "S") {
			GoWest();
			if (Wempty == true) {
				GoEast();
				if (Wempty == true && Eempty == true) {
					GoNorth();
				}
			}
		}
		if (CheckerScript.direction == "W") {
			GoNorth();
			if (Nempty == true) {
				GoWest();
				if (Nempty == true && Wempty == true) {
					GoEast();
				}
			}
		}
	}
	public void TSouth(){
		if (CheckerScript.direction == "E") {
			GoSouth();
			if (Sempty == true) {
				GoEast();
				if (Sempty == true && Eempty == true) {
					GoWest();
				}
			}
		}
		if (CheckerScript.direction == "N") {
			GoEast();
			if (Eempty == true) {
				GoWest();
				if (Wempty == true && Eempty == true) {
					GoSouth();
				}
			}
		}
		if (CheckerScript.direction == "W") {
			GoWest();
			if (Wempty == true) {
				GoSouth();
				if (Wempty == true && Sempty == true) {
					GoEast();
				}
			}
		}
	}
	public void TWest(){
		if (CheckerScript.direction == "S") { // go west and then south
			GoWest();
			if (Wempty == true) {
				GoSouth();
				if (Sempty == true && Wempty == true) {
					GoNorth();
				}
			}
		}
		if (CheckerScript.direction == "N") { // go north and then west
			GoNorth();
			if (Nempty == true) {
				GoWest();
				if (Nempty == true && Wempty == true) {
					GoSouth();
				}
			}

		}
		if (CheckerScript.direction == "E") { // go south and then north
			GoSouth();
			if (Sempty == true) {
				GoNorth();
				if (Sempty == true && Nempty == true) {
					GoWest();
				}
			}
		
		}
	}
	public void TEast(){
		if (CheckerScript.direction == "S") { // go south and east
			GoSouth();
			if (Sempty == true) {
				GoEast();
				if (Sempty == true && Eempty == true) {
					GoNorth();
				}
			}

		}
		if (CheckerScript.direction == "N") { //go east and then north
			GoEast();
			if (Eempty == true) {
				GoNorth();
				if (Nempty == true && Eempty == true) {
					GoSouth();
				}
			}
		
		}
		if (CheckerScript.direction == "W") { // go north and then south
			GoNorth();
			if (Nempty == true) {
				GoSouth();
				if (Sempty == true && Nempty == true) {
					GoEast();
				}
			}
		
		}
	}
	public void Cross(){
		if (CheckerScript.direction == "N") { // go east,north and then west
			GoEast();
			if (Eempty == true) {
				GoNorth();
				if (Eempty == true && Nempty == true) {
					GoWest();
					if (Eempty == true && Nempty == true && Wempty == true) {
						GoSouth();
					}
				}
			}


		}
		if (CheckerScript.direction == "S") {
			// go west,south and then east
			GoWest();
			if (Wempty == true) {
				GoSouth();
				if (Wempty == true && Sempty == true) {
					GoEast();
					if (Eempty == true && Sempty == true && Wempty == true) {
						GoNorth();
					}
				}
			}
		}
		if (CheckerScript.direction == "E") {//go south,east and then north
			GoSouth();
			if (Sempty == true) {
				GoEast();
				if (Sempty == true && Eempty == true) {
					GoNorth();
					if (Eempty == true && Nempty == true && Sempty == true) {
						GoWest();
					}
				}
			}


		}
		if (CheckerScript.direction == "W") { // go north,west and then south
			GoNorth();
			if (Nempty == true) {
				GoWest();
				if (Nempty == true && Wempty == true) {
					GoSouth();
					if (Sempty == true && Nempty == true && Wempty == true) {
						GoEast();
					}
				}
			}
		}
	}
	void GoNorth(){
		checker.transform.position += new Vector3(0,distance,0); // go north
		Debug.DrawRay (checker.transform.position, checker.transform.forward*500, Color.red);
		if (Physics.Raycast(checker.transform.position,checker.transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			Debug.Log(tempHitObj);
			if (MesoLists.Northlist.Contains(tempHitObj)) {
				CheckerScript.direction = "N";
				tempHitObj.GetComponent<ColorChange>().isCorrect = true;
			}else{
				checker.transform.position -= new Vector3(0,distance,0);
				Nempty = true;
			}
		}
	}
	void GoSouth(){
		checker.transform.position -= new Vector3(0,distance,0); // go South
		Debug.DrawRay (checker.transform.position, checker.transform.forward*500, Color.red);
		if (Physics.Raycast(checker.transform.position,checker.transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			Debug.Log(tempHitObj);
			if (MesoLists.Southlist.Contains(tempHitObj)) {
				CheckerScript.direction = "S";
				if (tempHitObj.gameObject.name != "EndPipe") {
					tempHitObj.GetComponent<ColorChange>().isCorrect = true;
				}
			}else{
				checker.transform.position += new Vector3(0,distance,0);
				Sempty = true;
			}
		}
	}
	void GoWest(){
		checker.transform.position -= new Vector3(distance,0,0); // go west
		Debug.DrawRay (checker.transform.position, checker.transform.forward*500, Color.red);
		if (Physics.Raycast(checker.transform.position,checker.transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			Debug.Log(tempHitObj);
			if (MesoLists.Westlist.Contains(tempHitObj)) {
				CheckerScript.direction = "W";
				tempHitObj.GetComponent<ColorChange>().isCorrect = true;
			}else{
				checker.transform.position += new Vector3(distance,0,0);
				Wempty = true;
			}
		}
	}
	void GoEast(){
		checker.transform.position += new Vector3(distance,0,0); // go east
		Debug.DrawRay (checker.transform.position, checker.transform.forward*500, Color.red);
		if (Physics.Raycast(checker.transform.position,checker.transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			Debug.Log(tempHitObj);
			if (MesoLists.Eastlist.Contains(tempHitObj)) {
				CheckerScript.direction = "E";
				tempHitObj.GetComponent<ColorChange>().isCorrect = true;
			}else{
				checker.transform.position -= new Vector3(distance,0,0);
				Eempty = true;
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
