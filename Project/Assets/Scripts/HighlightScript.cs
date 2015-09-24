using UnityEngine;
using System.Collections;

public class HighlightScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}

	void OnMouseOver()
	{
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
	// Update is called once per frame
	void Update () {
	
	}
}
