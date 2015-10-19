using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpeningChecker : MonoBehaviour {

	public List<GameObject> Northlist = new List<GameObject>();
	public List<GameObject> Eastlist = new List<GameObject>();
	public List<GameObject> Westlist = new List<GameObject>();
	public List<GameObject> Southlist = new List<GameObject>();
	public List<GameObject> TileList = new List<GameObject> ();

	GameObject tempHitObj;
	float distance = 1.1f;
	Ray ray;
	RaycastHit hit;

	public int score;
	public int openings;

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
		
			if (allList[i].gameObject.name == "Tile") {
				TileList.Add(allList[i]);
			}
		}
		Eastlist.Add(GameObject.Find("EndPipe"));
		Southlist.Add(GameObject.Find("EndPipe"));
		Northlist.Add(GameObject.Find("EndPipe"));
		Westlist.Add(GameObject.Find("EndPipe"));
		Eastlist.Add(GameObject.Find("StartPipe"));
		Southlist.Add(GameObject.Find("StartPipe"));
		Northlist.Add(GameObject.Find("StartPipe"));
		Westlist.Add(GameObject.Find("StartPipe"));

	}
	void Solve(){
	for (int i = 0; i < TileList.Count; i++) {
			transform.position = new Vector3(TileList[i].transform.position.x,TileList[i].transform.position.y, 0) ;
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
			if (Northlist.Contains(tempHitObj)) {
				tempHitObj.GetComponent<Renderer>().material.color = Color.green;
				Debug.Log("correct");
			}else{
				Debug.Log("NorthOpening");
				score -= 10;
				openings += 1;
			}
		}
		transform.position -= new Vector3(0,distance,0);
	}
	void GoSouth(){
		transform.position -= new Vector3(0,distance,0); // go South
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			if (Southlist.Contains(tempHitObj)) {
				tempHitObj.GetComponent<Renderer>().material.color = Color.green;
				Debug.Log("correct");
			}else{
				Debug.Log("SouthOpening");
				score -= 10;
				openings += 1;
			}
		}
		transform.position += new Vector3(0,distance,0);
	}
	void GoWest(){
		transform.position -= new Vector3(distance,0,0); // go west
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			if (Westlist.Contains(tempHitObj)) {	
				tempHitObj.GetComponent<Renderer>().material.color = Color.green;
				Debug.Log("correct");
			}else{
				Debug.Log("WestOpening");
				score -= 10;
				openings += 1;
			}
		}
		transform.position += new Vector3(distance,0,0);
	}
	void GoEast(){
		transform.position += new Vector3(distance,0,0); // go east
		if (Physics.Raycast(transform.position,transform.forward,out hit)) {
			tempHitObj = hit.transform.gameObject;
			if (Eastlist.Contains(tempHitObj)) {
				tempHitObj.GetComponent<Renderer>().material.color = Color.green;
				Debug.Log("correct");
			}else{
				Debug.Log("EastOpening");
				score -= 10;
				openings += 1;
			}
		}
		transform.position -= new Vector3(distance,0,0);
	}

	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.M)) {
			Solve();
		}
	}
}
