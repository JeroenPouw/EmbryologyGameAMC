using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
	string objectname;
	// Use this for initialization
	void Start () {
	
	}

	void LevelSwitch(){
	switch (objectname) {
		case "New Game":
			Application.LoadLevel("Overworld");
			break;
		}
	}
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Input.GetMouseButtonUp(0)) {
			if (Physics.Raycast(ray,out hit)) {
				objectname = hit.collider.gameObject.name;
				LevelSwitch();
			}
		}
	}
}
