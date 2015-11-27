using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpeningChecker : MonoBehaviour {
	GameObject tempHitObj;
	float distance = 1.1f;
	Ray ray;
	RaycastHit hit;
	
	public int openings;//debug purposes

	// Use this for initialization
	void Start () {

	}
	public void Solve(){
	for (int i = 0; i < MesoLists.TileList.Count; i++) {
			transform.position = new Vector3(MesoLists.TileList[i].transform.position.x,MesoLists.TileList[i].transform.position.y, 0) ;
			OpeningCheck();
		}
	}
	void OpeningCheck(){
	if (Physics.Raycast(transform.position,transform.forward, out hit)) {
		switch (hit.transform.gameObject.name) {
		case "Tile":
				// do nothing
		break;
		case "LNorthEast" :
			GoNorth();
			GoEast();
			break;
		case "StraightVert":
			GoNorth();
			GoSouth();
			break;
		case "StraightHor":
			GoEast();
			GoWest();
			break;
		case "TWest":
			GoNorth();
			GoSouth();
			GoWest();
			break;
		case "TEast":
			GoNorth();
			GoSouth();
			GoEast();
			break;
		case "Cross":
			GoNorth();
			GoSouth();
			GoEast();
			GoWest();
			break;
			}
		}
	}
	void GoNorth(){
		transform.position += new Vector3(0,distance,0); // go north
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			if (MesoLists.Northlist.Contains(tempHitObj)) {
			}else{
				ScoreScript.score -= 10;
				openings += 1;
			}
		}
		transform.position -= new Vector3(0,distance,0);
	}
	void GoSouth(){
		transform.position -= new Vector3(0,distance,0); // go South
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			if (MesoLists.Southlist.Contains(tempHitObj)) {
			}else{
				ScoreScript.score -= 10;
				openings += 1;
			}
		}
		transform.position += new Vector3(0,distance,0);
	}
	void GoWest(){
		transform.position -= new Vector3(distance,0,0); // go west
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			if (MesoLists.Westlist.Contains(tempHitObj)) {	
			}else{
				ScoreScript.score -= 10;
				openings += 1;
			}
		}
		transform.position += new Vector3(distance,0,0);
	}
	void GoEast(){
		transform.position += new Vector3(distance,0,0); // go east
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			if (MesoLists.Eastlist.Contains(tempHitObj)) {
			}else{
				ScoreScript.score -= 10;
				openings += 1;
			}
		}
		transform.position -= new Vector3(distance,0,0);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
