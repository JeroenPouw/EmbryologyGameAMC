using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckerScript : MonoBehaviour {
	public List<GameObject> Northlist = new List<GameObject>();
	public List<GameObject> Eastlist = new List<GameObject>();
	public List<GameObject> Westlist = new List<GameObject>();
	public List<GameObject> Southlist = new List<GameObject>();
	public List<GameObject> PipeList = new List<GameObject> ();

	string direction = "S";

	bool north;
	bool west;
	bool east;
	bool south;

	GameObject tempHitObj;
	float distance = 1.1f;

	public LayerMask pipeMask;
	public LayerMask tileMask;

	Ray ray;
	RaycastHit hit;

	bool Nempty;
	bool Sempty;
	bool Eempty;
	bool Wempty;
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
	}

	void Check(){
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			Debug.Log("Tile:" + hit.transform.gameObject.name);
			switch (hit.transform.gameObject.name) {
			case "EndPipe":
				Application.LoadLevel("Overworld");
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
			case "TWest":
				if (direction == "S") { // go south and then west
					GoSouth();
					if (Sempty = true) {
						GoWest();
					}
				}
				if (direction == "N") { // go north and then west
					GoNorth();
					if (Nempty = true) {
						GoWest();
					}
				}
				if (direction == "E") { // go south and then north
					GoSouth();
					if (Sempty == true) {
						GoNorth();
					}
				}
				break;
			case "TEast":
				if (direction == "S") { // go south and east
					GoSouth();
					if (Sempty = true) {
						GoEast();
					}
				}
				if (direction == "N") { //go north and then east
					GoNorth();
					if (Nempty = true) {
						GoEast();
					}
				}
				if (direction == "W") { // go south and then north
					GoSouth();
					if (Sempty == true) {
						GoNorth();
					}
				}
				break;
			case "Cross":
				if (direction == "N") { // go east,north and then west
					GoEast();
					if (Eempty == true) {
						GoNorth();
					}
					if (Eempty == true && Nempty == true) {
						GoWest();
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
				}
				if (direction == "E") {//go south,east and then north
					GoSouth();
						if (Sempty == true) {
						GoEast();
					}
						if (Sempty == true && Eempty == true) {
						GoNorth();
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
					}
					break;
				}
			
			}
		Nempty = false;
		Sempty = false;
		Eempty = false;
		Wempty = false;
		}


	void GoNorth(){
		transform.position += new Vector3(0,distance,0); // go north
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			if (Northlist.Contains(tempHitObj)) {
				direction = "N";
				return;
			}else
				transform.position -= new Vector3(0,distance,0);
			Nempty = true;
		}
	}
	void GoSouth(){
		transform.position -= new Vector3(0,distance,0); // go South
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			if (Southlist.Contains(tempHitObj)) {
				direction = "S";
				return;
			}else
				transform.position += new Vector3(0,distance,0);
			Sempty = true;
		}
	}
	void GoWest(){
		transform.position -= new Vector3(distance,0,0); // go west
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			if (Westlist.Contains(tempHitObj)) {
				direction = "W";
				return;
			}else
				transform.position += new Vector3(distance,0,0);
			Wempty = true;
		}
	}
	void GoEast(){
		transform.position += new Vector3(distance,0,0); // go east
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			if (Eastlist.Contains(tempHitObj)) {
				direction = "E";
				return;
			}else
				transform.position -= new Vector3(distance,0,0);
			Eempty = true;
		}
	}

	void Solve(){
		for (int i = 0; i < (PipeList.Count*2); i++) {
			Check ();
		}
	
	}
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.M)) {
			Solve ();
		}
	}
}
