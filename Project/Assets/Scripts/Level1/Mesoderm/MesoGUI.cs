using UnityEngine;
using System.Collections;

public class MesoGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	
	void OnGUI(){
		//Debug.Log ("hoi");
		GUI.Box (new Rect (10,10,100,90), "Score");
		GUI.TextArea (new Rect (10, 40, 100, 20), "Current:" + OpeningChecker.score);
		GUI.TextArea (new Rect (10, 70, 100, 20), "Bonus:" + CheckerScript.bonusPoints);
		GUI.TextArea (new Rect (10, 100, 100, 20), "Total:" + OpeningChecker.score + CheckerScript.bonusPoints);
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
