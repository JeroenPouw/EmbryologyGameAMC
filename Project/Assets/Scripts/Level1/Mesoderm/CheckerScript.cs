using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckerScript : MonoBehaviour {
	public List<GameObject> Northlist = new List<GameObject>();
	public List<GameObject> Eastlist = new List<GameObject>();
	public List<GameObject> Westlist = new List<GameObject>();
	public List<GameObject> Southlist = new List<GameObject>();
	public List<GameObject> PipeList = new List<GameObject> ();

	string direction;

	GameObject tempHitObj;
	float distance = 1.1f;

	public static int bonusPoints;

	RaycastHit hit;

	bool Nempty;
	bool Sempty;
	bool Eempty;
	bool Wempty;

	bool GameOver;
	// Use this for initialization
	void Start () {
		GameObject[] allList = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
		for (int i = 0; i < allList.Length; i++) {
			if (allList[i].gameObject.tag.Contains("East")) {
				Eastlist.Add(allList[i]);
			}
			if (allList[i].gameObject.tag.Contains("West")) {
				Westlist.Add(allList[i]);
			}
			if (allList[i].gameObject.tag.Contains("North")) {
				Northlist.Add(allList[i]);
			}
			if (allList[i].gameObject.tag.Contains("South")) {
				Southlist.Add(allList[i]);
			}
			if (allList[i].gameObject.tag.Contains("Pipe")) {
				PipeList.Add(allList[i]);
			}
		}
		Eastlist.Add(GameObject.Find("EndPipe"));
		Southlist.Add(GameObject.Find("EndPipe"));
		Northlist.Add(GameObject.Find("EndPipe"));
		Westlist.Add(GameObject.Find("EndPipe"));
		Eastlist.Add(GameObject.Find("Organ"));
		Southlist.Add(GameObject.Find("Organ"));
		Northlist.Add(GameObject.Find("Organ"));
		Westlist.Add(GameObject.Find("Organ"));
	}

	void Check(){
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
		//	Debug.Log("Tile:" + hit.transform.gameObject.name);
			switch (hit.transform.gameObject.name) {
			case "EndPipe":
				if (bonusPoints >= 1 && GameOver == false) {
					OpeningChecker.score += 100;
					OpeningChecker.score += bonusPoints;
					GameOver = true;
					//Application.LoadLevel("Overworld");
				}
			break;
			case "Organ":
				bonusPoints += 10;
				Cross();
				break;
			case "StartPipe":
			//	Debug.Log("start");
				direction = "S";
				GoSouth();
				break;
			case "LNorthWest":
				if (direction == "S") {
					GoWest();
					if (Wempty) {
						GoNorth();
					}
				}
				if (direction == "E") {
					GoNorth();
					if (Nempty) {
						GoWest();
					}
				}
				break;
			case "LSouthEast":
				if (direction == "W") {
					GoSouth();
					if (Sempty) {
						GoEast();
					}
				}
				if (direction == "N") {
					GoEast();
					if (Eempty) {
						GoSouth();
					}
				}
				break;
			case "LNorthEast":
				if (direction == "S") {
					GoEast();
					if (Eempty == true) {
						GoNorth();
					}
				}
				if (direction == "W") {
					GoNorth();
					if (Nempty == true) {
						GoEast();
					}
				}
				break;
			case "LSouthWest":
				if (direction == "E") {
					GoSouth();
					if (Sempty) {
						GoWest();
					}
				}
				if (direction == "N") {
					GoWest();
					if (Wempty) {
						GoSouth();
					}
				}

				break;
			case "StraightVert":
				if (direction == "S") {
					GoSouth();
					if (Sempty == true) {
						GoNorth();
					}
				}
				if (direction == "N") {
					GoNorth();
					if (Nempty == true) {
						GoSouth();
					}
				}
				break;
			case "StraightHor":
				if (direction == "W") {
					GoWest();
					if (Wempty == true) {
						GoEast();
					}
				}
				if (direction == "E") {
					GoEast();
					if (Eempty == true) {
						GoWest();
					}
				}
				break;
			case "TNorth":
				if (direction == "E") {
					GoWest();
					if (Wempty) {
						GoNorth();
					}
					if (Wempty && Nempty) {
						GoEast();
					}
				}
				if (direction == "S") {
					GoWest();
					if (Wempty) {
						GoEast();
					}
					if (Wempty && Eempty) {
						GoNorth();
					}
				}
				if (direction == "W") {
					GoNorth();
					if (Nempty) {
						GoWest();
					}
					if (Nempty && Wempty) {
						GoEast();
					}
				}
				break;
			case "TSouth":
				if (direction == "E") {
					GoSouth();
					if (Sempty) {
						GoEast();
					}
					if (Sempty && Eempty) {
						GoWest();
					}
				}
				if (direction == "N") {
					GoEast();
					if (Eempty) {
						GoWest();
					}
					if (Wempty && Eempty) {
						GoSouth();
					}
				}
				if (direction == "W") {
					GoWest();
					if (Wempty) {
						GoSouth();
					}
					if (Wempty && Sempty) {
						GoEast();
					}
				}
				break;
			case "TWest":
				if (direction == "S") { // go west and then south
					GoWest();
					if (Wempty = true) {
						GoSouth();
					}
					if (Sempty && Wempty) {
						GoNorth();
					}
				}
				if (direction == "N") { // go north and then west
					GoNorth();
					if (Nempty = true) {
						GoWest();
					}
					if (Nempty && Wempty) {
						GoSouth();
					}
				}
				if (direction == "E") { // go south and then north
					GoSouth();
					if (Sempty == true) {
						GoNorth();
					}
					if (Sempty && Nempty) {
						GoWest();
					}
				}
				break;
			case "TEast":
				if (direction == "S") { // go south and east
					GoSouth();
					if (Sempty = true) {
						GoEast();
					}
					if (Sempty && Eempty) {
						GoNorth();
					}
				}
				if (direction == "N") { //go east and then north
					GoEast();
					if (Eempty = true) {
						GoNorth();
					}
					if (Nempty && Eempty) {
						GoSouth();
					}
				}
				if (direction == "W") { // go north and then south
					GoNorth();
					if (Nempty == true) {
						GoSouth();
					}
					if (Sempty && Nempty) {
						GoEast();
					}
				}
				break;
			case "Cross":
				Cross();
				break;
				}
			
			}
		Nempty = false;
		Sempty = false;
		Eempty = false;
		Wempty = false;
		}

	void Cross(){
		if (direction == "N") { // go east,north and then west
			GoEast();
			if (Eempty == true) {
				GoNorth();
			}
			if (Eempty == true && Nempty == true) {
				GoWest();
			}
			if (Eempty && Nempty && Wempty) {
				GoSouth();
			}
		}
		if (direction == "S") { // go west,south and then east
			GoWest();
			if (Wempty == true) {
				GoSouth();
			}
			if (Wempty == true && Sempty == true) {
				GoEast();	
			}
			if (Eempty && Sempty && Wempty) {
				GoNorth();
			}
		}
		if (direction == "E") {//go south,east and then north
			GoSouth();
			if (Sempty == true) {
				GoEast();
			}
			if (Sempty == true && Eempty == true) {
				GoNorth();
			}
			if (Eempty && Nempty && Sempty) {
				GoWest();
			}
		}
		if (direction == "W") { // go north,west and then south
			GoNorth();
			if (Nempty == true) {
				GoWest();
			}
			if (Nempty == true && Wempty == true) {
				GoSouth();
			}
			if (Sempty && Nempty && Wempty) {
				GoEast();
			}
		}
	
	}
	void GoNorth(){
		transform.position += new Vector3(0,distance,0); // go north
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			if (Northlist.Contains(tempHitObj)) {

			//	if (Physics.Raycast(transform.position,transform.forward,out hit,200,pipeMask)) {
				//		tempHitObj = hit.transform.gameObject;
				//tempHitObj.GetComponent<Renderer>().enabled = true;
				//}
				direction = "N";
				Debug.Log (direction);
				tempHitObj.GetComponent<ColorChange>().isCorrect = true;
				return;
			}else{
				transform.position -= new Vector3(0,distance,0);
				Nempty = true;
			}
		}
	}
	void GoSouth(){
		transform.position -= new Vector3(0,distance,0); // go South
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			if (Southlist.Contains(tempHitObj)) {
				//if (Physics.Raycast(transform.position,transform.forward,out hit,200,pipeMask)) {
				//	tempHitObj = hit.transform.gameObject;
				//tempHitObj.GetComponent<Renderer>().enabled = true;
				//}
				direction = "S";
				Debug.Log (direction);
				tempHitObj.GetComponent<ColorChange>().isCorrect = true;
				return;
			}else{
				transform.position += new Vector3(0,distance,0);
				Sempty = true;
			}
		}
	}
	void GoWest(){
		transform.position -= new Vector3(distance,0,0); // go west
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			if (Westlist.Contains(tempHitObj)) {
				//if (Physics.Raycast(transform.position,transform.forward,out hit,200,pipeMask)) {
				//	tempHitObj = hit.transform.gameObject;
			//	tempHitObj.GetComponent<Renderer>().enabled = true;
				//}
				direction = "W";
				Debug.Log (direction);
				tempHitObj.GetComponent<ColorChange>().isCorrect = true;
				return;
			}else{
				transform.position += new Vector3(distance,0,0);
				Wempty = true;
			}
		}
	}
	void GoEast(){
		transform.position += new Vector3(distance,0,0); // go east
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			if (Eastlist.Contains(tempHitObj)) {
				//if (Physics.Raycast(transform.position,transform.forward,out hit,200,pipeMask)) {
				//	tempHitObj = hit.transform.gameObject;
			//	tempHitObj.GetComponent<Renderer>().enabled = true;
				//}
				direction = "E";
				Debug.Log (direction);
				tempHitObj.GetComponent<ColorChange>().isCorrect = true;
				return;
			}else{
				transform.position -= new Vector3(distance,0,0);
				Eempty = true;
			}
		}
	}

	IEnumerator Solve(){
		for (int i = 0; i < (PipeList.Count*2); i++) {
			Check ();
			yield return new WaitForSeconds(2f);
		}
	
	}


	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.M)) {
			StartCoroutine(Solve ());
		}
	}
}
