using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	public static int score;
	public string playerName;
	// Use this for initialization
	void Start () {
	
	}

	void OnGUI(){
		//Debug.Log ("hoi");
		GUI.Box (new Rect (10,10,150,90), "Score");
		GUI.Box (new Rect (10, 60, 150, 20), "Current Score:" + score);
		
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (score);
	}
}
