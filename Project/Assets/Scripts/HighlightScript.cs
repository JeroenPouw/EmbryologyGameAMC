using UnityEngine;
using System.Collections;

public class HighlightScript : MonoBehaviour {

	public bool ShowThisGUI = false;

	// Use this for initialization
	void Start () {

	}

	void OnMouseOver()
	{
		if (Input.GetKeyDown(KeyCode.Space)&& gameObject.layer == 4){
			ShowThisGUI = true;
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
		ShowThisGUI = false;
		if (gameObject.tag != ("nonTrans") && gameObject.tag != ("Player")) {
			if (GetComponent<Renderer>().material.color.a >= 0.5f && GetComponent<Renderer>().material.shader == Shader.Find("Transparent/Diffuse")) {
				GetComponent<Renderer> ().material.shader = Shader.Find ("Transparent/Diffuse");
				GetComponent<Renderer> ().material.color -= new Color (0, 0, 0, 0.4f);
			}
		}
	}

	void OnGUI() {
		
		if (ShowThisGUI) {
			
			GUI.Box(new Rect(Screen.width / 2 - 190, Screen.height / 2 - 140, 240, 320), "This is a title");

			// Make the first button
			if(GUI.Button(new Rect(Screen.width / 2 - 190, Screen.height / 2 - 140, 240, 320), "Infos")) {
				//text
			}
		}
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
