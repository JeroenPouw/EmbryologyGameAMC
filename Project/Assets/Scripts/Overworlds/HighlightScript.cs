using UnityEngine;
using System.Collections;

public class HighlightScript : MonoBehaviour {

	public bool ShowThisGUI = false;

	TextAsset InfoText; 

	string GUIString;
	string GUIInfoString;
	// Use this for initialization
	void Awake () {

	}

	void OnMouseOver()
	{
		switch (gameObject.tag) { // if mouseOver == true, show infotext.
			// ----------------------------- Level 1 ------------------------------------------------------------
		case "Endoderm":
			GUIString = "Endoderm";
			InfoText = Resources.Load ("MyTexts/Endoderm") as TextAsset;
			GUIInfoString = InfoText.text;
			break;
		case "Ectoderm":
			GUIString = "Ectoderm";
			InfoText = Resources.Load ("MyTexts/Ectoderm") as TextAsset;
			GUIInfoString = InfoText.text;
			break;
		case "Mesoderm":
			GUIString = "Mesoderm";
			InfoText = Resources.Load ("MyTexts/Mesoderm") as TextAsset;
			GUIInfoString = InfoText.text;
			break;
		case "Yolk Sac":
			GUIString = "Yolk Sac";
			InfoText = Resources.Load ("MyTexts/Yolk Sac") as TextAsset;
			GUIInfoString = InfoText.text;
			break;
		case "Amnion Wall":
			GUIString = "Amnion Wall";
			InfoText = Resources.Load ("MyTexts/Amnion Wall") as TextAsset;
			GUIInfoString = InfoText.text;
			break;
		case "Connecting Stalk":
			GUIString = "Connecting Stalk";
			InfoText = Resources.Load ("MyTexts/Connecting Stalk") as TextAsset;
			GUIInfoString = InfoText.text;
			break;	
			// ----------------------------- Level 1 ------------------------------------------------------------

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
			if(GUI.Button(new Rect(Screen.width / 2 - 190, Screen.height / 2 - 140, 240, 320), GUIInfoString)) {
				GUI.Box(new Rect(Screen.width/2 - 190, Screen.height/2 -140,240,320), GUIInfoString);
			}
		}
		
	}

	// Update is called once per frame
	void Update () {
	}
}
