using UnityEngine;
using System.Collections;

public class MesoGameController : MonoBehaviour {
	GameObject mesoObj;
	CheckerScript mesoScript;
	GameObject mesoObj2;
	OpeningChecker mesoScript2;
	// Use this for initialization
	void Start () {
		mesoObj = GameObject.Find ("Checker");
		mesoScript = mesoObj.GetComponent<CheckerScript> ();
		mesoObj2 = GameObject.Find ("OpeningChecker");
		mesoScript2 = mesoObj2.GetComponent<OpeningChecker> ();
	}
	void Reset(){
		Application.LoadLevel(Application.loadedLevelName);
	}

	 void Solve(){
		mesoScript.StartCoroutine (mesoScript.Solving());
		mesoScript2.Solve ();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			Reset();
		}
		if (Input.GetKeyDown(KeyCode.M)) {
			Solve();
		}
	}
}
