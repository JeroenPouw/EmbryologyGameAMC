using UnityEngine;
using System.Collections;

public class HighlightScript : MonoBehaviour {

	public bool ShowThisGUI = false;
	string GUIString;
	// Use this for initialization
	void Start () {

	}

	void OnMouseOver()
	{
		switch (gameObject.tag) {
		case "Endoderm":
			GUIString = "Endoderm";
			break;
		case "Ectoderm":
			GUIString = "Ectoderm";
			break;
		case "Mesoderm":
			GUIString = "Mesoderm";
			break;
		case "Yolk Sac":
			GUIString = "Yolk Sac";
			break;
		case "Amnion Wall":
			GUIString = "Amnion Wall";
			break;
		case "Connecting Stalk":
			GUIString = "Connecting Stalk";
			break;	

		}
		if (Input.GetKeyDown(KeyCode.Space)){
			ShowThisGUI = true;
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			ShowThisGUI = false;
		}
		if (gameObject.tag != ("nonTrans") && gameObject.tag != ("Player")){
			if (GetComponent<Renderer>().material.color.a <= 0.4f && GetComponent<Renderer>().material.shader == Shader.Find("Transparent/Diffuse")) {
				GetComponent<Renderer> ().material.shader = Shader.Find ("Transparent/Diffuse");
				GetComponent<Renderer> ().material.color += new Color (0, 0, 0, 0.4f);
			}
		}
	}

	void OnMouseExit()
	{
		if (gameObject.tag != ("nonTrans") && gameObject.tag != ("Player")) {
			if (GetComponent<Renderer>().material.color.a >= 0.5f && GetComponent<Renderer>().material.shader == Shader.Find("Transparent/Diffuse")) {
				GetComponent<Renderer> ().material.shader = Shader.Find ("Transparent/Diffuse");
				GetComponent<Renderer> ().material.color -= new Color (0, 0, 0, 0.4f);
			}
		}
	}

	void OnGUI() {
		
		if (ShowThisGUI) {
			
			GUI.Box(new Rect(Screen.width / 2 - 190, Screen.height / 2 - 140, 240, 320), GUIString);

			// Make the first button
			if(GUI.Button(new Rect(Screen.width / 2 - 190, Screen.height / 2 - 140, 240, 320), "Infos:" + GUIString)) {
				//text
			}
		}
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
